using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class InvoiceLineItemConfiguration: IEntityTypeConfiguration<InvoiceLineItem>
{
    public void Configure(EntityTypeBuilder<InvoiceLineItem> builder)
    {
        // Precision for decimal properties
        builder.Property(li => li.UnitPrice).HasPrecision(18, 2);
        builder.Property(li => li.LineTotal).HasPrecision(18, 2);

        // Relationship with Invoice (already configured via InvoiceConfiguration's HasMany)
        // builder.HasOne(li => li.Invoice)
        //     .WithMany(i => i.LineItems)
        //     .HasForeignKey(li => li.InvoiceID)
        //     .OnDelete(DeleteBehavior.Cascade); // This is implicitly handled

        // Configure Optional Relationship with FeeItem
        builder.HasOne(li => li.FeeItem)
            .WithMany() // Assuming FeeItem doesn't have direct ICollection<InvoiceLineItem>
            .HasForeignKey(li => li.FeeItemID)
            .IsRequired(false) // Make FK nullable
            .OnDelete(DeleteBehavior.SetNull); // Set FK to null if FeeItem is deleted
    }
}