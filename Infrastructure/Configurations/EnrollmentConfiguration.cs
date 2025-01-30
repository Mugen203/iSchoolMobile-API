using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.EnrollmentDate)
            .IsRequired();
            
        builder.Property(e => e.Status)
            .IsRequired();
            
        builder.Property(e => e.EnrollmentNotes)
            .HasMaxLength(500);
            
        // One enrollment has one grade
        builder.HasOne(e => e.Grade)
            .WithOne(g => g.Enrollment)
            .HasForeignKey<Grade>(g => g.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}