using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Finance.GetFinancialSummary;

public class Models
{
    public sealed class FinancialSummaryRequest
    {
        // Currently no parameters needed to get the overall summary for the authenticated user.
        // Could add filters like AcademicYear later if needed.
    }
    
    public sealed class FinancialSummaryResponse
    {
        public decimal OverallOutstandingBalance { get; set; }
        public DateTimeOffset? NextDueDate { get; set; }
        public List<SemesterFinanceDetails> SemesterSummaries { get; set; } = [];
    }

    public class SemesterFinanceDetails
    {
        public Guid FinancialRecordID { get; set; }
        public string Semester { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public decimal TotalFeesForSemester { get; set; }
        public decimal AmountPaidForSemester { get; set; }
        public decimal OutstandingBalanceForSemester { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public List<FeeItemSummary> FeeItems { get; set; } = [];
        public List<PaymentSummary> Payments { get; set; } = [];
    }

    public sealed class FeeItemSummary
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public FeeItemCategory Category { get; set; }
        public PaymentStatus PaymentStatus { get; set; } // Status of this specific item
        public DateTimeOffset? DueDate { get; set; }
        public bool IsRequired { get; set; }
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