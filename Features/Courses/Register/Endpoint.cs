using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Features.Courses.Register;

[Authorize]
public class Endpoint : Endpoint<CourseRegistrationRequest, RegistrationReceiptResponse>
{
    private readonly EnrollmentService _enrollmentService;
    private readonly ILogger<Endpoint> _logger;
    
    public Endpoint(EnrollmentService enrollmentService, ILogger<Endpoint> logger)
    {
        _enrollmentService = enrollmentService;
        _logger = logger;
    }
    
    public override void Configure()
    {
        Post("api/courses/register");
        Roles("Student");
        Description(description => description
            .WithName("RegisterForCourses")
            .Produces<RegistrationReceiptResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(409)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(CourseRegistrationRequest request, CancellationToken cancellationToken)
    {
        //Get the student ID
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID was not found in token claims during course registration");
            AddError("Student ID is required but not found");
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
            return;
        }

        try
        {
            //Use enrollment service to register for courses with course codes
            var result = await _enrollmentService.RegisterForCoursesAsync(studentID, request);
            _logger.LogInformation("Student ID {studentID} was registered for {CourseCount} courses successfully",
                studentID, request.CourseCodes.Count);

            await SendAsync(result);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student ID {studentID} was not found", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (CourseNotFoundException ex)
        {
            _logger.LogWarning(ex, "Course not found during registration for student: {studentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (CourseAlreadyRegisteredException ex)
        {
            _logger.LogWarning(ex, "Course already registered by student: {studentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status409Conflict, cancellationToken);
        }
        catch (ScheduleConflictException ex)
        {
            _logger.LogWarning(ex, "Schedule conflict detected during registration for student: {studentID}",
                studentID);
            AddError("Schedule conflict detected: " + ex.Message);
            if (ex.Conflicts.Count != 0)
            {
                foreach (var conflict in ex.Conflicts)
                {
                    AddError(
                        $"Conflict detected between: {conflict.ConflictingCourseCode} on {conflict.ConflictDay} at {conflict.ConflictTime}");
                }
            }

            await SendErrorsAsync(StatusCodes.Status409Conflict, cancellationToken);
        }
        catch (RegistrationException ex)
        {
            _logger.LogWarning(ex, "Registration policy validation failed during registration for student: {studentID}",
                studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during course registration for student: {studentID}", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}