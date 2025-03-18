using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Grade.GetSemester;

public class Models
{
    public class SemesterGradesResponse
    {
        public double SemesterGPA { get; set; }
        public int CreditsAttempted { get; set; }
        public int CreditsEarned { get; set; }
        public List<CourseGradeInfo> Grades { get; set; } = new List<CourseGradeInfo>();
    }

    public class CourseGradeInfo // New DTO specific for GetSemesterGrades
    {
        public Guid GradeID { get; set; }
        public Guid CourseID { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public GradeLetter Grade { get; set; }
        public double GradePoints { get; set; }
        public string? Remarks { get; set; } = string.Empty;
    }
}