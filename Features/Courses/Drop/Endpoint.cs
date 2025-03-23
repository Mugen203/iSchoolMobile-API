using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Courses.Drop.Models;

namespace iSchool_Solution.Features.Courses.Drop;

public class Endpoint: Endpoint<DropCourseRequest, DropCourseResponse>
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
        Delete("api/courses/drop");
        Roles("Student");
        Description(description => description
            .WithName("DropCourse")
            .WithSummary("Drops a course from student's schedule")
            .WithTags("Courses")
            .Produces<DropCourseResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(DropCourseRequest request, CancellationToken cancellationToken)
    {
         // Get the student ID from claims
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID was not found in token claims during course drop attempt");
            AddError("Student ID is required but not found");
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
            return;
        }
        
        try
        {
            // Call enrollment service to drop the course
            var result = await _enrollmentService.DropCourseAsync(studentID, request.CourseCode);
            
            if (result.Success)
            {
                _logger.LogInformation("Course {CourseID} successfully dropped by student {StudentID}", 
                    request.CourseCode, studentID);
                await SendAsync(result, cancellation: cancellationToken);
            }
            else
            {
                _logger.LogWarning("Failed to drop course {CourseCode} for student {StudentID}", 
                    request.CourseCode, studentID);
                AddError(result.Message);
                await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            }
        }
        catch (CourseNotFoundException ex)
        {
            _logger.LogWarning(ex, "Course {CourseID} not found during drop attempt by student {StudentID}", 
                request.CourseCode, studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (RegistrationException ex)
        {
            _logger.LogWarning(ex, "Registration policy prevented course drop for student {StudentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during course drop for student {StudentID}", studentID);
            AddError("An unexpected error occurred while dropping the course");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}