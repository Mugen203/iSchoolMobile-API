using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedRegistrationPeriods
{
    // Declare a public static readonly Guid for RegistrationPeriodID
    public static Guid January2025RegistrationPeriodId;

    public static void Seed(ModelBuilder builder)
    {
        January2025RegistrationPeriodId = Guid.NewGuid();

        builder.Entity<RegistrationPeriod>().HasData(
            new RegistrationPeriod
            {
                RegistrationPeriodID = January2025RegistrationPeriodId,
                AcademicYear = "2024-2025",
                Semester = Semester.January.ToString(),
                StartDate = new DateTime(2025, 1, 21),
                EndDate = new DateTime(2025, 3, 1),
                IsActive = true,
                Description = "January 2025 Registration",
                AllowCourseAdd = true,
                AllowCourseDrop = true,
                LateRegistrationStart = new DateTime(2025, 3, 2),
                LateRegistrationEnd = new DateTime(2025, 3, 31),
                LateRegistrationFee = 50
            }
        );
    }
}