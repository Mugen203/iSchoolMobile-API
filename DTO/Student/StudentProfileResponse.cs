using iSchool_Solution.Enums;

namespace iSchool_Solution.DTO.Student;

public record StudentProfileResponse(
    string StudentID,
    string FirstName,
    string LastName,
    string FullName,
    string StudentEmail,
    string PhoneNumber,
    string Address,
    DateTimeOffset DateOfBirth,
    Gender Gender,
    string Degree,
    string DepartmentName,
    string EmergencyContactName,
    string EmergencyContactPhone,
    string StudentPhotoUrl);