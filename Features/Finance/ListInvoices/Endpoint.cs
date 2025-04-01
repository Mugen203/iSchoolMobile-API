using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Repository;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;

namespace iSchool_Solution.Features.Finance.ListInvoices;

[Authorize]
public class Endpoint : Endpoint<Models.ListInvoicesRequest, Models.ListInvoicesResponse>
{
    private readonly InvoiceService _invoiceService; 
    private readonly FinanceRepository _financeRepository;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(InvoiceService invoiceService, FinanceRepository financeRepository, ILogger<Endpoint> logger)
    {
        _invoiceService = invoiceService;
         _financeRepository = financeRepository;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/student/invoices");
        Roles("Student");
        Summary(s => {
             s.Summary = "Lists invoices for the authenticated student.";
             s.Description = "Returns a paginated list of the student's invoices.";
             s.Responses[200] = "Invoices listed successfully.";
             s.Responses[401] = "Unauthorized.";
             s.Responses[403] = "Forbidden.";
             s.Responses[500] = "An unexpected error occurred.";
        });
         Tags("Finance");
    }

    public override async Task HandleAsync(Models.ListInvoicesRequest req, CancellationToken ct)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentId))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Fetching invoice list for StudentID: {StudentID}, Page: {Page}, PageSize: {PageSize}", studentId, req.Page, req.PageSize);

        try
        {
            // Implement pagination and fetching logic, likely in FinanceRepository or InvoiceService
            var invoices = await _financeRepository.GetInvoicesByStudentIdAsync(studentId); // Basic fetch, add pagination later

            var totalCount = invoices.Count; // Get total count before pagination for accurate TotalPages
            var totalPages = (int)Math.Ceiling(totalCount / (double)req.PageSize);

            var pagedInvoices = invoices
                                .Skip((req.Page - 1) * req.PageSize)
                                .Take(req.PageSize)
                                .ToList();

            var response = new Models.ListInvoicesResponse
            {
                Invoices = pagedInvoices.Select(inv => new Models.InvoiceSummary {
                    InvoiceID = inv.InvoiceID,
                    InvoiceNumber = inv.InvoiceNumber,
                    CreatedDate = inv.CreatedDate,
                    DueDate = inv.DueDate,
                    TotalAmount = inv.TotalAmount,
                    StatusDisplay = "Paid", 
                    Status = inv.Status 
                }).ToList(),
                TotalCount = totalCount,
                CurrentPage = req.Page,
                TotalPages = totalPages
            };

            await SendOkAsync(response, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching invoices for StudentID: {StudentID}", studentId);
            await SendErrorsAsync(500, ct);
        }
    }
}