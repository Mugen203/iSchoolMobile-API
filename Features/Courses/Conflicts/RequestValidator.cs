using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Conflicts.Models;

namespace iSchool_Solution.Features.Courses.Conflicts;

public class RequestValidator : Validator<ScheduleConflictRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseCodes)
            .NotNull().WithMessage("Course codes cannot be null")
            .NotEmpty().WithMessage("Course codes must be provided");

        RuleForEach(request => request.CourseCodes)
            .NotNull().WithMessage("Course code cannot be null")
            .NotEmpty().WithMessage("Course code must be provided")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
            .Matches(@"^[A-Z0-9]{2,10}$").WithMessage("Course code must be in a valid format (e.g., CS101)");
    }
}