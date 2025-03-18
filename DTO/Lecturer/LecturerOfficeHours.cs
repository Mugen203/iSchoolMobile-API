namespace iSchool_Solution.Entities.DTO.Lecturer;

public record LecturerOfficeHours(
    DayOfWeek Day,
    TimeOnly StartTime, 
    TimeOnly EndTime, 
    string Location,
    bool IsVirtual,
    string VirtualMeetingLink,
    string Notes
);