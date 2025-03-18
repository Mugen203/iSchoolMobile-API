namespace iSchool_Solution.Entities.DTO.Transcript;

public record SemesterGPAPoint(
    string SemesterName,
    double GPA,
    int Credits
);