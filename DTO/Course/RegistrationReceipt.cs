namespace iSchool_Solution.Entities.DTO.Course;

public record RegistrationReceipt(
    string StudentID,
    string StudentName,
    string Semester,
    string AcademicYear,
    DateTimeOffset RegistrationDate,
    int TotalCredits,
    decimal TotalFees,
    List<RegisteredCourseSummary> RegisteredCourses
);