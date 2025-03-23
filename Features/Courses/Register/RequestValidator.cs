using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Features.Courses.Register;

public class RequestValidator : Validator<CourseRegistrationRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseIDs)
            .NotNull().WithMessage("Course IDs cannot be null")
            .NotEmpty().WithMessage("At least one course ID must be provided");
    }
}