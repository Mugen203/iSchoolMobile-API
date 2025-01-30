using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(a => a.Content)
            .IsRequired()
            .HasMaxLength(4000);
            
        // builder.Property(a => a.TargetPrograms)
        //     .HasMaxLength(500);
        //     
        // builder.Property(a => a.TargetSemesters)
        //     .HasMaxLength(100);
            
        builder.Property(a => a.AttachmentUrl)
            .HasMaxLength(500);
    }
}