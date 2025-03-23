using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Drop.Models;

namespace iSchool_Solution.Features.Courses.Drop;

public class RequestValidator : Validator<DropCourseRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseID)
            .NotEmpty().WithMessage("Course ID is required");
    }
}