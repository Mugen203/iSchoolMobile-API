using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Grade.GetCurrent.Models;

namespace iSchool_Solution.Features.Grade.GetCurrent;

[Authorize]
public class Endpoint : EndpointWithoutRequest<CurrentGradesResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly StudentService _studentService;

    public Endpoint(ILogger<Endpoint> logger, StudentService studentService)
    {
        _logger = logger;
        _studentService = studentService;
    }

    public override void Configure()
    {
        Get("api/grades/current");
        Roles("Student");
        Description(description => description
            .WithName("GetCurrentGrades")
            .WithSummary("Gets a student's current enrolled courses and grades")
            .WithTags("Grades")
            .Produces<CurrentGradesResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID (NameIdentifier) claim was not found in token."); 
            AddError("Student ID required but not found");
            await SendUnauthorizedAsync(cancellationToken); 
            return;
        }

        try
        {
            var currentGrades = await _studentService.GetCurrentGradesAsync(studentID);
            _logger.LogInformation("Retrieved current grades for student {StudentID} with {CourseCount} courses",
                studentID, currentGrades.CurrentCourses.Count);
            await SendOkAsync(currentGrades, cancellationToken);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student {StudentID} not found during current grades retrieval", studentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving current grades for student {StudentID}", studentID);
            AddError("An unexpected error occurred while retrieving current grades");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}