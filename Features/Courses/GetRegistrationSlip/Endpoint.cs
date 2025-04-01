using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;

namespace iSchool_Solution.Features.Courses.GetRegistrationSlip;

[Authorize]
public class Endpoint : EndpointWithoutRequest
{
    private readonly EnrollmentService _enrollmentService;
    private readonly RegistrationRepository _registrationRepository; // Inject if needed here
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(EnrollmentService enrollmentService, RegistrationRepository registrationRepository,
        ILogger<Endpoint> logger)
    {
        _enrollmentService = enrollmentService;
        _registrationRepository = registrationRepository;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/student/registration-slip/{RegistrationPeriodID:guid?}"); // Make PeriodID optional
        Roles("Student");
        Description(d => d
            .WithName("DownloadRegistrationSlip")
            .WithSummary("Downloads the registration slip for a specific or active period.")
            .WithTags("Courses")
            .Produces(200, contentType: "application/pdf")
            .ProducesProblem(400, "application/json+problem")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404, "application/json+problem")
            .ProducesProblemFE(500)
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        var periodIdFromRoute = Route<Guid?>("RegistrationPeriodID");
        Guid targetPeriodId;

        if (periodIdFromRoute.HasValue && periodIdFromRoute.Value != Guid.Empty)
        {
            targetPeriodId = periodIdFromRoute.Value;
            _logger.LogInformation(
                "Request received for specific RegistrationPeriodID: {PeriodID} by StudentID: {StudentID}",
                targetPeriodId, studentID);
        }
        else
        {
            _logger.LogInformation("Request received for active registration period by StudentID: {StudentID}",
                studentID);
            var activePeriod = await _registrationRepository.GetActiveRegistrationPeriodAsync();
            if (activePeriod == null)
            {
                _logger.LogWarning("No active registration period found for StudentID: {StudentID}", studentID);
                AddError("No active registration period found.");
                await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
                return;
            }

            targetPeriodId = activePeriod.RegistrationPeriodID;
            _logger.LogInformation("Active RegistrationPeriodID: {PeriodID} identified for StudentID: {StudentID}",
                targetPeriodId, studentID);
        }


        try
        {
            var (fileContents, contentType, fileName) =
                await _enrollmentService.GenerateRegistrationSlipPdfAsync(studentID, targetPeriodId);

            await SendBytesAsync(fileContents, fileName, contentType, cancellation: ct);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student not found while generating registration slip: {StudentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        }
        catch (KeyNotFoundException ex) // Catches RegistrationPeriod or Enrollment not found
        {
            _logger.LogWarning(ex,
                "Required record not found while generating registration slip for StudentID: {StudentID}, PeriodID: {PeriodID}",
                studentID, targetPeriodId);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating registration slip for StudentID: {StudentID}, PeriodID: {PeriodID}",
                studentID, targetPeriodId);
            AddError("An unexpected error occurred while generating the registration slip.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}