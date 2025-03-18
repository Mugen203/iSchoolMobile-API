namespace iSchool_Solution.Entities.DTO.Transcript;

public record TranscriptCourseDetails(
    string CourseCode,
    string CourseName,
    int Credits,
    string Grade,
    double GradePoints
);