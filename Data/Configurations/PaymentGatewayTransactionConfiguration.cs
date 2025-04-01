using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class PaymentGatewayTransactionConfiguration : IEntityTypeConfiguration<PaymentGatewayTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentGatewayTransaction> builder)
    {
        // Precision for decimal properties
        builder.Property(t => t.AmountProcessed).HasPrecision(18, 2);

        // Configure Relationship with Payment (One-to-One or One-to-Many?)
        // Assuming one Payment can have multiple Gateway Transactions (e.g., auth, capture)
        // If it's strictly One-to-One, the configuration differs slightly.
        builder.HasOne(t => t.Payment)
            .WithMany() // Payment doesn't have ICollection<PaymentGatewayTransaction>
            .HasForeignKey(t => t.PaymentID)
            .OnDelete(DeleteBehavior.Cascade); // Delete transaction details if payment is deleted

        // Add index on GatewayTransactionReference if frequently queried
        builder.HasIndex(t => new { t.GatewayName, t.GatewayTransactionReference }).IsUnique();
    }
}