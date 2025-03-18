using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class ResearchProjectConfiguration : IEntityTypeConfiguration<ResearchProject>
{
    public void Configure(EntityTypeBuilder<ResearchProject> builder)
    {
        builder.HasOne(rp => rp.MainAuthor)
            .WithMany()
            .HasForeignKey(rp => rp.MainAuthorID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}