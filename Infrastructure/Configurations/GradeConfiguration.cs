using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(g => g.Id);
        
        builder.Property(g => g.Midterm)
            .HasPrecision(5, 2);
            
        builder.Property(g => g.Final)
            .HasPrecision(5, 2);
            
        builder.Property(g => g.Assignments)
            .HasPrecision(5, 2);
            
        builder.Property(g => g.TotalScore)
            .HasPrecision(5, 2);
            
        builder.Property(g => g.LetterGrade)
            .IsRequired()
            .HasMaxLength(2);
            
        builder.Property(g => g.GradePoint)
            .HasPrecision(3, 2);
    }
}