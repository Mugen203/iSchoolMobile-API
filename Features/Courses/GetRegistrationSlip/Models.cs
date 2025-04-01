namespace iSchool_Solution.Features.Courses.GetRegistrationSlip;

public class Models
{
    public class RegistrationSlipData
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow; // Or actual registration date if tracked
        public List<RegisteredCourseInfo> RegisteredCourses { get; set; } = [];
        public int TotalCredits { get; set; }
    }

    public class RegisteredCourseInfo
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}