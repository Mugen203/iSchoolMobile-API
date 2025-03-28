using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Features.Transcript.Get;

[Authorize]
public class Endpoint : EndpointWithoutRequest<TranscriptSummaryResponse>
{
    private readonly StudentService _studentService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(StudentService studentService, ILogger<Endpoint> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/students/{studentID}/transcript/");
        Roles("Student");
        Description(description => description
            .Produces<TranscriptSummaryResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status403Forbidden)
            .ProducesProblem(StatusCodes.Status404NotFound)
        );
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var requestedStudentID = Route<string>("studentID");
        var authenticatedUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _logger.LogInformation(
            "Transcript summary requested for StudentID: {RequestedStudentID} by UserID: {AuthenticatedUserID}",
            requestedStudentID, authenticatedUserID);

        if (string.IsNullOrEmpty(requestedStudentID))
        {
            _logger.LogWarning("StudentID missing from route for transcript request.");
            AddError("StudentID must be provided in the route.");
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            return;
        }

        if (requestedStudentID != authenticatedUserID && !User.IsInRole("Admin"))
        {
            _logger.LogWarning(
                "Authorization failed: User {AuthenticatedUserID} attempted to access transcript for {RequestedStudentID}.",
                authenticatedUserID, requestedStudentID);
            await SendForbiddenAsync(cancellationToken); 
            return;
        }

        try
        {
            var transcriptSummary = await _studentService.GetStudentTranscriptAsync(requestedStudentID);
            _logger.LogInformation("Successfully retrieved transcript summary for StudentID: {RequestedStudentID}",
                requestedStudentID);
            await SendOkAsync(transcriptSummary, cancellationToken);
        }
        catch (TranscriptNotFoundException ex)
        {
            _logger.LogWarning(ex, "Transcript not found for StudentID: {RequestedStudentID}", requestedStudentID);
            AddError(ex.Message);
            await SendNotFoundAsync(cancellationToken); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving transcript summary for StudentID: {RequestedStudentID}",
                requestedStudentID);
            AddError("An unexpected error occurred while retrieving the transcript summary.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}