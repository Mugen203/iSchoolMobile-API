using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class InvoiceConfiguration: IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        // Precision for decimal properties
        builder.Property(i => i.Subtotal).HasPrecision(18, 2);
        builder.Property(i => i.DiscountAmount).HasPrecision(18, 2);
        builder.Property(i => i.TotalAmount).HasPrecision(18, 2);

        // Configure Relationship with Student
        builder.HasOne(i => i.Student)
            .WithMany() // Assuming Student doesn't have a direct ICollection<Invoice>
            .HasForeignKey(i => i.StudentID)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deleting student if invoices exist

        // Configure Optional Relationship with FinancialRecord
        builder.HasOne(i => i.FinancialRecord)
            .WithMany() // Assuming FinancialRecord doesn't have a direct ICollection<Invoice>
            .HasForeignKey(i => i.FinancialRecordID)
            .IsRequired(false) // Make the FK nullable
            .OnDelete(DeleteBehavior.SetNull); // Set FK to null if FinancialRecord is deleted

        // Configure Relationship with InvoiceLineItems
        builder.HasMany(i => i.LineItems)
            .WithOne(li => li.Invoice)
            .HasForeignKey(li => li.InvoiceID)
            .OnDelete(DeleteBehavior.Cascade); // Delete line items when invoice is deleted

        // Unique index for InvoiceNumber if needed
        builder.HasIndex(i => i.InvoiceNumber).IsUnique();
    }
}