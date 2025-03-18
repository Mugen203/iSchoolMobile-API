namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record EvaluationPeriodSummary(
    int Id,
    string AcademicYear,
    string Semester,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    bool IsActive
);