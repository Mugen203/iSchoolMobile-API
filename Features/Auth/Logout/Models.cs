namespace iSchool_Solution.Features.Auth.Logout;

public class Models
{
    public sealed class LogoutResponse
    {
        public bool IsSuccessful { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}