namespace iSchool_Solution.Features.Courses.Conflicts;

public class Models
{
    public class ScheduleConflictResponse
    {
        public List<ScheduleConflict> Conflicts { get; set; } = new();
    }

    public record ScheduleConflict(
        string ConflictingCourseCode,
        string ConflictingCourseName,
        string ConflictDay,
        string ConflictTime
    );
}