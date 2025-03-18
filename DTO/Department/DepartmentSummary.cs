namespace iSchool_Solution.Entities.DTO.Department;

public record DepartmentSummary(
    Guid DepartmentID,
    string DepartmentName,
    string DepartmentDescription,
    DateTimeOffset BirthYear,
    string FacultyName,
    int TotalCourses,
    int TotalStudents
);