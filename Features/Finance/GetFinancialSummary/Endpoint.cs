using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.GetFinancialSummary.Models;

namespace iSchool_Solution.Features.Finance.GetFinancialSummary;

[Authorize]
public class Endpoint : EndpointWithoutRequest<FinancialSummaryResponse>
{
    private readonly FinanceService _financeService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(FinanceService financeService, ILogger<Endpoint> logger)
    {
        _financeService = financeService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/student/financial-summary");
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Retrieves the financial summary for the authenticated student.";
            s.Description =
                "Provides overall balance, next due date, and semester-by-semester breakdown of fees and payments.";
            s.Responses[200] = "Financial summary returned successfully.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden.";
            s.Responses[404] = "Student financial records not found.";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(studentId))
        {
            _logger.LogWarning("User ID claim (NameIdentifier) not found in token for financial summary request.");
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        _logger.LogInformation("Fetching financial summary for StudentID: {StudentID}", studentId);

        try
        {
            var summary = await _financeService.GetStudentFinancialSummaryAsync(studentId);
            _logger.LogInformation("Successfully fetched financial summary for StudentID: {StudentID}", studentId);
            await SendOkAsync(summary, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching financial summary for StudentID: {StudentID}", studentId);
            // Send 500 Internal Server Error for unexpected issues
            await SendStringAsync("An error occurred while retrieving financial information.",
                StatusCodes.Status500InternalServerError, cancellation: cancellationToken);
        }
    }
}