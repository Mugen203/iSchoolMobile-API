namespace iSchool_Solution.Entities.DTO.Course;

public record ScheduleConflict(
    string ConflictingCourseCode,
    string ConflictingCourseName,
    string ConflictDay,
    string ConflictTime
);