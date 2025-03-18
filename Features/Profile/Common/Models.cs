using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Profile.Common;

public class Models
{
    public sealed class ProfileResponse
    {
        public string StudentID { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public Gender Gender { get; init; } = default;
        public string PhoneNumber { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public string StudentEmail { get; init; } = string.Empty;
        public string AcademicAdvisor { get; init; } = string.Empty;
        public string DateOfBirthString { get; init; } = string.Empty;
        public DateTimeOffset DateOfBirth { get; set; }
        public string Degree { get; init; } = string.Empty;
        public string DepartmentName { get; init; } = string.Empty;
        public string StudentPhotoUrl { get; init; } = string.Empty;
        public string EmergencyContactName { get; init; } = string.Empty;
        public string EmergencyContactPhone { get; init; } = string.Empty;
    }

    public sealed class ProfileRequest
    {
        public string PhoneNumber { get; init; } = string.Empty;
        public string Address { get; init; } = string.Empty;
        public string EmergencyContactName { get; init; } = string.Empty;
        public string EmergencyContactPhone { get; init; } = string.Empty;
        public string StudentPhotoUrl { get; init; } = string.Empty;
    }
}