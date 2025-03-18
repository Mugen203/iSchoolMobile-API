using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedSemesterRecords
{
    // Declare public static readonly Guids for SemesterRecordIDs
    public static Guid SemesterRecord_FirstSem2021_2022_Id;
    public static Guid SemesterRecord_SecondSem2021_2022_Id;
    public static Guid SemesterRecord_FirstSem2022_2023_Id;
    public static Guid SemesterRecord_SecondSem2022_2023_Id;
    public static Guid SemesterRecord_FirstSem2023_2024_Id;
    public static Guid SemesterRecord_SecondSem2023_2024_Id;


    public static void Seed(ModelBuilder builder)
    {
        // Assign Guid.NewGuid() to SemesterRecordIDs
        SemesterRecord_FirstSem2021_2022_Id = Guid.NewGuid();
        SemesterRecord_SecondSem2021_2022_Id = Guid.NewGuid();
        SemesterRecord_FirstSem2022_2023_Id = Guid.NewGuid();
        SemesterRecord_SecondSem2022_2023_Id = Guid.NewGuid();
        SemesterRecord_FirstSem2023_2024_Id = Guid.NewGuid();
        SemesterRecord_SecondSem2023_2024_Id = Guid.NewGuid();


        builder.Entity<SemesterRecord>().HasData(
            // Semester Record for First Sem 2021/2022
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_FirstSem2021_2022_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2021/2022",
                Semester = Semester.September,
                StartDate = new DateTimeOffset(new DateTime(2021, 9, 1)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2021, 12, 15)) // Example End Date
                //SemesterGPA = 2.66, // Calculated GPA - Example
                //CreditsAttempted = 19, // Pre-calculated from transcript
                //CreditsEarned = 16 // Pre-calculated from transcript
            },
            // Semester Record for Second Sem 2021/2022
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_SecondSem2021_2022_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2021/2022",
                Semester = Semester.January,
                StartDate = new DateTimeOffset(new DateTime(2022, 1, 15)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2022, 5, 30)) // Example End Date
                //SemesterGPA = 1.94, // Calculated GPA - Example
                //CreditsAttempted = 16, // Pre-calculated from transcript
                //CreditsEarned = 13 // Pre-calculated from transcript
            },
            // Semester Record for First Sem 2022/2023
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_FirstSem2022_2023_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2022/2023",
                Semester = Semester.September,
                StartDate = new DateTimeOffset(new DateTime(2022, 9, 1)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2022, 12, 15)) // Example End Date
                //SemesterGPA = 3.00, // Calculated GPA - Example
                //CreditsAttempted = 16, // Pre-calculated from transcript
                //CreditsEarned = 13 // Pre-calculated from transcript - Corrected
            },
            // Semester Record for Second Sem 2022/2023
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_SecondSem2022_2023_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2022/2023",
                Semester = Semester.January,
                StartDate = new DateTimeOffset(new DateTime(2023, 1, 15)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2023, 5, 30)) // Example End Date
                //SemesterGPA = 3.11, // Calculated GPA - Example
                //CreditsAttempted = 16, // Pre-calculated from transcript
                //CreditsEarned = 16 // Pre-calculated from transcript
            },
            // Semester Record for First Sem 2023/2024
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_FirstSem2023_2024_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2023/2024",
                Semester = Semester.September,
                StartDate = new DateTimeOffset(new DateTime(2023, 9, 1)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2023, 12, 15)) // Example End Date
                //SemesterGPA = 3.50, // Calculated GPA - Example
                //CreditsAttempted = 18, // Pre-calculated from transcript
                //CreditsEarned = 18 // Pre-calculated from transcript - Corrected
            },
            // Semester Record for Second Sem 2023/2024
            new SemesterRecord
            {
                SemesterRecordID = SemesterRecord_SecondSem2023_2024_Id,
                TranscriptID = SeedTranscripts.TranscriptForStudent222CS01000694Id,
                StudentID = "222CS01000694",
                AcademicYear = "2023/2024",
                Semester = Semester.January,
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 15)), // Example Start Date
                EndDate = new DateTimeOffset(new DateTime(2024, 5, 30)) // Example End Date
                //SemesterGPA = 3.14, // Calculated GPA - Example
                //CreditsAttempted = 21, // Pre-calculated from transcript
                //CreditsEarned = 21 // Pre-calculated from transcript - Corrected
            }
        );
    }
}