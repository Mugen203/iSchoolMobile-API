namespace iSchool_Solution.Entities.DTO.Transcript;

public record SemesterProgress(
    string SemesterName,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    string CurrentWeek,
    double CurrentGPA,
    int EnrolledCredits,
    List<CourseProgress> Courses
);