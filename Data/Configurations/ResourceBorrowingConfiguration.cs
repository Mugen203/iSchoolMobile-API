using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class ResourceBorrowingConfiguration : IEntityTypeConfiguration<ResourceBorrowing>
{
    public void Configure(EntityTypeBuilder<ResourceBorrowing> builder)
    {
        builder.Property(r => r.LateFee)
            .HasPrecision(18, 2);
    }
}