namespace iSchool_Solution.Entities.DTO.FinanceManagement;

public record PaymentSummary(
    Guid PaymentID,
    decimal Amount,
    DateTimeOffset PaymentDate,
    string PaymentMethod,
    string ReferenceNumber,
    string Status
);