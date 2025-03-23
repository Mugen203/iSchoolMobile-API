using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.Conflicts.Models;

namespace iSchool_Solution.Features.Courses.Conflicts;

[Authorize]
public class Endpoint: Endpoint<ScheduleConflictRequest, ScheduleConflictResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly EnrollmentService _enrollmentService;

    public Endpoint(ILogger<Endpoint> logger, EnrollmentService enrollmentService)
    {
        _logger = logger;
        _enrollmentService = enrollmentService;
    }

    public override void Configure()
    {
        Get("api/courses/conflicts");
        Roles("Student");
        Description(description => description
            .WithName("CheckScheduleConflicts")
            .WithSummary("Checks for course schedule conflicts")
            .WithTags("Courses")
            .Produces<ScheduleConflictResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(ScheduleConflictRequest request, CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID was not found in token claims during conflict check");
            AddError("Student ID is required but not found");
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
            return;
        }
        
        try
        {
            var conflicts = await _enrollmentService.CheckScheduleConflictsAsync(studentID, request.CourseCodes);
            _logger.LogInformation("Checked schedule conflicts for student {StudentID} with {ConflictCount} conflicts found", 
                studentID, conflicts.Conflicts.Count);
            
            await SendOkAsync(conflicts, cancellationToken);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student {StudentID} not found during conflict check", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (CourseNotFoundException ex)
        {
            _logger.LogWarning(ex, "Course not found during conflict check for student {StudentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during conflict check for student {StudentID}", studentID);
            AddError("An unexpected error occurred while checking for schedule conflicts");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}