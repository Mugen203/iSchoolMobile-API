using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedEvaluationPeriods
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<EvaluationPeriod>().HasData(
            new EvaluationPeriod
            {
                Id = 1,
                AcademicYear = "2024-2025",
                Semester = Semester.September,
                StartDate = new DateTimeOffset(new DateTime(2024, 9, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 10, 31)), IsActive = false,
                Description = "September 2024 Evaluation"
            },
            new EvaluationPeriod
            {
                Id = 2,
                AcademicYear = "2024-2025",
                Semester = Semester.January,
                StartDate = new DateTimeOffset(new DateTime(2025, 1, 21)),
                EndDate = new DateTimeOffset(new DateTime(2024, 2, 28)), IsActive = true,
                Description = "January 2025 Evaluation"
            }
        );
    }
}