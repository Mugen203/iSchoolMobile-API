using iSchool_Solution.Entities.DTO.Department;

namespace iSchool_Solution.Entities.DTO.Faculty;

public record FacultyDetails(
    Guid FacultyID,
    string FacultyName,
    string FacultyDescription,
    DateTimeOffset FoundingYear,
    List<DepartmentListItem> Departments
);