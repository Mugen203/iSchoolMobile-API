using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Courses.GetCourseDetails;

public class Models
{
    public class CourseDetailsResponse
    {
        public Guid CourseID { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Department { get; set; } = string.Empty;
        public List<LecturerInfo> Lecturers { get; set; } = [];
        public List<ScheduleItem> Schedule { get; set; } = [];
        public int EnrollmentCount { get; set; }
        public int MaxCapacity { get; set; }
        public decimal CourseFee { get; set; }
        public List<string> Prerequisites { get; set; } = [];
        public string Syllabus { get; set; } = string.Empty;
        public bool IsRegistrationOpen { get; set; }
    }
    
    public class CourseDetailsRequest
    {
        public Guid CourseID { get; set; }
    }
    
    public class LecturerInfo
    {
        public string LecturerID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Office { get; set; } = string.Empty;
        public string ContactHours { get; set; } = string.Empty;
    }

    public class ScheduleItem
    {
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public ClassLocation Location { get; set; }
    }
}