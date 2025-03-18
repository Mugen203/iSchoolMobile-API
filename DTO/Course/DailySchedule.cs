namespace iSchool_Solution.Entities.DTO.Course;

public record DailySchedule 
{
    public string Day { get; init; }
    public List<CourseTimeSlot> Courses { get; init; }
}