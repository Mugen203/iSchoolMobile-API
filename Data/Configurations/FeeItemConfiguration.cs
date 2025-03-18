using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class FeeItemConfiguration : IEntityTypeConfiguration<FeeItem>
{
    public void Configure(EntityTypeBuilder<FeeItem> builder)
    {
        builder.Property(f => f.Amount)
            .HasPrecision(18, 2);

        builder.HasOne(fi => fi.FinancialRecord)
            .WithMany(fr => fr.FeeItems)
            .HasForeignKey(fi => fi.FinancialRecordID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}