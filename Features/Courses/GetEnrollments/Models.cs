using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Courses.GetEnrollments;

public class Models
{
    public class EnrollmentsRequest
    {
        public string? Semester { get; set; }
        public string? AcademicYear { get; set; }
        public bool CurrentOnly { get; set; } = true;
    }

    public class EnrollmentsResponse
    {
        public string StudentID { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public List<EnrollmentItem> Enrollments { get; set; } = new();
        public int TotalCredits { get; set; }
        public int TotalCourses { get; set; }
        public decimal TotalFees { get; set; }
    }

    public class EnrollmentItem
    {
        public Guid CourseID { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Department { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public string Grade { get; set; } = string.Empty;
        public EnrollmentStatus Status { get; set; }
        public List<ScheduleInfo> Schedule { get; set; } = [];
        public LecturerInfo Lecturer { get; set; } = new();
        public decimal CourseFee { get; set; }
    }

    public class ScheduleInfo
    {
        public string Day { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public ClassLocation Location { get; set; }
    }

    public class LecturerInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}