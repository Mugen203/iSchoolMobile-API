using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasOne(d => d.Department)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.DepartmentID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.CourseTimeSlots) // Course has many CourseTimeSlots
            .WithOne(cts => cts.Course) // Each CourseTimeSlot belongs to one Course
            .HasForeignKey(cts => cts.CourseID) // Foreign key in CourseTimeSlot is CourseID
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.LecturerCourses) // Course has many LecturerCourses
            .WithOne(lc => lc.Course) // Each LecturerCourse belongs to one Course
            .HasForeignKey(lc => lc.CourseID) // Foreign key in LecturerCourse is CourseID
            .OnDelete(DeleteBehavior.Cascade);
    }
}