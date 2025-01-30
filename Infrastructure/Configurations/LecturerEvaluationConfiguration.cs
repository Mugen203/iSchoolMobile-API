using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LecturerEvaluationConfiguration : IEntityTypeConfiguration<LecturerEvaluation>
{
    public void Configure(EntityTypeBuilder<LecturerEvaluation> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Comments)
            .HasMaxLength(1000);
            
        builder.Property(e => e.Semester)
            .IsRequired()
            .HasMaxLength(20);
    }
}