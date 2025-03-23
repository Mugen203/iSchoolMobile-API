using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetCourseDetails.Models;

namespace iSchool_Solution.Features.Courses.GetCourseDetails;

public class RequestValidator : Validator<CourseDetailsRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.CourseID)
            .NotEmpty().WithMessage("Course ID is required");
    }
}