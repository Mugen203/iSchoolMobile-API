using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Transcript.Get;

public class Models
{
    public class TranscriptSummaryResponse
    {
        public Guid TranscriptID { get; set; }
        public double CummulativeGPA { get; set; }
        public int TotalCreditsEarned { get; set; }
        public int CreditsAttempted { get; set; }
        public AcademicStanding AcademicStanding { get; set; }
        public int RemainingRequiredCredits { get; set; }
        public double LastSemesterGPA { get; set; }
        public bool CanRequestOfficialTranscript { get; set; }
        public List<SemesterSummaryInfo> Semesters { get; set; } = new();
    }

    public class SemesterSummaryInfo
    {
        public Guid SemesterRecordID { get; set; }
        public string Semester { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public double SemesterGPA { get; set; }
        public int Credits { get; set; }
        public List<TranscriptCourseInfo> Grades { get; set; } = new();
    }

    public class TranscriptCourseInfo
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public GradeLetter Grade { get; set; }
        public double GradePoints { get; set; }
    }
}