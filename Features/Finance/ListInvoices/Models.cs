using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Finance.ListInvoices;

public class Models
{
    public sealed class ListInvoicesRequest
    {
        // Optional pagination/filtering for student's invoice list
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public InvoiceStatus? Status { get; set; } // Optional filter by status
    }

    public sealed class ListInvoicesResponse
    {
        public List<InvoiceSummary> Invoices { get; set; } = [];
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }

    public sealed class InvoiceSummary // Represents one invoice in a list
    {
        public Guid InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; } // Add if using enum
        public string StatusDisplay { get; set; } = string.Empty; 
    }
}