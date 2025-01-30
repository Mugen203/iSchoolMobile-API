using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LibraryAccessConfiguration : IEntityTypeConfiguration<LibraryAccess>
{
    public void Configure(EntityTypeBuilder<LibraryAccess> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder.Property(l => l.ResourceId)
            .IsRequired()
            .HasMaxLength(50);
            
        builder.Property(l => l.ResourceTitle)
            .IsRequired()
            .HasMaxLength(200);
    }
}