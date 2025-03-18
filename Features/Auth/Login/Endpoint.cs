using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Auth.Login.Models;

namespace iSchool_Solution.Features.Auth.Login;

public class Endpoint(AuthService authService) : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("api/auth/login");
        AllowAnonymous();
        Description(description => description
            .Produces<LoginResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status401Unauthorized));
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var response = await authService.ValidateUserAsync(request);

        if (response == null)
        {
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        if (response.IsSuccessful)
        {
            await SendOkAsync(response, cancellationToken);
        }

        else if (response.RequiresTwoFactor)
        {
            await SendOkAsync(response, cancellationToken);
        }

        else
        {
            await SendErrorsAsync(400, cancellationToken);
        }
    }
}