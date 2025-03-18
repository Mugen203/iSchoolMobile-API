using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedCourseStudents
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<CourseStudent>().HasData(
            new CourseStudent
            {
                CourseID = SeedCourses.Cosc466CourseId,
                StudentID = "222CS01000694",
                RegistrationPeriodID = SeedRegistrationPeriods.January2025RegistrationPeriodId
            },
            new CourseStudent
            {
                CourseID = SeedCourses.Cosc440CourseId,
                StudentID = "222CS01000694",
                RegistrationPeriodID = SeedRegistrationPeriods.January2025RegistrationPeriodId
            },
            new CourseStudent
            {
                CourseID = SeedCourses.Cosc370CourseId,
                StudentID = "222CS01000694",
                RegistrationPeriodID = SeedRegistrationPeriods.January2025RegistrationPeriodId
            },
            new CourseStudent
            {
                CourseID = SeedCourses.Cosc445CourseId,
                StudentID = "222CS01000694",
                RegistrationPeriodID = SeedRegistrationPeriods.January2025RegistrationPeriodId
            }
        );
    }
}