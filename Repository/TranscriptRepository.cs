using iSchool_Solution.Data;
using Microsoft.EntityFrameworkCore;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Repository;

public class TranscriptRepository
{
    private readonly ApplicationDbContext _context;

    public TranscriptRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TranscriptSummaryResponse> GetStudentTranscriptAsync(string studentID)
    {
        var transcripts = await _context.Transcripts
            .Where(t => t.StudentID == studentID)
            .Include(t => t.Student)
            .ThenInclude(s => s.Department) // Eager load Department through Student for RequiredCredits
            .Include(t => t.SemesterRecords)
            .ThenInclude(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync();

        if (transcripts == null) throw new KeyNotFoundException("Transcript not found.");

        // 1. Calculate RemainingRequiredCredits
        var remainingRequiredCredits = transcripts.Student.Department.RequiredCredits - transcripts.CreditsEarned;
        if (remainingRequiredCredits < 0) remainingRequiredCredits = 0;

        // 2. Calculate CurrentSemesterProjectedGPA
        var currentSemesterProjectedGPA = 0.0;
        var currentSemesterRecord = transcripts.SemesterRecords
            .OrderByDescending(sr => sr.StartDate) // Latest StartDate is current semester
            .FirstOrDefault();

        if (currentSemesterRecord != null)
        {
            var totalGradePoints = 0.0;
            var totalCredits = 0;

            foreach (var grade in currentSemesterRecord.Grades)
            {
                totalGradePoints += grade.GradePoints * grade.Course.CourseCredits; // Use CourseCredits from Course
                totalCredits += grade.Course.CourseCredits; // Use CourseCredits from Course
            }

            if (totalCredits > 0) currentSemesterProjectedGPA = totalGradePoints / totalCredits;
        }

        var transcriptSummaryResponse = new TranscriptSummaryResponse
        {
            TranscriptID = transcripts.TranscriptID,
            CummulativeGPA = transcripts.CummulativeGPA,
            CreditsAttempted = transcripts.CreditsAttempted,
            TotalCreditsEarned = transcripts.CreditsEarned,
            AcademicStanding = transcripts.AcademicStanding,
            RemainingRequiredCredits = remainingRequiredCredits,
            LastSemesterGPA =
                transcripts.SemesterRecords.LastOrDefault()?.SemesterGPA ?? 0,
            CanRequestOfficialTranscript = transcripts.isOfficial,
            Semesters = transcripts.SemesterRecords.Select(sr => new SemesterSummaryInfo
            {
                SemesterRecordID = sr.SemesterRecordID,
                Semester = sr.Semester.ToString(),
                StartDate = sr.StartDate,
                EndDate = sr.EndDate,
                SemesterGPA = sr.SemesterGPA,
                Credits = sr.CreditsAttempted,
                Grades = sr.Grades.Select(grade => new TranscriptCourseInfo
                {
                    CourseCode = grade.Course.CourseCode,
                    CourseName = grade.Course.CourseName,
                    Credits = grade.Course.CourseCredits, // Use CourseCredits from Course
                    Grade = grade.GradeLetter,
                    GradePoints = grade.GradePoints
                }).ToList()
            }).ToList()
        };

        return transcriptSummaryResponse;
    }
}