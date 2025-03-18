using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Auth.Verify2FA.Models;

namespace iSchool_Solution.Features.Auth.Verify2FA;

public class TwoFactorRequestValidator : Validator<TwoFactorRequest>
{
    public TwoFactorRequestValidator()
    {
        RuleFor(request => request.StudentID)
            .NotEmpty()
            .WithMessage("StudentID is required")
            .MinimumLength(10)
            .WithMessage("StudentID must be at least 13 characters long");
        
        RuleFor(request => request.TwoFactorToken)
            .NotEmpty()
            .WithMessage("TwoFactorToken is required")
            .MinimumLength(5)
            .WithMessage("TwoFactorToken must be at least 5 characters long");
    }
}