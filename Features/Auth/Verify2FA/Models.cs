namespace iSchool_Solution.Features.Auth.Verify2FA;

public class Models
{
    public sealed class TwoFactorRequest
    {
        public string StudentID { get; set; }
        public string TwoFactorToken { get; set; }
    }
}