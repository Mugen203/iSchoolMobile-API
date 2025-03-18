namespace iSchool_Solution.Entities.DTO.Transcript;

public record SemesterSummary(
    Guid SemesterRecordID,
    string Semester,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    double SemesterGPA,
    int Credits,
    List<CourseGrade> Grades
);