using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;

namespace iSchool_Solution.Features.Auth.Logout;

[Authorize]
public class Endpoint : EndpointWithoutRequest
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
        Post("api/auth/logout");
        Roles("Student");
        Description(description => description
            .WithName("Logout")
            .WithSummary("Logs student out of the application")
            .WithTags("Logout")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            _logger.LogWarning("User ID (NameIdentifier) claim was not found in token during logout attempt.");
            AddError("User identifier not found in token.");
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            return;
        }

        _logger.LogInformation("Logout attempt for User ID: {UserID}", userId);

        try
        {
            var logoutResponse = await _authService.LogoutAsync(userId);

            if (logoutResponse.IsSuccessful)
            {
                _logger.LogInformation("Logout successful for User ID: {UserID}", userId);
                await SendNoContentAsync(cancellationToken);
            }
            else
            {
                // Handle unexpected failure within the logout service itself
                _logger.LogError("Logout service failed for User ID: {UserID}. Message: {Message}", userId,
                    logoutResponse.Message);
                await SendStringAsync(logoutResponse.Message, StatusCodes.Status500InternalServerError, cancellation: cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected exception during logout for User ID: {UserID}", userId);
            await SendStringAsync("An unexpected error occurred during logout.",
                StatusCodes.Status500InternalServerError, cancellation: cancellationToken);
        }
    }
}