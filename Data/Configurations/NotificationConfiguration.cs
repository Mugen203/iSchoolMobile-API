using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        // Notification relationships
        builder.HasOne(n => n.Student)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.StudentID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}