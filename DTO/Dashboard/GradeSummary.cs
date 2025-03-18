namespace iSchool_Solution.Entities.DTO.Dashboard;

public record GradeSummary(
    string CourseCode,
    string CourseName,
    string Assessment,
    string Grade,
    DateTimeOffset PostedDate
);