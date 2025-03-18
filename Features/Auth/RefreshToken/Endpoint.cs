using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Auth.RefreshToken.Models;

namespace iSchool_Solution.Features.Auth.RefreshToken;

public class Endpoint(AuthService authService) : Endpoint<RefreshTokenRequest, RefreshTokenResponse>
{
    public override void Configure()
    {
        Post(("api/auth/refresh-token"));
        Roles("Student");
        Description(description => description
            .Produces<RefreshTokenResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }

    public override async Task HandleAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var refreshTokenResponse = await authService.RefreshTokenAsync(request);

        if (refreshTokenResponse.IsSuccessful)
        {
            await SendOkAsync(refreshTokenResponse, cancellationToken);
        }

        else
        {
            await SendErrorsAsync(400, cancellationToken);
        }
    }
}