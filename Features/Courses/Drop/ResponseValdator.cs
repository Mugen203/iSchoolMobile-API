using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Drop.Models;

namespace iSchool_Solution.Features.Courses.Drop;

public class ResponseValidator : Validator<DropCourseResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.CourseID)
            .NotEmpty().WithMessage("Course ID cannot be empty");
            
        RuleFor(response => response.Message)
            .NotEmpty().WithMessage("Message cannot be empty");
    }
}