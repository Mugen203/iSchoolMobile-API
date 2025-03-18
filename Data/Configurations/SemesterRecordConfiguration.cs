using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class SemesterRecordConfiguration : IEntityTypeConfiguration<SemesterRecord>
{
    public void Configure(EntityTypeBuilder<SemesterRecord> builder)
    {
        // Keep cascade delete for Transcript relationship
        builder.HasOne(sr => sr.Transcript)
            .WithMany(t => t.SemesterRecords)
            .HasForeignKey(sr => sr.TranscriptID)
            .OnDelete(DeleteBehavior.Cascade);

        // Change Student relationship to Restrict (prevents multiple cascade paths)
        builder.HasOne(sr => sr.Student)
            .WithMany()
            .HasForeignKey(sr => sr.StudentID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}