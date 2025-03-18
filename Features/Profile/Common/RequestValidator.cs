using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Profile.Common.Models;

namespace iSchool_Solution.Features.Profile.Common;

public class RequestValidator : Validator<ProfileRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.Address);

        RuleFor(request => request.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MinimumLength(10).WithMessage("Phone number must be at least 10 digits long.")
            .Matches(@"^\+?(\d[\d\s().-]{0,}){9}\d$").WithMessage("Invalid phone number format.");

        RuleFor(request => request.EmergencyContactName)
            .NotEmpty().WithMessage("EmergencyContact name cannot be empty.")
            .MinimumLength(2).WithMessage("EmergencyContact name must be at least 2 characters.")
            .MaximumLength(20).WithMessage("EmergencyContact name cannot exceed 20 characters.");

        RuleFor(request => request.EmergencyContactPhone)
            .NotEmpty().WithMessage("EmergencyContact phone number cannot be empty.")
            .MinimumLength(10).WithMessage("Phone number must be at least 10 digits long.")
            .Matches(@"^\+?(\d[\d\s().-]{0,}){9}\d$").WithMessage("Invalid phone number format.");

        RuleFor(request => request.StudentPhotoUrl)
            .NotNull().WithMessage("StudentPhotoUrl cannot be null.");
    }
}