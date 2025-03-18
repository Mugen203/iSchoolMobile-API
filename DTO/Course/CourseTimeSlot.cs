namespace iSchool_Solution.Entities.DTO.Course;

public record CourseTimeSlot(
    Guid CourseID,
    string CourseCode,
    string CourseName,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Location,
    string LecturerName,
    string Color
);