using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Academics.GetAcademicProgress;

public class Models
{
    public class AcademicSummaryResponse
    {
        public double CumulativeGPA { get; set; }
        public int CreditsEarned { get; set; }
        public int CreditsAttempted { get; set; }
        public AcademicStanding AcademicStanding { get; set; } 
        public List<SemesterProgressInfo> Semesters { get; set; } = new List<SemesterProgressInfo>();
    }

    public class SemesterProgressInfo
    {
        public string SemesterName { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public double SemesterGPA { get; set; } 
        public int CreditsAttemptedThisSemester { get; set; }
        public int CreditsEarnedThisSemester { get; set; } 
        public List<CourseProgressInfo> Courses { get; set; } = new List<CourseProgressInfo>();
    }

    public class CourseProgressInfo
    {
        public Guid CourseID { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string CurrentGrade { get; set; } = string.Empty; // String representation of GradeLetter for display
    }
}