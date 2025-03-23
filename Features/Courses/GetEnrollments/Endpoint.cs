using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.GetEnrollments.Models;

namespace iSchool_Solution.Features.Courses.GetEnrollments;

[Authorize]
public class Endpoint: Endpoint<EnrollmentsRequest, EnrollmentsResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly CourseQueryService _courseQueryService;

    public Endpoint(ILogger<Endpoint> logger, CourseQueryService courseQueryService)
    {
        _logger = logger;
        _courseQueryService = courseQueryService;
    }

    public override void Configure()
    {
        Get("api/student/enrollments");
        Roles("Student");
        Description(description => description
            .WithName("GetStudentEnrollments")
            .WithSummary("Gets a student's course enrollments")
            .WithTags("Courses")
            .Produces<EnrollmentsResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(EnrollmentsRequest request, CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue("studentID");
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID was not found in token claims during enrollments retrieval");
            AddError("Student ID is required but not found");
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
            return;
        }

        try
        {
            var enrollmentResponse = await _courseQueryService.GetStudentEnrolledCoursesAsync(studentID, request);
            _logger.LogInformation("Retrieved enrollments for student {StudentID} with {EnrollmentCount} courses",
                studentID, enrollmentResponse.Enrollments.Count);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student {StudentID} not found during enrollments retrieval", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Student {StudentID} enrollments retrieval failed", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}