namespace iSchool_Solution.Entities.DTO.Dashboard;

public record DeadlineSummary(
    string Title,
    string CourseCode,
    DateTimeOffset DueDate,
    string Type,
    string Priority
);