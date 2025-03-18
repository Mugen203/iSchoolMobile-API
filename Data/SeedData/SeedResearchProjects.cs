using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedResearchProjects
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<ResearchProject>().HasData(
            new ResearchProject
            {
                Id = 1,
                Title = "AI in Healthcare",
                MainAuthorID = "222CS01000694",
                Abstract = "Research on AI applications in healthcare",
                Keywords = "AI, Healthcare",
                DateSubmitted = new DateTimeOffset(new DateTime(2024, 9, 1)),
                Status = ResearchStatus.UnderReview,
                Department = "Computer Science"
            }
        );
    }
}