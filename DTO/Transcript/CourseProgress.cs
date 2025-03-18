namespace iSchool_Solution.Entities.DTO.Transcript;

public record CourseProgress(
    Guid CourseID,
    string CourseCode,
    string CourseName,
    int Credits,
    string CurrentGrade,
    double CompletionPercentage,
    int CompletedAssignments,
    int TotalAssignments
);