using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Auth.Login.Models;
using static iSchool_Solution.Features.Auth.Verify2FA.Models;

namespace iSchool_Solution.Features.Auth.Verify2FA;

public class Endpoint : Endpoint<TwoFactorRequest, LoginResponse>
{
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService;

    public Endpoint(AuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }
    
    public override void Configure()
    {
        Post("api/auth/verify-2fa");
        AllowAnonymous();
        Description(description => description
            .Produces<LoginResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }
    
    public override async Task HandleAsync(TwoFactorRequest request, CancellationToken cancellationToken)
    {
        var (is2FaRequired, jwtToken) = await _authService.LoginAsync
        (
            request.StudentID,
            request.TwoFactorToken
        );
        
        if (!is2FaRequired && !string.IsNullOrEmpty(jwtToken))
        {
            var response = new LoginResponse
            {
                IsSuccessful = true,
                Token = jwtToken,
                RefreshToken = string.Empty,
                Message = "2FA verification successful. Login completed.",
                RequiresTwoFactor = false,
                ExpiresAt = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration.GetSection("JwtSettings")["ExpiryInMinutes"] ?? "300"))
            };
            
            await SendOkAsync(response, cancellationToken);
            return;
        }
        
        await SendUnauthorizedAsync(cancellationToken);
    }
}