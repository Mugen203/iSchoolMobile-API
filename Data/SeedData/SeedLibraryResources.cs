using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedLibraryResources
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<LibraryResource>().HasData(
            new LibraryResource
            {
                Id = 1,
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                ISBN = "9780262033848",
                Category = "Computer Science",
                Publisher = "MIT Press",
                YearPublished = 2009,
                Edition = "3rd",
                Description = "Comprehensive guide to algorithms",
                Location = "Library Section A",
                ResourceType = ResourceType.Book,
                DigitalAccessLink = string.Empty,
                IsDigital = false,
                TotalCopies = 10,
                AvailableCopies = 8
            }
        );
    }
}