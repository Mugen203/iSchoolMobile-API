
namespace iSchool_Solution.Features.Auth.Login;

public class Models
{
    public sealed class LoginRequest
    {
        public string StudentID { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public bool RememberMe { get; init; }
    }

    public sealed class LoginResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public bool RequiresTwoFactor  { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}