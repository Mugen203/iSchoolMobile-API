using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.GetPaymentSummary.Models;

namespace iSchool_Solution.Features.Finance.GetPaymentHistory;

[Authorize]
public class Endpoint : EndpointWithoutRequest<PaymentHistoryResponse>
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
        Get("/api/student/payments");
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Retrieves the payment history for the authenticated student.";
            s.Description = "Returns a list of all recorded payments for the student.";
            s.Responses[200] = "Payment history returned successfully.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden.";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(studentId))
        {
            _logger.LogWarning("User ID claim (NameIdentifier) not found in token for payment history request.");
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        _logger.LogInformation("Fetching payment history for StudentID: {StudentID}", studentId);

        try
        {
            var history = await _financeService.GetStudentPaymentHistoryAsync(studentId);
            _logger.LogInformation("Successfully fetched payment history for StudentID: {StudentID}", studentId);
            await SendOkAsync(history, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching payment history for StudentID: {StudentID}", studentId);
            await SendStringAsync("An error occurred while retrieving payment history.",
                StatusCodes.Status500InternalServerError, cancellation: cancellationToken);
        }
    }
}