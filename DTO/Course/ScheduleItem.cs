namespace iSchool_Solution.Entities.DTO.Course;

public record ScheduleItem(
    DayOfWeek Day,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Location
);