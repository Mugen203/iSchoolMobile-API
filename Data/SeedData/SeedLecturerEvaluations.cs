using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedLecturerEvaluations
{
    public static void Seed(ModelBuilder builder, Guid courseID)
    {
        builder.Entity<LecturerEvaluation>().HasData(
            new LecturerEvaluation
            {
                Id = 1,
                EvaluationPeriodID = 1,
                CourseID = courseID,
                LecturerID = SeedLecturers.LecturerL001Id,
                SubmissionDate = new DateTimeOffset(new DateTime(2024, 9, 15)),
                Comments = "Great course!"
            }
        );
    }
}