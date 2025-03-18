namespace iSchool_Solution.Features.Auth.RefreshToken;

public class Models
{
    public sealed class RefreshTokenRequest
    {
        public string StudentID { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
    
    public sealed class RefreshTokenResponse
    {
        public bool IsSuccessful { get; init; }
        public string? Token { get; init; }
        public string? RefreshToken { get; init; }
        public DateTimeOffset ExpiresAt { get; init; }
        public bool RequiresTwoFactor  { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}