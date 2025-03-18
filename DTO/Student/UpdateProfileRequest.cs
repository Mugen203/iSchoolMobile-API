using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.DTO.Student;

public record UpdateProfileRequest
{
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; init; } = string.Empty;

    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string PhoneNumber { get; init; } = string.Empty;

    public string Address { get; init; } = string.Empty;

    public string EmergencyContactName { get; init; } = string.Empty;

    [Phone(ErrorMessage = "Invalid Emergency Contact Phone Number")]
    public string EmergencyContactPhone { get; init; } = string.Empty;
}