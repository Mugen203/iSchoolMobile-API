using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Grade.GetSemester.Models;

namespace iSchool_Solution.Features.Grade.GetSemester;

[Authorize]
public class Endpoint : Endpoint<SemesterGradesRequest, List<SemesterGradesResponse>>
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
        Get("api/grades/{year}/{semester}");
        Roles("Student");
        Description(description => description
            .WithName("GetSemesterGrades")
            .WithSummary("Gets a student's grades for a specific semester")
            .WithTags("Grades")
            .Produces<List<SemesterGradesResponse>>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(SemesterGradesRequest request, CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue("StudentID");
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID was not found in token claims during semester grades retrieval");
            AddError("Student ID is required but not found");
            await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
            return;
        }

        // Update request with StudentID from token
        request.StudentID = studentID;

        try
        {
            var semesterGrades = await _studentService.GetSemesterGradesAsync(
                studentID,
                request.Semester,
                request.AcademicYear);

            _logger.LogInformation("Retrieved semester grades for student {StudentID}, semester {Semester}, year {Year}",
                studentID, request.Semester, request.AcademicYear);

            await SendOkAsync(semesterGrades, cancellationToken);
        }
        catch (SemesterRecordNotFoundException ex)
        {
            _logger.LogWarning(ex, "Semester record not found for student {StudentID}, semester {Semester}, year {Year}",
                studentID, request.Semester, request.AcademicYear);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving semester grades for student {StudentID}", studentID);
            AddError("An unexpected error occurred while retrieving semester grades");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}