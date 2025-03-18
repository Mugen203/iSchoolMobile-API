using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.DTO.Authentication;

public record LoginRequest
{
    [Required(ErrorMessage = "StudentID is required")]
    public string StudentID { get; init; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; init; } = string.Empty;

    public bool RememberMe { get; init; }
}