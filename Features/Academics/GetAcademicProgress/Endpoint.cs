using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Academics.GetAcademicProgress.Models; // Use models from this feature

namespace iSchool_Solution.Features.Academics.GetAcademicProgress;

[Authorize]
public class Endpoint : EndpointWithoutRequest<AcademicSummaryResponse>
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
        Get("/api/student/academic-progress"); 
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Retrieves a summary of the student's academic progress.";
            s.Description = "Includes cumulative GPA, credits earned/attempted, academic standing, and semester breakdowns.";
            s.Responses[200] = "Academic progress summary returned successfully.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden.";
            s.Responses[404] = "Student or transcript not found.";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Academics", "Student"); 
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID (NameIdentifier) claim was not found in token for academic progress request.");
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Fetching academic progress summary for StudentID: {StudentID}", studentID);

        try
        {
            // Call the existing service method
            var summary = await _studentService.GetAcademicProgressSummaryAsync(studentID);

            _logger.LogInformation("Successfully fetched academic progress summary for StudentID: {StudentID}", studentID);
            await SendOkAsync(summary, ct);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student not found when fetching academic progress for StudentID: {StudentID}", studentID);
            AddError(ex.Message);
            await SendNotFoundAsync(ct);
        }
        catch (TranscriptNotFoundException ex)
        {
             _logger.LogWarning(ex, "Transcript not found when fetching academic progress for StudentID: {StudentID}", studentID);
             AddError(ex.Message);
             await SendNotFoundAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching academic progress summary for StudentID: {StudentID}", studentID);
            AddError("An unexpected error occurred while retrieving academic progress.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}