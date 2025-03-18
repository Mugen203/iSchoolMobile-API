namespace iSchool_Solution.DTO.Student;

public record StudentSummary(
    string StudentID,
    string FirstName,
    string LastName,
    string Email,
    string DepartmentName,
    double CumulativeGPA,
    string AcademicStanding,
    int CompletedCredits
);