using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class LecturerEvaluationConfiguration : IEntityTypeConfiguration<LecturerEvaluation>
{
    public void Configure(EntityTypeBuilder<LecturerEvaluation> builder)
    {
        // Evaluation relationships - LecturerEvaluation
        builder.HasOne(le => le.EvaluationPeriod)
            .WithMany(ep => ep.Evaluations)
            .HasForeignKey(le => le.EvaluationPeriodID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(le => le.Course)
            .WithMany()
            .HasForeignKey(le => le.CourseID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(le => le.Lecturer)
            .WithMany(l => l.Evaluations)
            .HasForeignKey(le => le.LecturerID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}