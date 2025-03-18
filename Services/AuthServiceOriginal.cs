using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using iSchool_Solution.DTO.Authentication;
using iSchool_Solution.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace iSchool_Solution.Services;

public class AuthServiceOriginal(
    IConfiguration configuration,
    UserManager<ApiUser> userManager,
    SignInManager<ApiUser> signInManager,
    ILogger<AuthService> logger)
{
    private ApiUser? _student;

    public async Task<AuthResponse> ValidateUserAsync(LoginRequest loginRequest)
    {
        // Find the user by StudentID
        var student = await userManager.FindByNameAsync(loginRequest.StudentID);

        if (student == null)
        {
            logger.LogWarning($"Authentication failed. Student ID {loginRequest.StudentID} not found.");
            return new AuthResponse(
                false,
                null,
                null,
                default,
                false,
                "Authentication Failed"
            );
        }

        // Use SignInManager to check password and handle lockouts
        var result = await signInManager.CheckPasswordSignInAsync(student, loginRequest.Password, true);

        if (result.Succeeded)
        {
            // Check if 2FA is enabled for this user
            if (await userManager.GetTwoFactorEnabledAsync(student))
            {
                // Generate 2FA token
                logger.LogInformation($"2FA is enabled for StudentID: {loginRequest.StudentID}. Generating 2FA token.");

                var token = await userManager.GenerateTwoFactorTokenAsync(student,
                    "Email");

                logger.LogInformation($"Generated 2FA Token (before SendEmailAsync): {token}");

                // Fix: Add null check before using student.Email
                if (!string.IsNullOrEmpty(student.Email))
                    // Send token via email
                    SendEmailAsync(student.Email, token);
                else
                    logger.LogWarning($"Cannot send 2FA token: Email is null for student {student.StudentID}");

                return new AuthResponse
                (
                    false,
                    null,
                    null,
                    default,
                    true,
                    "Please enter the verification code sent to your email.");
            }

            // Student is valid, generate the JWT token
            var jwtToken = await CreateTokenAsync(student);

            return new AuthResponse
            (
                Token: jwtToken,
                IsSuccessful: true,
                Message: "Authentication successful",
                RefreshToken: null, // Or generate refresh token
                ExpiresAt: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(configuration.GetSection("JwtSettings")["ExpiryInMinutes"] ??
                                     "300")), // Defaults to 300 mins
                RequiresTwoFactor: false // 2FA not required for this login path
            );
        }

        if (result.IsLockedOut)
        {
            logger.LogWarning($"Account locked out for Student ID {loginRequest.StudentID}");
            return new AuthResponse
            (
                false,
                Message: "Your account has been locked due to multiple failed attempts. Please try again later.",
                Token: null,
                RefreshToken: null,
                ExpiresAt: default,
                RequiresTwoFactor: false);
        }

        logger.LogWarning($"Authentication failed for Student ID {loginRequest.StudentID}");
        return new AuthResponse
        (
            false,
            Message: "Invalid credentials.",
            Token: null,
            RefreshToken: null,
            ExpiresAt: default,
            RequiresTwoFactor: false);
    }

    private async Task<string> CreateTokenAsync(ApiUser student)
    {
        _student = student;
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaimsAsync();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"] ?? string.Empty);

        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaimsAsync()
    {
        var claims = new List<Claim>();

        if (_student != null)
        {
            // Fix: Add null checks for claim values
            claims =
            [
                new Claim(ClaimTypes.NameIdentifier, _student.Id),
                new Claim(ClaimTypes.Name, _student.StudentID),
                new Claim("FirstName", _student.StudentFirstName),
                new Claim("LastName", _student.StudentLastName),
                new Claim(ClaimTypes.Email, _student.Email ?? string.Empty)
            ];

            var roles = await userManager.GetRolesAsync(_student);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        var tokenOptions = new JwtSecurityToken
        (
            jwtSettings["Issuer"],
            jwtSettings["Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(
                Convert.ToDouble(jwtSettings["ExpiryInMinutes"] ?? "300")), // Defaults to 300 mins
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    public async Task<bool> EnableTwoFactorAuthAsync(ApiUser student, string token)
    {
        var isTwoFactorTokenValid =
            await userManager.VerifyTwoFactorTokenAsync(student, TokenOptions.DefaultAuthenticatorProvider, token);

        if (!isTwoFactorTokenValid) return false;

        var result = await userManager.SetTwoFactorEnabledAsync(student, true);
        return result.Succeeded;
    }

    public async Task<bool> DisableTwoFactorAuthAsync(ApiUser student)
    {
        var result = await userManager.SetTwoFactorEnabledAsync(student, false);
        return result.Succeeded;
    }

    public async Task<(bool Is2faRequired, string JwtToken)> LoginAsync(string studentId, string twoFactorToken)
    {
        // 1. Find User by StudentID:
        var student = await userManager.FindByNameAsync(studentId);
        if (student == null) return (false, string.Empty);

        // 2. Check if 2FA is Enabled for the User:
        if (await userManager.GetTwoFactorEnabledAsync(student))
        {
            // 3a. 2FA is Enabled - Check if 2FA Token is Provided:
            if (string.IsNullOrEmpty(twoFactorToken))
                return (true, string.Empty);

            // 3b. 2FA Token is Provided - Verify it:
            if (!await userManager.VerifyTwoFactorTokenAsync(student, "Email",
                    twoFactorToken))
                return (false, string.Empty);
            // 3c. 2FA Token is Valid - Proceed to Generate JWT (fall through to step 4)
        }

        // 4. 2FA is Not Enabled OR 2FA is Enabled and Passed: Generate JWT Token:
        var jwtToken = await CreateTokenAsync(student);
        return (false, jwtToken);
    }

    private void SendEmailAsync(string email, string token)
    {
        // Cannot call this method with null email due to added checks
        // TODO: Implement mail service
        logger.LogInformation($"Sending 2FA token to email: {email}");
        logger.LogInformation($"2FA Token: {token}");
    }
}