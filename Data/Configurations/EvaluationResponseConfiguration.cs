using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class EvaluationResponseConfiguration : IEntityTypeConfiguration<EvaluationResponse>
{
    public void Configure(EntityTypeBuilder<EvaluationResponse> builder)
    {
        builder.HasOne(er => er.Evaluation)
            .WithMany(le => le.Responses)
            .HasForeignKey(er => er.LecturerEvaluationID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(er => er.Question)
            .WithMany(eq => eq.Responses)
            .HasForeignKey(er => er.EvaluationQuestionID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}