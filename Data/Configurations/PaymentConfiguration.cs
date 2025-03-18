using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        // Configure decimal precision for Payment
        builder.Property(p => p.Amount)
            .HasPrecision(18, 2);

        // Payment relationships
        builder.HasOne(p => p.FinancialRecord)
            .WithMany(fr => fr.Payments)
            .HasForeignKey(p => p.FinancialRecordID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}