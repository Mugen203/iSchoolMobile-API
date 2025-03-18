/*using iSchool_Solution.DTO.Authentication;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Mvc;

namespace iSchool_Solution.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AuthService authService, ILogger<AuthController> logger, IConfiguration configuration) : ControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        logger.LogInformation("Login request received for StudentID: {StudentID}", loginRequest.StudentID);
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Invalid login request model state.");
            return BadRequest(ModelState);
        }

        var authResponse = await authService.ValidateUserAsync(loginRequest);

        if (authResponse.IsSuccessful)
        {
            logger.LogInformation("Successful login for StudentID: {StudentID}", loginRequest.StudentID);
            return Ok(authResponse);
        }
        
        if (authResponse.RequiresTwoFactor)
        {
            // TODO: Perform additional checks here
            return Ok(authResponse);
        }
        
        if (authResponse.Message == "Your account has been locked due to multiple failed attempts. Please try again later.")
        {
            return BadRequest(authResponse);
        }
        
        logger.LogWarning("Login failed for StudentID: {StudentID}. Message: {Message}", loginRequest.StudentID, authResponse.Message);
        return BadRequest(authResponse);
    }

    [HttpPost("verify-2fa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> VerifyTwoFactor([FromBody] TwoFactorRequest verificationRequest)
    {
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Invalid login request model state.");
            return BadRequest(ModelState);
        }

        var (is2FaRequired, jwtToken) = await authService.LoginAsync
        (
            verificationRequest.StudentID,
            verificationRequest.TwoFactorToken
        );

        if (!is2FaRequired && !string.IsNullOrEmpty(jwtToken))
        {
            return Ok(new AuthResponse(
                IsSuccessful: true,
                Token: jwtToken,
                RefreshToken: string.Empty,
                Message: "2FA verification successful. Login completed.",
                RequiresTwoFactor: false,
                ExpiresAt: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(configuration.GetSection("JwtSettings")["ExpiryInMinutes"] ?? "300"))
            ));
        }

        return BadRequest(new AuthResponse
        (
            IsSuccessful: false,
            Token: null,
            RefreshToken: null,
            Message: "2FA verification failed.",
            ExpiresAt: default,
            RequiresTwoFactor: true
        ));
    }
}*/