using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Conflicts.Models;

namespace iSchool_Solution.Features.Courses.Conflicts;

public class RequestValidator : Validator<ScheduleConflictRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseID)
            .NotNull().WithMessage("Course IDs cannot be null")
            .NotEmpty().WithMessage("At least one course ID must be provided");
    }
}