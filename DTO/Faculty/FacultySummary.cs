namespace iSchool_Solution.Entities.DTO.Faculty;

public record FacultySummary(
    Guid FacultyID,
    string FacultyName,
    string FacultyDescription,
    DateTimeOffset FoundingYear 
);