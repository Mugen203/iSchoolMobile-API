namespace iSchool_Solution.Features.Finance.GetInvoiceDetails;

public class Models
{
    // Request uses route parameter {invoiceId}, no specific request body model needed

    public sealed class InvoiceDetailsResponse // Represents the full Invoice data
    {
        public Guid InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public Guid? FinancialRecordID { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        // public InvoiceStatus Status { get; set; }
        public string StatusDisplay { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public List<InvoiceLineItemDetails> LineItems { get; set; } = [];
    }

    public sealed class InvoiceLineItemDetails
    {
        public int InvoiceLineItemID { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int? FeeItemID { get; set; } // Original FeeItem ID if linked
    }
}