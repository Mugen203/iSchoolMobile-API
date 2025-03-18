namespace iSchool_Solution.Entities.DTO.Research;

public record ResearchProjectContributorDetails(
    int Id,
    string ResearchContributorID,
    string ContributorName,
    string Role,
    string ContributionDetails
);