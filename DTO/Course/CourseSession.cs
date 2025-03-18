namespace iSchool_Solution.Entities.DTO.Course;

public record CourseSession(
    DayOfWeek Day,
    TimeOnly StartTime, 
    TimeOnly EndTime,
    string Location,
    string RoomNumber,
    string BuildingName,
    string LecturerName
);