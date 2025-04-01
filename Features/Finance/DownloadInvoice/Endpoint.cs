using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Data;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Features.Finance.DownloadInvoice;

[Authorize]
public class Endpoint : EndpointWithoutRequest // Request gets ID from route
{
    private readonly InvoiceService _invoiceService;
     private readonly ApplicationDbContext _context; // Or repo
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(InvoiceService invoiceService, ApplicationDbContext context, ILogger<Endpoint> logger)
    {
        _invoiceService = invoiceService;
         _context = context; // Or repo
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/student/invoices/{invoiceID:guid}/download");
        Roles("Student");
         Summary(s => {
             s.Summary = "Downloads the PDF for a specific invoice.";
             s.Description = "Returns the generated invoice PDF file.";
             s.Responses[200] = "Invoice PDF file.";
             s.Responses[401] = "Unauthorized.";
             s.Responses[403] = "Forbidden (Invoice does not belong to user).";
             s.Responses[404] = "Invoice not found or PDF not generated.";
             s.Responses[500] = "An unexpected error occurred during PDF generation or retrieval.";
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var invoiceId = Route<Guid>("invoiceID");
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(studentId))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Download requested for InvoiceID: {InvoiceID} by StudentID: {StudentID}", invoiceId, studentId);

        try
        {
             // Optional: Verify invoice ownership before generating PDF
             var invoiceOwner = await _context.Invoices
                .Where(i => i.InvoiceID == invoiceId)
                .Select(i => i.StudentID)
                .FirstOrDefaultAsync(ct);

             if (invoiceOwner == null) {
                 await SendNotFoundAsync(ct);
                 return;
             }
             if (invoiceOwner != studentId && !User.IsInRole("Admin")) {
                  _logger.LogWarning("Forbidden download attempt: Student {StudentID} tried to download Invoice {InvoiceID}", studentId, invoiceId);
                 await SendForbiddenAsync(ct);
                 return;
             }


            // Generate the PDF content
            byte[] pdfBytes = await _invoiceService.GenerateInvoicePdfAsync(invoiceId);

            // Determine filename
            var fileName = $"Invoice-{invoiceId}.pdf"; // Or use InvoiceNumber if available

             _logger.LogInformation("Sending PDF InvoiceID: {InvoiceID}, FileName: {FileName}, Size: {Size} bytes", invoiceId, fileName, pdfBytes.Length);

            // Send the file
            await SendBytesAsync(pdfBytes, fileName, "application/pdf", cancellation: ct);
        }
        catch (KeyNotFoundException ex)
        {
             _logger.LogWarning(ex, "Invoice not found for PDF download: {InvoiceID}", invoiceId);
             await SendNotFoundAsync(ct);
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Error generating or sending PDF for InvoiceID: {InvoiceID}", invoiceId);
             await SendErrorsAsync(500, ct);
        }
    }
}