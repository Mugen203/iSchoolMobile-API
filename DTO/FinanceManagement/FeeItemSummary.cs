namespace iSchool_Solution.Entities.DTO.FinanceManagement;

public record FeeItemSummary(
    int Id,
    string Description,
    decimal Amount,
    string Category,
    bool IsRequired
);