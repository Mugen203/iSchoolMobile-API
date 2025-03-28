using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.GetSchedule.Models;

namespace iSchool_Solution.Features.Courses.GetSchedule;

[Authorize]
public class Endpoint : EndpointWithoutRequest<ScheduleResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly CourseQueryService _courseQueryService;

    public Endpoint(CourseQueryService courseQueryService, ILogger<Endpoint> logger)
    {
        _logger = logger;
        _courseQueryService = courseQueryService;
    }

    public override void Configure()
    {
        Get("api/student/schedule");
        Roles("Student");
        Description(description => description
            .WithName("GetStudentSchedule")
            .WithSummary("Gets a student's course schedule")
            .WithTags("Courses")
            .Produces<ScheduleResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID (NameIdentifier) claim was not found in token.");
            await SendUnauthorizedAsync(cancellationToken); 
            return;
        }

        try
        {
            var scheduleResponse = await _courseQueryService.GetStudentScheduleAsync(studentID);
            _logger.LogInformation("Retrieved schedule for student: {studentID} with {courseCount} courses",
                studentID, scheduleResponse.Courses.Count);
            await SendOkAsync(scheduleResponse, cancellationToken);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning("Student: {studentID} not found during schedule retrieval", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving student schedule for student: {studentID}", studentID);
            AddError("Unexpected error during your schedule retrieval");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}