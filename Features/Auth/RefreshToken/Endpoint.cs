using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Auth.RefreshToken.Models;

namespace iSchool_Solution.Features.Auth.RefreshToken;

[Authorize]
public class Endpoint : Endpoint<RefreshTokenRequest, RefreshTokenResponse>
{
    private readonly AuthService _authService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(AuthService authService, ILogger<Endpoint> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("api/auth/refresh-token");
        Roles("Student");
        Description(description => description
            .WithName("Refresh Token")
            .WithSummary("Refreshes the JWT token")
            .Produces<RefreshTokenResponse>()
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }

    public override async Task HandleAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Refresh token attempt for StudentID: {StudentID}", request.StudentID);

        var refreshTokenResponse = await _authService.RefreshTokenAsync(request);

        if (refreshTokenResponse.IsSuccessful)
        {
            _logger.LogInformation("Refresh token successful for StudentID: {StudentID}", request.StudentID);
            await SendOkAsync(refreshTokenResponse, cancellationToken); // 200 OK
        }
        else
        {
            _logger.LogWarning("Refresh token failed for StudentID {StudentID}: {Message}", request.StudentID,
                refreshTokenResponse.Message);
            await SendStringAsync(refreshTokenResponse.Message, StatusCodes.Status401Unauthorized,
                cancellation: cancellationToken); // 401
        }
    }
}