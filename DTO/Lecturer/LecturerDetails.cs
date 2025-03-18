using iSchool_Solution.Entities.DTO.Course;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Lecturer;

public record LecturerDetails 
{
    public string LecturerID { get; init; } = string.Empty;
    public string LecturerFirstName { get; init; } = string.Empty;
    public string LecturerLastName { get; init; } = string.Empty;
    public string LecturerEmail { get; init; } = string.Empty;
    public string Office { get; init; } = string.Empty;
    public Gender Gender { get; init; }
    public string DepartmentName { get; init; } = string.Empty;
    public Guid DepartmentID { get; init; }
    public string Title { get; init; } = string.Empty; 
    public string Credentials { get; init; } = string.Empty;
    public string Biography { get; init; } = string.Empty;
    public string ProfileImageUrl { get; init; } = string.Empty;
    public List<LecturerOfficeHours> OfficeHours { get; init; } = new(); 
    public List<CourseListItem> CurrentCourses { get; init; } = new();
    public string ResearchInterests { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
}