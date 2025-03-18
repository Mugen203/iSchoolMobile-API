namespace iSchool_Solution.DTO.Authentication;

public record AuthResponse(
    bool IsSuccessful,
    string? Token,
    string? RefreshToken,
    DateTime ExpiresAt,
    bool RequiresTwoFactor,
    string Message
);