using System.Security.Claims;
using FastEndpoints;
using FluentValidation;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Evaluation.Submit.Models;

namespace iSchool_Solution.Features.Evaluation.Submit;

[Authorize]
public class Endpoint : Endpoint<SubmitEvaluationRequest, SubmitEvaluationResponse>
{
    private readonly StudentService _studentService; // Change to EvaluationService if created
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(StudentService studentService, ILogger<Endpoint> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/student/evaluations/submit");
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Submits a lecturer/course evaluation by a student.";
            s.Description = "Allows students to submit feedback during an active evaluation period.";
            s.Responses[200] = "Evaluation submitted successfully."; // Or 201 Created
            s.Responses[400] = "Invalid request data (validation errors or business logic violation).";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden (e.g., period inactive, already submitted).";
            s.Responses[404] = "Not Found (e.g., Course, Lecturer, Period, Question ID invalid).";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Evaluation", "Student");
    }

    public override async Task HandleAsync(SubmitEvaluationRequest req, CancellationToken ct)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentId))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Evaluation submission request received from StudentID: {StudentID} for CourseID: {CourseID}, LecturerID: {LecturerID}",
            studentId, req.CourseID, req.LecturerID);

        try
        {
            var response = await _studentService.SubmitEvaluationAsync(studentId, req);
            await SendOkAsync(response, ct); // Or SendCreatedAtAsync if you have a GetEvaluation endpoint
        }
        catch (ValidationException vex) // Catch FluentValidation errors explicitly
        {
            _logger.LogWarning("Validation failed during evaluation submission for StudentID: {StudentID}. Errors: {Errors}", studentId, vex.Errors);
             AddError(vex.Message); // Add validation errors to response
             await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
        }
        catch (InvalidOperationException ioex) // Catch business logic errors (period inactive, not enrolled, already submitted)
        {
            _logger.LogWarning("Business rule violation during evaluation submission for StudentID: {StudentID}. Message: {Message}", studentId, ioex.Message);
            AddError(ioex.Message);
            await SendErrorsAsync(StatusCodes.Status400BadRequest, ct); // Send 400 for these
        }
        catch (KeyNotFoundException knfex) // Catch invalid IDs
        {
            _logger.LogWarning("Record not found during evaluation submission for StudentID: {StudentID}. Message: {Message}", studentId, knfex.Message);
            AddError(knfex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error during evaluation submission for StudentID: {StudentID}", studentId);
            AddError("An unexpected error occurred while submitting the evaluation.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}