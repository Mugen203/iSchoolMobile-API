namespace iSchool_Solution.Features.Finance.GetInvoice;

public class Models
{
    public sealed class GenerateInvoiceRequest
    {
        public Guid FinancialRecordID { get; set; } // ID of the semester record to generate invoice from
        // Optional: Could add StudentID for verification or specific line items if not tied to FinRecord
    }

    // Response could be the full InvoiceDetails or a simpler confirmation
    public sealed class GenerateInvoiceResponse
    {
        public Guid InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}