namespace iSchool_Solution.Features.Courses.GetSchedule;

public class Models
{
    public class ScheduleResponse
    {
        public List<ScheduledCourseInfo> Courses { get; set; } = new();
    }

    public class ScheduledCourseInfo
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
    }
}