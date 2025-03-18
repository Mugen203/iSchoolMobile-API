namespace iSchool_Solution.Entities.DTO.FinanceManagement;

public record FinancialSummary(
    Guid FinancialRecordID,
    string Semester,
    decimal TotalFees,
    decimal AmountPaid,
    decimal OutstandingBalance,
    DateTimeOffset LastUpdated,
    List<FeeItemSummary> FeeItems,
    List<PaymentSummary> RecentPayments
);