namespace iSchool_Solution.Entities.DTO.Grade;

public record GradeDetails(
    Guid GradeID,
    Guid SemesterRecordID,
    string CourseCode,
    string StudentID,
    DateTimeOffset DateAwarded,
    string GradeLetter,
    double GradePoints,
    bool IsCourseCompleted,
    string Semester,
    string Remarks
);