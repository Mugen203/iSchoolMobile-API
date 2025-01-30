using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Primary keys and indexes
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.Email).IsUnique();
        builder.HasIndex(s => s.StudentId).IsUnique();
        
        // Required fields with constraints
        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(s => s.PasswordHash)
            .IsRequired();
        
        builder.Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(s => s.StudentId)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.Property(s => s.Program)
            .IsRequired()
            .HasMaxLength(100);
        
        // Relationships
        builder.HasMany(s => s.Enrollments)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(s => s.Grades)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(s => s.Payments)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}