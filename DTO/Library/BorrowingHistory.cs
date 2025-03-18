using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Library;

public record BorrowingHistory(
    int Id,
    LibraryResourceSummary Resource,
    DateTime BorrowDate,
    DateTime DueDate,
    DateTime? ReturnDate,
    BorrowStatus Status,
    decimal? LateFee
);