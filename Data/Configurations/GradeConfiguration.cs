using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        // Grade relationships
        builder.HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.Course)
            .WithMany(c => c.Grades)
            .HasForeignKey(g => g.CourseID)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(g => g.SemesterRecord)
            .WithMany(sr => sr.Grades)
            .HasForeignKey(g => g.SemesterRecordID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}