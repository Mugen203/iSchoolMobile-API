using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Finance.GetPaymentHistory;

public class Models
{
    public sealed class RecordPaymentRequest
    {
        // Required fields for recording a payment manually (likely by an Admin)
        public string StudentID { get; set; } = string.Empty;
        public Guid FinancialRecordID { get; set; } // ID of the semester record payment applies to
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty; // e.g., Cheque number, transaction ID
        public DateTimeOffset PaymentDate { get; set; }
        public string? Notes { get; set; } // Optional notes about the payment
    }

    public sealed class RecordPaymentResponse
    {
        public Guid PaymentID { get; set; }
        public Guid FinancialRecordID { get; set; }
        public decimal UpdatedOutstandingBalance { get; set; } // Return the new balance for confirmation
        public string Message { get; set; } = string.Empty;
    }
    
    public sealed class PaymentSummary
    {
        public Guid PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public PaymentStatus Status { get; set; } // Status of the payment transaction itself
    }
}