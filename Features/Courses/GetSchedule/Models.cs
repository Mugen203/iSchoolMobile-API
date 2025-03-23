namespace iSchool_Solution.Features.Courses.GetSchedule;

public class Models
{
    public class ScheduleResponse
    {
        public List<ScheduledCourseInfo> Courses { get; set; } = [];
    }

    public class ScheduledCourseInfo
    {
        public Guid CourseID { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
    }
}