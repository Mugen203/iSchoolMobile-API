using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class TranscriptConfiguration : IEntityTypeConfiguration<Transcript>
{
    public void Configure(EntityTypeBuilder<Transcript> builder)
    {
        // Transcript relationships
        builder.HasOne(t => t.Student)
            .WithMany(s => s.Transcripts)
            .HasForeignKey(t => t.StudentID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}