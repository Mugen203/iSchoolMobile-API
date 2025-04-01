using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.GetPaymentHistory.Models;

namespace iSchool_Solution.Features.Finance.GetPaymentSummary;

[Authorize]
public class Endpoint : Endpoint<RecordPaymentRequest, RecordPaymentResponse>
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
        Post("/api/finance/record-payment");
        Roles("Admin"); 
        Summary(s => {
            s.Summary = "Records a manual payment made by a student.";
            s.Description = "Used by administrators to record payments made via cash, bank transfer, etc.";
            s.Responses[200] = "Payment recorded successfully.";
            s.Responses[400] = "Invalid request data.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden (User not Admin).";
            s.Responses[404] = "Student or Financial Record not found.";
            s.Responses[500] = "An unexpected error occurred.";
        });
         Tags("Finance");
    }

    public override async Task HandleAsync(RecordPaymentRequest req, CancellationToken ct)
    {
        _logger.LogInformation("Attempting to record payment by Admin User: {AdminUserID}, for Student: {StudentID}, Amount: {Amount}",
            User.FindFirstValue(ClaimTypes.NameIdentifier), req.StudentID, req.Amount);

        try
        {
            var response = await _financeService.RecordManualPaymentAsync(req);
            await SendOkAsync(response, ct);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Record payment failed: Student not found - {StudentID}", req.StudentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        }
        catch (KeyNotFoundException ex) // Catching generic KeyNotFound for FinancialRecord for now
        {
             _logger.LogWarning(ex, "Record payment failed: Financial record not found - {RecordID} for Student {StudentID}", req.FinancialRecordID, req.StudentID);
             AddError(ex.Message);
             await SendErrorsAsync(StatusCodes.Status404NotFound, ct);
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Unexpected error recording payment for StudentID: {StudentID}", req.StudentID);
             AddError("An unexpected error occurred while recording the payment.");
             await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}