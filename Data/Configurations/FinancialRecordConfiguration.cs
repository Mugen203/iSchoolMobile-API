using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class FinancialRecordConfiguration : IEntityTypeConfiguration<FinancialRecord>
{
    public void Configure(EntityTypeBuilder<FinancialRecord> builder)
    {
        // Configure decimal precision for financial properties
        builder.Property(f => f.AmountPaid)
            .HasPrecision(18, 2);

        builder.Property(f => f.OutstandingBalance)
            .HasPrecision(18, 2);

        builder.Property(f => f.TotalFees)
            .HasPrecision(18, 2);

        // Financial records relationships
        builder.HasOne(fr => fr.Student)
            .WithMany(s => s.FinancialRecords)
            .HasForeignKey(fr => fr.StudentID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}