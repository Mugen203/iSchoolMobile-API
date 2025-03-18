using iSchool_Solution.Entities.DTO.Course;

namespace iSchool_Solution.Entities.DTO.Department;

public record DepartmentDetails(
    Guid DepartmentID,
    string DepartmentName,
    string DepartmentDescription,
    DateTimeOffset BirthYear,
    string FacultyName,
    List<CourseListItem> Courses 
);