using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Repository;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.GetInvoiceDetails.Models;

namespace iSchool_Solution.Features.Finance.GetInvoiceDetails;

[Authorize]
public class Endpoint : Endpoint<EmptyRequest, InvoiceDetailsResponse> // Request gets ID from route
{
    private readonly FinanceRepository _financeRepository;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(FinanceRepository financeRepository, ILogger<Endpoint> logger)
    {
        _financeRepository = financeRepository;
        _logger = logger;
    }


    public override void Configure()
    {
        Get("/api/student/invoices/{invoiceID:guid}");
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Gets the details of a specific invoice.";
            s.Description =
                "Returns detailed information including line items for a specific invoice belonging to the student.";
            s.Responses[200] = "Invoice details returned successfully.";
            s.Responses[401] = "Unauthorized.";
            s.Responses[403] = "Forbidden (Invoice does not belong to user).";
            s.Responses[404] = "Invoice not found.";
            s.Responses[500] = "An unexpected error occurred.";
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(EmptyRequest _, CancellationToken ct)
    {
        var invoiceID = Route<Guid>("invoiceID");
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(studentId))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Fetching details for InvoiceID: {InvoiceID} by StudentID: {StudentID}", invoiceID,
            studentId);

        try
        {
            var invoice = await _financeRepository.GetInvoiceByIdAsync(invoiceID);

            if (invoice == null)
            {
                _logger.LogWarning("Invoice not found: {InvoiceID}", invoiceID);
                await SendNotFoundAsync(ct); // Send 404 Not Found
                return;
            }

            // Authorization check: Does this invoice belong to the logged-in student?
            if (invoice.StudentID != studentId && !User.IsInRole("Admin"))
            {
                _logger.LogWarning("Forbidden attempt: Student {StudentID} tried to access Invoice {InvoiceID}",
                    studentId, invoiceID);
                await SendForbiddenAsync(ct); // Send 403 Forbidden
                return;
            }

            // Map the fetched entity (including Student and LineItems) to the response DTO
            var response = new InvoiceDetailsResponse
            {
                InvoiceID = invoice.InvoiceID,
                InvoiceNumber = invoice.InvoiceNumber,
                StudentID = invoice.StudentID,
                StudentName = $"{invoice.Student.FirstName} {invoice.Student.LastName}",
                FinancialRecordID = invoice.FinancialRecordID,
                CreatedDate = invoice.CreatedDate,
                DueDate = invoice.DueDate,
                Subtotal = invoice.Subtotal,
                DiscountAmount = invoice.DiscountAmount,
                TotalAmount = invoice.TotalAmount,
                StatusDisplay = invoice.Status.ToString(),
                Notes = invoice.Notes,
                LineItems = invoice.LineItems.Select(li => new InvoiceLineItemDetails
                {
                    // Null check for line items
                    InvoiceLineItemID = li.InvoiceLineItemID,
                    Description = li.Description,
                    Quantity = li.Quantity,
                    UnitPrice = li.UnitPrice,
                    LineTotal = li.LineTotal,
                    FeeItemID = li.FeeItemID
                }).ToList() // Default to empty list if null
            };

            await SendOkAsync(response, ct); // Send 200 OK
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching details for InvoiceID: {InvoiceID}", invoiceID);
            // Send 500 Internal Server Error for unexpected issues
            await SendStringAsync("An error occurred while retrieving invoice details.",
                StatusCodes.Status500InternalServerError, cancellation: ct);
        }
    }
}