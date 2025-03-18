namespace iSchool_Solution.Entities.DTO.Course;

public record CourseDetails(
    Guid CourseID,
    string CourseCode,
    string CourseName,
    string Description,
    int Credits,
    string DepartmentName,
    bool IsEnrolled,
    int TotalEnrolled,
    int MaxCapacity,
    List<Lecturer.LecturerDetails> Lecturers,
    List<ScheduleItem> Schedule,
    List<string> Prerequisites,
    string Syllabus
);