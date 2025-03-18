using System.Globalization;
using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Profile.Common.Models;

namespace iSchool_Solution.Features.Profile.Common;

public partial class ResponseValidator : Validator<ProfileResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.StudentID)
            .NotEmpty().WithMessage("StudentID cannot be empty.")
            .MinimumLength(13).WithMessage("StudentID must be at least 13 characters.");

        RuleFor(response => response.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters.")
            .MaximumLength(20).WithMessage("First name cannot exceed 20 characters.");

        RuleFor(response => response.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters.")
            .MaximumLength(20).WithMessage("Last name cannot exceed 20 characters.");

        RuleFor(response => response.Address)
            .NotEmpty().WithMessage("Address cannot be empty.")
            .MinimumLength(10).WithMessage("Address must be at least 10 digits long.")
            .MaximumLength(50).WithMessage("Address cannot exceed 50 characters.");

        RuleFor(response => response.Gender)
            .NotEmpty()
            .WithMessage("Gender cannot be empty.");

        RuleFor(response => response.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MinimumLength(10).WithMessage("Phone number must be at least 10 digits long.")
            .Matches(@"^\+?(\d[\d\s().-]{0,}){9}\d$").WithMessage("Invalid phone number format.");

        RuleFor(response => response.StudentEmail)
            .NotEmpty().WithMessage("StudentEmail cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(response => response.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth cannot be empty.")
            .Custom((_, context) =>
            {
                var dateString =
                    context.InstanceToValidate.DateOfBirthString; // Access DateOfBirthString from the instance

                if (string.IsNullOrEmpty(dateString)) return; // Already handled by NotEmpty, but for robustness

                if (!MyRegex().IsMatch(dateString))
                {
                    context.AddFailure("Date of Birth must be in DD - MM -YYYY format.");
                    return; // Format invalid, no need to check date validity
                }

                if (!DateTimeOffset.TryParseExact
                    (
                        dateString,
                        "dd - MM -YYYY",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal,
                        out var parsedDate
                    ))
                {
                    context.AddFailure("Date of Birth is not a valid date.");
                    return; // Parsing failed, invalid date
                }

                // If format is valid and parsing successful, set the DateOfBirth property
                context.InstanceToValidate.DateOfBirth = parsedDate;
            });

        RuleFor(response => response.Degree)
            .NotEmpty().WithMessage("Degree cannot be empty.")
            .MinimumLength(4).WithMessage("Degree must be at least 4 characters.")
            .MaximumLength(100).WithMessage("Degree cannot exceed 100 characters.");

        RuleFor(response => response.DepartmentName)
            .NotEmpty().WithMessage("Department name cannot be empty.")
            .MinimumLength(2).WithMessage("Department name must be at least 2 characters.")
            .MaximumLength(20).WithMessage("Department name cannot exceed 20 characters.");

        RuleFor(response => response.AcademicAdvisor)
            .NotEmpty().WithMessage("Academic advisor cannot be empty.")
            .MinimumLength(10).WithMessage("Academic advisor must be at least 10 characters.")
            .MaximumLength(20).WithMessage("Academic advisor cannot exceed 20 characters.");

        RuleFor(response => response.StudentPhotoUrl)
            .NotNull().WithMessage("StudentPhotoUrl cannot be null.");

        RuleFor(response => response.EmergencyContactName)
            .NotEmpty().WithMessage("EmergencyContact name cannot be empty.")
            .MinimumLength(2).WithMessage("EmergencyContact name must be at least 2 characters.")
            .MaximumLength(20).WithMessage("EmergencyContact name cannot exceed 20 characters.");

        RuleFor(response => response.EmergencyContactPhone)
            .NotEmpty().WithMessage("EmergencyContact phone number cannot be empty.")
            .MinimumLength(10).WithMessage("Phone number must be at least 10 digits long.")
            .Matches(@"^\+?(\d[\d\s().-]{0,}){9}\d$").WithMessage("Invalid phone number format.");
    }

    // Regex for date
    [System.Text.RegularExpressions.GeneratedRegex(@"^\d{2}\s-\s\d{2}\s-\s\d{4}$")]
    private static partial System.Text.RegularExpressions.Regex MyRegex();
}