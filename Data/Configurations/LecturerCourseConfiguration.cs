using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class LecturerCourseConfiguration : IEntityTypeConfiguration<LecturerCourse>
{
    public void Configure(EntityTypeBuilder<LecturerCourse> builder)
    {
        builder.HasKey(lc => new { lc.LecturerID, lc.CourseID });

        builder.HasOne(lc => lc.Lecturer)
            .WithMany(l => l.LecturerCourses)
            .HasForeignKey(lc => lc.LecturerID);

        builder.HasOne(lc => lc.Course)
            .WithMany(c => c.LecturerCourses)
            .HasForeignKey(lc => lc.CourseID);
    }
}