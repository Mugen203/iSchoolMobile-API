using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Transcript.Get.Models;
using static iSchool_Solution.Features.Transcript.GetSemester.Models;

namespace iSchool_Solution.Services;

public class TranscriptService
{
    private readonly TranscriptRepository _transcriptRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<TranscriptService> _logger;

    public TranscriptService(
        TranscriptRepository transcriptRepository,
        ApplicationDbContext context,
        ILogger<TranscriptService> logger)
    {
        _transcriptRepository = transcriptRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Gets the complete transcript for a student
    /// </summary>
    public async Task<TranscriptSummaryResponse> GetStudentTranscriptAsync(string studentID)
    {
        // Fetch the transcript and related data in one go for efficiency
        var transcript = await _context.Transcripts
            .Include(t => t.SemesterRecords)
            .ThenInclude(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(t => t.StudentID == studentID);

        if (transcript == null) throw new TranscriptNotFoundException(studentID);

        await RecalculateTranscriptGPAAsync(transcript);
        await _context.SaveChangesAsync();

        // Get Transcript Details
        var transcriptDetails = await _transcriptRepository.GetStudentTranscriptAsync(studentID);

        // Update TranscriptSummaryResponse with calculated GPA values
        transcriptDetails.CummulativeGPA = transcript.CummulativeGPA;
        transcriptDetails.CreditsAttempted = transcript.CreditsAttempted;
        transcriptDetails.TotalCreditsEarned = transcript.CreditsEarned;
        transcriptDetails.Semesters = transcriptDetails.Semesters.Select(
            srDto =>
            {
                var semesterRecordEntity =
                    transcript.SemesterRecords.FirstOrDefault(srEntity =>
                        srEntity.SemesterRecordID == srDto.SemesterRecordID);
                if (semesterRecordEntity != null)
                {
                    srDto.SemesterGPA = semesterRecordEntity.SemesterGPA;
                    srDto.Credits = semesterRecordEntity.CreditsAttempted;
                }

                return srDto;
            }).ToList();

        return transcriptDetails;
    }

    /// <summary>
    /// Gets detailed information about a specific semester in a student's transcript
    /// </summary>
    public async Task<SemesterTranscriptResponse> GetSemesterTranscriptAsync(string studentID, Guid semesterRecordID)
    {
        // Get the specific semester record with related data
        var semesterRecord = await _context.SemesterRecords
            .Include(sr => sr.Transcript)
            .Include(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(sr => 
                sr.StudentID == studentID && 
                sr.SemesterRecordID == semesterRecordID);

        if (semesterRecord == null)
            throw new SemesterRecordNotFoundException(studentID, semesterRecordID);

        // Recalculate GPA to ensure it's up to date
        semesterRecord.CalculateSemesterGPA();
        await _context.SaveChangesAsync();

        // Map to response model
        var response = new SemesterTranscriptResponse
        {
            SemesterRecordID = semesterRecord.SemesterRecordID,
            SemesterName = semesterRecord.Semester.ToString(),
            AcademicYear = semesterRecord.AcademicYear,
            SemesterGPA = semesterRecord.SemesterGPA,
            SemesterCredits = semesterRecord.CreditsAttempted,
            SemesterStanding = DetermineSemesterStanding(semesterRecord.SemesterGPA),
            Courses = semesterRecord.Grades.Select(grade => new TranscriptCourseInfo
            {
                CourseCode = grade.Course.CourseCode,
                CourseName = grade.Course.CourseName,
                Credits = grade.Course.CourseCredits,
                Grade = grade.GradeLetter,
                GradePoints = grade.GradeLetter.GetGradePoints()
            }).ToList(),
            HasOfficialReport = semesterRecord.Transcript.isOfficial,
            SemesterReportId = null // Set this if you have semester-specific reports
        };

        return response;
    }

    /// <summary>
    /// Gets detailed information about a specific semester by academic year and semester
    /// </summary>
    public async Task<SemesterTranscriptResponse> GetSemesterTranscriptAsync(
        string studentID, string academicYear, Semester semester)
    {
        // Get the specific semester record with related data
        var semesterRecord = await _context.SemesterRecords
            .Include(sr => sr.Transcript)
            .Include(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(sr => 
                sr.StudentID == studentID && 
                sr.AcademicYear == academicYear && 
                sr.Semester == semester);

        if (semesterRecord == null)
            throw new SemesterRecordNotFoundException(studentID, semester, 
                int.Parse(academicYear.Split('-')[0]));

        // Now get transcript using the semester record ID
        return await GetSemesterTranscriptAsync(studentID, semesterRecord.SemesterRecordID);
    }

    /// <summary>
    /// Recalculates GPA for a transcript
    /// </summary>
    private async Task RecalculateTranscriptGPAAsync(Transcript transcript)
    {
        transcript.CalculateCummulativeGPA();
        foreach (var semesterRecord in transcript.SemesterRecords)
            semesterRecord.CalculateSemesterGPA();
    }

    /// <summary>
    /// Determines academic standing based on GPA
    /// </summary>
    private AcademicStanding DetermineSemesterStanding(double gpa)
    {
        return gpa switch
        {
            >= 3.75 => AcademicStanding.FirstClass,
            >= 3.25 => AcademicStanding.SecondClassUpper,
            >= 2.75 => AcademicStanding.SecondClassLower,
            >= 2.00 => AcademicStanding.ThirdClass,
            _ => AcademicStanding.Fail
        };
    }
}