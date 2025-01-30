using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        
        builder.HasIndex(p => p.ReferenceNumber)
            .IsUnique();
            
        builder.Property(p => p.Amount)
            .HasPrecision(10, 2)
            .IsRequired();
            
        builder.Property(p => p.ReferenceNumber)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.Property(p => p.TransactionId)
            .HasMaxLength(100);
            
        builder.Property(p => p.Description)
            .HasMaxLength(500);
    }
}