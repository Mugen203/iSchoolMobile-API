using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedResearchContributors
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<ResearchContributor>().HasData(
            new ResearchContributor
            {
                Id = 1,
                ResearchProjectID = 1,
                ResearchContributorID = "222CS01000694",
                Role = "Co-author",
                ContributionDetails = "Assisted with data analysis"
            }
        );
    }
}