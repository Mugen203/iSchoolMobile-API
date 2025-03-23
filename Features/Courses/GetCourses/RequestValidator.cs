using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetCourses.Models;

namespace iSchool_Solution.Features.Courses.GetCourses;

public class RequestValidator : Validator<CourseListRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.Page)
            .GreaterThanOrEqualTo(1).When(r => r.Page.HasValue)
            .WithMessage("Page must be greater than or equal to 1");
            
        RuleFor(request => request.PageSize)
            .InclusiveBetween(1, 100).When(r => r.PageSize.HasValue)
            .WithMessage("Page size must be between 1 and 100");
            
        RuleFor(request => request.AcademicYear)
            .GreaterThanOrEqualTo(2000).When(r => r.AcademicYear.HasValue)
            .WithMessage("Academic year must be a valid year");
    }
}