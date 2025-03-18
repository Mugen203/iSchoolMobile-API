using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class ResearchContributorConfiguration : IEntityTypeConfiguration<ResearchContributor>
{
    public void Configure(EntityTypeBuilder<ResearchContributor> builder)
    {
        // Research relationships - ResearchContributor
        builder.HasOne(rc => rc.Project)
            .WithMany(rp => rp.Contributors)
            .HasForeignKey(rc => rc.ResearchProjectID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rc => rc.Contributor)
            .WithMany()
            .HasForeignKey(rc => rc.ResearchContributorID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}