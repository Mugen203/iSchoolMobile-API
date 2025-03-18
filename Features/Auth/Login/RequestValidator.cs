using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Auth.Login.Models;

namespace iSchool_Solution.Features.Auth.Login;

public class RequestValidator : Validator<LoginRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.StudentID)
            .NotEmpty()
            .WithMessage("StudentID is required")
            .MinimumLength(10)
            .WithMessage("StudentID must be at least 13 characters long");

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8);
    }
}