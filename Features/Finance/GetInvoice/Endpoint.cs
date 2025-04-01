using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.GetInvoice.Models;

namespace iSchool_Solution.Features.Finance.GetInvoice;

[Authorize]
public class Endpoint : Endpoint<GenerateInvoiceRequest, GenerateInvoiceResponse>
{
    private readonly InvoiceService _invoiceService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(InvoiceService invoiceService, ILogger<Endpoint> logger)
    {
        _invoiceService = invoiceService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/admin/invoices/generate");
        Roles("Admin");
        Summary(s =>
        {
            s.Summary = "Generate an invoice from a financial record.";
            s.Description =
                "Creates an official invoice based on an existing financial record ID. Restricted to Admins.";
            s.Responses[201] = "Invoice generated successfully."; // Use 201 Created
            s.Responses[400] = "Invalid request data.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden.";
            s.Responses[404] = "Financial record not found.";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Finance", "Admin");
    }

    public override async Task HandleAsync(GenerateInvoiceRequest req, CancellationToken ct)
    {
        _logger.LogInformation("Admin {AdminUserId} generating invoice for FinancialRecordID: {FinancialRecordID}",
            User.FindFirstValue(ClaimTypes.NameIdentifier), req.FinancialRecordID);
        try
        {
            var invoice = await _invoiceService.CreateInvoiceFromFinancialRecordAsync(req.FinancialRecordID);
            var response = new GenerateInvoiceResponse
            {
                InvoiceID = invoice.InvoiceID,
                InvoiceNumber = invoice.InvoiceNumber,
                Message = "Invoice generated successfully."
            };
            await SendCreatedAtAsync<GetInvoiceDetails.Endpoint>(new { invoiceId = invoice.InvoiceID }, response,
                cancellation: ct); // Send 201 Created
        }
        catch (KeyNotFoundException ex) // Catch specific "not found"
        {
            _logger.LogWarning(ex, "Failed to generate invoice: FinancialRecordID {FinancialRecordID} not found.",
                req.FinancialRecordID);
            await SendNotFoundAsync(ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating invoice for FinancialRecordID: {FinancialRecordID}",
                req.FinancialRecordID);
            await SendErrorsAsync(500, ct);
        }
    }
}