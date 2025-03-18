using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Research;

public record ResearchProjectDetails(
    int Id,
    string Title,
    string Abstract,
    string Keywords,
    DateTimeOffset DateSubmitted,
    ResearchStatus Status,
    string Department,
    string MainAuthorName,
    List<ResearchProjectContributorDetails> Contributors,
    List<ResearchProjectDocumentDetails> Documents 
);