using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedResourceBorrowings
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<ResourceBorrowing>().HasData(
            new ResourceBorrowing
            {
                Id = 1,
                LibraryResourceID = 1,
                StudentId = "222CS01000694",
                BorrowDate = new DateTime(2024, 9, 1),
                DueDate = new DateTime(2024, 9, 15), Status = BorrowStatus.Borrowed
            }
        );
    }
}