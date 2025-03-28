using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Auth.Login.Models;

namespace iSchool_Solution.Features.Auth.Login;

public class Endpoint : Endpoint<LoginRequest, LoginResponse>
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
        Post("api/auth/login");
        AllowAnonymous();
        Description(description => description
            .WithName("Login")
            .WithSummary("Logs on the login page")
            .WithTags("Login")
            .Produces<LoginResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status401Unauthorized));
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Login attempt for StudentID: {StudentID}", request.StudentID);

        var response = await _authService.ValidateUserAsync(request);

        if (response == null)
        {
            _logger.LogWarning("AuthService returned null for StudentID: {StudentID}", request.StudentID);
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        if (response.IsSuccessful || response.RequiresTwoFactor)
        {
            _logger.LogInformation(
                "Login response for StudentID {StudentID}: Successful={IsSuccessful}, RequiresTwoFactor={RequiresTwoFactor}",
                request.StudentID, response.IsSuccessful, response.RequiresTwoFactor);
            await SendOkAsync(response, cancellationToken);
        }
        
        else if (response.Message is "Authentication Failed" or "Invalid credentials.")
        {
            _logger.LogWarning("Login failed for StudentID {StudentID}: Invalid credentials", request.StudentID);
            await SendStringAsync("Invalid credentials.", StatusCodes.Status401Unauthorized,
                cancellation: cancellationToken);
        }
        else if (response.Message.Contains("locked out"))
        {
            _logger.LogWarning("Login failed for StudentID {StudentID}: Account locked out", request.StudentID);
            await SendStringAsync(response.Message, StatusCodes.Status401Unauthorized, cancellation: cancellationToken);
        }
        else
        {
            // For other unexpected errors indicated by the service response
            _logger.LogWarning("Login failed for StudentID {StudentID} with unexpected message: {Message}",
                request.StudentID, response.Message);
            AddError(response.Message);
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
        }
    }
}