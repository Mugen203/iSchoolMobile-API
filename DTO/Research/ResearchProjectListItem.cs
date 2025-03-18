using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Research;

public record ResearchProjectListItem(
    int Id,
    string Title,
    string MainAuthorName,
    DateTimeOffset DateSubmitted,
    ResearchStatus Status,
    string Department,
    List<ContributorSummary> Contributors
);