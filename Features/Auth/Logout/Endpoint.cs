using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;

namespace iSchool_Solution.Features.Auth.Logout;

[Authorize]
public class Endpoint(AuthService authService) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("api/auth/logout");
        Roles("Student");
        Description(description => description
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status400BadRequest));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);
        
        if (studentIdClaim == null || string.IsNullOrEmpty(studentIdClaim.Value))
        {
            await SendErrorsAsync(400, cancellationToken);
            return;
        }

        var studentId = studentIdClaim.Value;
        var logoutResponse = await authService.LogoutAsync(studentId);
        
        if (logoutResponse.IsSuccessful)
        {
            await SendNoContentAsync(cancellationToken);
        }

        else
        {
            await SendUnauthorizedAsync(cancellationToken);
        }
    }
}