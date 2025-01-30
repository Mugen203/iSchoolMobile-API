using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.CourseCode).IsUnique();
        
        builder.Property(c => c.CourseCode)
            .IsRequired()
            .HasMaxLength(20);
            
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(c => c.Description)
            .HasMaxLength(1000);
            
        builder.Property(c => c.LecturerName)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(c => c.Fee)
            .HasPrecision(10, 2);
            
        // Relationships
        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey(e => e.CourseId);
            
        builder.HasMany(c => c.Grades)
            .WithOne(g => g.Course)
            .HasForeignKey(g => g.CourseId);
    }
}