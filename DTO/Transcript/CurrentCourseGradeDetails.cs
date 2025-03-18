namespace iSchool_Solution.Entities.DTO.Transcript;

public record CurrentCourseGradeDetails(
    string CourseCode,
    string CourseName,
    int Credits,
    string CurrentGrade,
    double GradeValue,
    List<CourseGrade> Assessments
);