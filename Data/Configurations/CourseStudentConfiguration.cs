using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.HasKey(cs => new { cs.CourseID, cs.StudentID });

        builder.HasOne(cs => cs.Course)
            .WithMany(c => c.CourseStudents)
            .HasForeignKey(cs => cs.CourseID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cs => cs.RegistrationPeriod)
            .WithMany(rp => rp.CourseEnrollments)
            .HasForeignKey(cs => cs.RegistrationPeriodID);

        builder.HasOne(cs => cs.Student)
            .WithMany(s => s.CourseStudents)
            .HasForeignKey(cs => cs.StudentID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}