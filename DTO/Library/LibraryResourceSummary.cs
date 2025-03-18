using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Library;

public record LibraryResourceSummary(
    int Id,
    string Title,
    string Author,
    string ISBN,
    string Category,
    string Publisher,
    ResourceType Type,
    bool IsDigital,
    int AvailableCopies,
    string AccessLink
);