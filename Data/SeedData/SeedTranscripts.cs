using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedTranscripts
{
    public static Guid TranscriptForStudent222CS01000694Id;

    public static void Seed(ModelBuilder builder)
    {
        TranscriptForStudent222CS01000694Id = Guid.NewGuid();

        builder.Entity<Transcript>().HasData(
            new Transcript
            {
                TranscriptID = TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                GeneratedDate = new DateTimeOffset(new DateTime(2024, 10, 26)),
                //CummulativeGPA = 2.89, // Example Cummulative GPA - Calculated from provided grades
                //CreditsAttempted = 106, // Example Credits Attempted - Sum of credits from transcript
                //CreditsEarned = 93, // Example Credits Earned - Sum of earned credits from transcript
                isOfficial = false, // Assume it's an unofficial transcript
                AcademicStanding = AcademicStanding.SecondClassLower
            }
        );
    }
}