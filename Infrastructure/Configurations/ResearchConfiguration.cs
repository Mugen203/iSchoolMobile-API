using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ResearchConfiguration : IEntityTypeConfiguration<Research>
{
    public void Configure(EntityTypeBuilder<Research> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(r => r.Abstract)
            .IsRequired()
            .HasMaxLength(2000);
            
        builder.Property(r => r.DocumentUrl)
            .HasMaxLength(500);
            
        builder.Property(r => r.SupervisorName)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(r => r.Keywords)
            .HasMaxLength(500);
    }
}