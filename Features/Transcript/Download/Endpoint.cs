using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Transcript.Download.Models;

namespace iSchool_Solution.Features.Transcript.Download;

[Authorize]
public class Endpoint : Endpoint<DownloadTranscriptRequest, DownloadTranscriptResponse>
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
        Post("/students/{studentID}/transcript/download");
        Roles("Student");
        Description(description => description
            .WithName("DownloadTranscript")
            .WithSummary("Generates a downloadable transcript file")
            .WithTags("Transcript")
            .Produces<DownloadTranscriptResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }
    
    public override async Task HandleAsync(DownloadTranscriptRequest request, CancellationToken cancellationToken)
    {
        // Get studentID from route or claims if not provided in request
        if (string.IsNullOrEmpty(request.StudentID))
        {
            request.StudentID = Route<string>("studentID");
            
            // If still not available, get from user claims
            if (string.IsNullOrEmpty(request.StudentID))
            {
                request.StudentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(request.StudentID))
                {
                    AddError("Student ID is required");
                    await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
                    return;
                }
            }
        }
        
        // Verify the student is requesting their own transcript
        var userStudentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userStudentID != request.StudentID && !User.IsInRole("Admin"))
        {
            _logger.LogWarning("Student {UserID} attempted to download transcript for {RequestedStudentID}", 
                userStudentID, request.StudentID);
            AddError("You can only download your own transcript");
            await SendErrorsAsync(StatusCodes.Status403Forbidden, cancellationToken);
            return;
        }
        
        try
        {
            // Check if official transcript is requested by student
            if (request.IsOfficial && !User.IsInRole("Admin"))
            {
                // Additional check should be added here for official transcript eligibility
                _logger.LogInformation("Student {StudentID} requested official transcript", request.StudentID);
            }
            
            var response = await _transcriptService.GenerateDownloadableTranscriptAsync(
                request.StudentID, 
                request.IsOfficial, 
                request.Format,
                request.SemesterID,
                request.Purpose);
                
            _logger.LogInformation("Generated downloadable transcript for student {StudentID}", request.StudentID);
            await SendOkAsync(response, cancellationToken);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student not found during transcript download attempt: {StudentID}", request.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (TranscriptNotFoundException ex)
        {
            _logger.LogWarning(ex, "Transcript not found during download attempt: {StudentID}", request.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (SemesterRecordNotFoundException ex)
        {
            _logger.LogWarning(ex, "Semester record not found during transcript download attempt: {StudentID}", request.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (TranscriptRequestException ex)
        {
            _logger.LogWarning(ex, "Transcript request not allowed: {StudentID}", request.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status403Forbidden, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating downloadable transcript for student {StudentID}", request.StudentID);
            AddError("An unexpected error occurred while generating your transcript");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}