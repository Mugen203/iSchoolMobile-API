using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class RegistrationPeriodConfiguration : IEntityTypeConfiguration<RegistrationPeriod>
{
    public void Configure(EntityTypeBuilder<RegistrationPeriod> builder)
    {
        // Configure decimal precision for RegistrationPeriod
        builder.Property(r => r.LateRegistrationFee)
            .HasPrecision(18, 2);
    }
}