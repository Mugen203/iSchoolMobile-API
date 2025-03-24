using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Transcript.Download.Models;
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

    /// <summary>
    /// Generates a downloadable transcript file for a student
    /// </summary>
    public async Task<DownloadTranscriptResponse> GenerateDownloadableTranscriptAsync(
        string studentID, bool isOfficial, TranscriptFormat format, Guid? semesterID = null, string? purpose = null)
    {
        // 1. Verify the student exists and can download transcripts
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.StudentID == studentID);

        if (student == null)
            throw new StudentNotFoundException(studentID);

        // 2. Get transcript data - handle the different types separately
        object transcriptData;
        if (semesterID.HasValue)
            transcriptData = await GetSemesterTranscriptAsync(studentID, semesterID.Value);
        else
            transcriptData = await GetStudentTranscriptAsync(studentID);

        // 3. Check if student can get official transcript if requested
        if (isOfficial)
        {
            var transcript = await _context.Transcripts
                .FirstOrDefaultAsync(t => t.StudentID == studentID);

            if (transcript == null)
                throw new TranscriptNotFoundException(studentID);

            if (!transcript.isOfficial)
                throw new TranscriptRequestException("Official transcript not available for this student due to holds or restrictions");

            // Log official transcript request for audit
            await LogTranscriptRequestAsync(studentID, isOfficial, purpose);
        }

        // 4. Generate the actual file
        var fileData = await GenerateTranscriptFileAsync(transcriptData, format, isOfficial);

        // Get file extension based on format enum
        var fileExtension = GetFileExtension(format);

        // 5. Save the file to storage
        var fileName = $"transcript_{studentID}_{DateTime.UtcNow:yyyyMMddHHmmss}{fileExtension}";
        var uploadResult = await SaveTranscriptFileAsync(fileName, fileData, isOfficial);

        // 6. Create response with file details
        var response = new DownloadTranscriptResponse
        {
            TranscriptID = Guid.NewGuid(),
            IsOfficial = isOfficial,
            GeneratedDate = DateTimeOffset.UtcNow,
            FileName = fileName,
            FileUrl = uploadResult.FileUrl,
            FileType = GetMimeType(format),
            FileSize = uploadResult.FileSize,
            ExpiryDays = isOfficial ? 30 : 7, // Official transcripts available longer
            IsPasswordProtected = isOfficial, // Official transcripts are password protected
            RequiresAuthentication = true // Always require authentication
        };

        return response;
    }

    // Helper methods
    private async Task<string> GenerateTranscriptFileAsync(object transcriptData, TranscriptFormat format, bool isOfficial)
    {
        _logger.LogInformation("Generating {Format} transcript file (Official: {IsOfficial})", format, isOfficial);

        // Handle different types of transcript data
        if (transcriptData is SemesterTranscriptResponse semesterTranscript)
        {
            // TODO: Generate semester-specific transcript
        }
        else if (transcriptData is TranscriptSummaryResponse fullTranscript)
        {
            // TODO: Generate full transcript
        }

        await Task.Delay(100); // Simulate file generation time
        return "MockFileContents";
    }

    private async Task<(string FileUrl, string FileSize)> SaveTranscriptFileAsync(string fileName, string fileData, bool isOfficial)
    {
        // TODO: Implement storage to local file system
        _logger.LogInformation("Saving transcript file {FileName}", fileName);

        // Simulate saving delay and generate a temporary URL
        await Task.Delay(100);

        // Example URL that would be a working download link in a real system
        var url = $"/api/transcripts/download/{fileName}?temp=true";
        return (url, "256 KB"); // Mock file size
    }

    private async Task LogTranscriptRequestAsync(string studentID, bool isOfficial, string? purpose)
    {
        // In a real system, you would log this to a database table for audit purposes
        _logger.LogInformation(
            "Transcript request logged - Student: {StudentID}, Official: {IsOfficial}, Purpose: {Purpose}",
            studentID, isOfficial, purpose ?? "Not specified");

        await Task.CompletedTask;
    }

    // Helper methods to work with the TranscriptFormat enum
    private string GetFileExtension(TranscriptFormat format)
    {
        return format switch
        {
            TranscriptFormat.Pdf => ".pdf",
            TranscriptFormat.Docx => ".docx",
            _ => throw new ArgumentException($"Unsupported transcript format: {format}")
        };
    }

    private string GetMimeType(TranscriptFormat format)
    {
        return format switch
        {
            TranscriptFormat.Pdf => "application/pdf",
            TranscriptFormat.Docx => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            _ => throw new ArgumentException($"Unsupported transcript format: {format}")
        };
    }
}