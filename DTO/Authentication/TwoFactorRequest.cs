using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.DTO.Authentication;

public record TwoFactorRequest
{
    [Required] public string StudentID { get; set; }

    [Required] public string TwoFactorToken { get; set; }
}