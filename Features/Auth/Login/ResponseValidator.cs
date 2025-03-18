using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Auth.Login.Models;

namespace iSchool_Solution.Features.Auth.Login;

public class ResponseValidator : Validator<LoginResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.IsSuccessful)
            .NotEmpty()
            .WithMessage("Must return true or false");
        
        RuleFor(response => response.Token)
            .NotEmpty()
            .WithMessage("Must return token or null.");
        
        RuleFor(response => response.RefreshToken)
            .NotEmpty()
            .WithMessage("Must return token or null.");
        
        RuleFor(response => response.ExpiresAt)
            .NotEmpty()
            .WithMessage("Token must have expiry date.");
        
        RuleFor(response => response.RequiresTwoFactor)
            .NotEmpty()
            .WithMessage("Must return true or false");
        
        RuleFor(response => response.Message)
            .NotEmpty()
            .WithMessage("Feedback text must not be empty.");
    }
}