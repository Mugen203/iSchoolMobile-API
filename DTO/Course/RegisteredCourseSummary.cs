namespace iSchool_Solution.Entities.DTO.Course;

public record RegisteredCourseSummary(
    string CourseCode,
    string CourseName,
    int Credits,
    List<ScheduleItem> Schedule,
    List<Lecturer.LecturerDetails> Lecturers 
);