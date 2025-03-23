using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Features.Courses.Register;

public class RequestValidator : Validator<CourseRegistrationRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseCodes)
            .NotNull().WithMessage("Course codes cannot be null")
            .NotEmpty().WithMessage("At least one course code must be provided");
            
        // Regex pattern validation for course codes
        RuleForEach(request => request.CourseCodes)
            .NotEmpty().WithMessage("Course code cannot be empty")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
            .Matches(@"^[A-Z]{2,4}\d{3,4}$").WithMessage("Course code must be in format like 'COSC101' or 'CS101'");
    }
}