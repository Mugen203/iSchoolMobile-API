namespace iSchool_Solution.Entities.DTO.Course;

public record CourseListItem(
    Guid CourseID,
    string CourseCode,
    string CourseName,
    int Credits,
    string DepartmentName,
    bool IsEnrolled,
    int TotalEnrolled,
    int MaxCapacity);