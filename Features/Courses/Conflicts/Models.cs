namespace iSchool_Solution.Features.Courses.Conflicts;

public class Models
{
    public class ScheduleConflictResponse
    {
        public bool HasConflicts { get; set; }
        public List<ScheduleConflict> Conflicts { get; set; } = [];
    }

    public class ScheduleConflictRequest
    {
        public string CourseID { get; set; } = string.Empty;
    }

    public class ScheduleConflict
    {
        public string ConflictingCourseCode { get; set; } = string.Empty;
        public string ConflictingCourseName { get; set; } = string.Empty;
        public DayOfWeek ConflictDay { get; set; }
        public string ConflictTime { get; set; } = string.Empty;
    };
}