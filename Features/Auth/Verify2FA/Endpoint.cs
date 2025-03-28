using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Auth.Login.Models;
using static iSchool_Solution.Features.Auth.Verify2FA.Models;

namespace iSchool_Solution.Features.Auth.Verify2FA;

public class Endpoint : Endpoint<TwoFactorRequest, LoginResponse>
{
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(AuthService authService, IConfiguration configuration, ILogger<Endpoint> logger)
    {
        _authService = authService;
        _configuration = configuration;
        _logger = logger;
    }
    
    public override void Configure()
    {
        Post("api/auth/verify-2fa");
        AllowAnonymous();
        Description(description => description
            .WithName("Verify 2FA")
            .WithSummary("Verifies 2FA API endpoint.")
            .WithTags("Verify2FA")
            .Produces<LoginResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }
    
    public override async Task HandleAsync(TwoFactorRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Verify 2FA attempt for StudentID: {StudentID}", request.StudentID); // Add entry log

        var (is2FaRequired, jwtToken) = await _authService.LoginAsync(
            request.StudentID,
            request.TwoFactorToken
        );

        if (!is2FaRequired && !string.IsNullOrEmpty(jwtToken))
        {
            // Generate Refresh Token (Placeholder - requires adding GenerateAndStoreRefreshToken to AuthService)
            // string? newRefreshToken = await _authService.GenerateAndStoreRefreshToken(request.StudentID);

            var response = new LoginResponse
            {
                IsSuccessful = true,
                Token = jwtToken,
                RefreshToken = "placeholder_refresh_token", // Replace with actual newRefreshToken
                Message = "2FA verification successful. Login completed.",
                RequiresTwoFactor = false,
                ExpiresAt = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration.GetSection("JwtSettings")["ExpiryInMinutes"] ?? "300"))
            };
            _logger.LogInformation("Verify 2FA successful for StudentID: {StudentID}", request.StudentID);
            await SendOkAsync(response, cancellationToken);
            return;
        }

        _logger.LogWarning("Verify 2FA failed for StudentID: {StudentID}", request.StudentID);
        await SendUnauthorizedAsync(cancellationToken);
    }
}