namespace iSchool_Solution.Entities.DTO.Transcript;

public record CourseGrade(
    Guid GradeID,
    Guid CourseID,
    string CourseCode,
    string CourseName,
    int Credits,
    string Grade,
    double GradePoints,
    string Remarks
);