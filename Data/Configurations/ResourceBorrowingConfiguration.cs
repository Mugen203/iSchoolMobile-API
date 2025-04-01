using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class ResourceBorrowingConfiguration : IEntityTypeConfiguration<ResourceBorrowing>
{
    public void Configure(EntityTypeBuilder<ResourceBorrowing> builder)
    {
        // Configure decimal precision for LateFee (existing)
        builder.Property(r => r.LateFee)
            .HasPrecision(18, 2);

        // Relationship to LibraryResource
        builder.HasOne(rb => rb.Resource)
            .WithMany(lr => lr.BorrowingRecords)
            .HasForeignKey(rb => rb.LibraryResourceID)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a resource if it's borrowed

        // Relationship to Student (ApiUser)
        builder.HasOne(rb => rb.Student)
            .WithMany() // ApiUser might not have a direct ICollection<ResourceBorrowing>
            .HasForeignKey(rb => rb.StudentId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a student if they have borrowed items (adjust if needed)
    }
}