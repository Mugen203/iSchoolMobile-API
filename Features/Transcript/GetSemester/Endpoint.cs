using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Transcript.GetSemester.Models;

namespace iSchool_Solution.Features.Transcript.GetSemester;

[Authorize]
public class Endpoint : Endpoint<SemesterTranscriptRequest, SemesterTranscriptResponse>
{
    private readonly TranscriptService _transcriptService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(TranscriptService transcriptService, ILogger<Endpoint> logger)
    {
        _transcriptService = transcriptService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/students/{studentID}/transcript/{academicYear}/{semester}");
        Roles("Student");
        Description(description => description
            .WithName("GetSemesterTranscript")
            .WithSummary("Gets detailed transcript information for a specific semester")
            .WithTags("Transcript")
            .Produces<SemesterTranscriptResponse>(200, "application/json")
            .ProducesProblem(404)
            .ProducesProblemFE(500)
        );
    }

    public override async Task HandleAsync(SemesterTranscriptRequest request, CancellationToken cancellationToken)
    {
        var authenticatedUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _logger.LogInformation(
            "Semester transcript requested for StudentID: {RequestedStudentID} (Year: {AcademicYear}, Semester: {Semester}) by UserID: {AuthenticatedUserID}",
            request.StudentID, request.AcademicYear, request.Semester, authenticatedUserID);

        if (request.StudentID != authenticatedUserID && !User.IsInRole("Admin"))
        {
            _logger.LogWarning(
                "Authorization failed: User {AuthenticatedUserID} attempted to access semester transcript for {RequestedStudentID}.",
                authenticatedUserID, request.StudentID);
            await SendForbiddenAsync(cancellationToken); 
            return;
        }

        try
        {
            if (!string.IsNullOrEmpty(request.AcademicYear) &&
                Enum.IsDefined(request.Semester))
            {
                var response = await _transcriptService.GetSemesterTranscriptAsync(
                    request.StudentID, request.AcademicYear, request.Semester);
                await SendOkAsync(response, cancellationToken);
            }
            // Fall back to ID-based lookup only if specifically provided
            else if (request.SemesterID.HasValue && request.SemesterID.Value != Guid.Empty)
            {
                var response = await _transcriptService.GetSemesterTranscriptAsync(
                    request.StudentID, request.SemesterID.Value);
                await SendOkAsync(response, cancellationToken);
            }
            else
            {
                AddError("Academic year and semester must be provided");
                await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            }
        }
        catch (SemesterRecordNotFoundException ex)
        {
            _logger.LogWarning(ex, "Semester record not found for student {StudentID}", request.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving semester transcript for student {StudentID}", request.StudentID);
            AddError("An unexpected error occurred while retrieving semester transcript");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}