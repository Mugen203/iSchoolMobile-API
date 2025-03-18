namespace iSchool_Solution.Entities.DTO.Course;

public record StudentSchedule 
{
    public string Semester { get; init; } = string.Empty;
    public string AcademicYear { get; init; } = string.Empty;
    public int TotalCredits { get; init; }
    public int TotalCourses { get; init; }
    public List<DailySchedule> Schedule { get; init; } = new();
}