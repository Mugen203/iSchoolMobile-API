using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Existing Faculty relationship (default is Cascade if FK is required, Restrict if optional)
        builder.HasOne(d => d.Faculty)
            .WithMany(f => f.Departments)
            .HasForeignKey(d => d.FacultyID)
            .OnDelete(DeleteBehavior.Restrict);

        // Prevent deleting a Department if it has associated Courses
        builder.HasMany(d => d.Courses)
            .WithOne(c => c.Department)
            .HasForeignKey(c => c.DepartmentID)
            .OnDelete(DeleteBehavior.Restrict); // Added explicit restrict

        // Prevent deleting a Department if it has associated Students
        builder.HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentID)
            .OnDelete(DeleteBehavior.Restrict); // Added explicit restrict
    }
}