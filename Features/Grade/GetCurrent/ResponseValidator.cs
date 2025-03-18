using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Grade.GetCurrent.Models;

namespace iSchool_Solution.Features.Grade.GetCurrent;

public class ResponseValidator : Validator<CurrentGradesResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.CurrentCourses)
            .NotNull().WithMessage("Current Courses list cannot be null")
            .NotEmpty().WithMessage("Current Courses list cannot be empty")
            .ForEach(course =>
                course.SetValidator(new CurrentCourseGradeInfoValidator())); // Validate each CurrentCourseGradeInfo
    }
}

public class CurrentCourseGradeInfoValidator : Validator<CurrentCourseGradeInfo>
{
    public CurrentCourseGradeInfoValidator()
    {
        RuleFor(course => course.CourseCode)
            .NotEmpty().WithMessage("Course Code cannot be empty");

        RuleFor(course => course.CourseName)
            .NotEmpty().WithMessage("Course Name cannot be empty");

        RuleFor(course => course.Credits)
            .NotNull().WithMessage("Credits cannot be null")
            .GreaterThan(0).WithMessage("Credits must be greater than 0");

        RuleFor(course => course.CurrentGrade)
            .NotEmpty().WithMessage("Current Grade cannot be empty");

        RuleFor(course => course.GradeValue)
            .NotNull().WithMessage("Grade Value cannot be null")
            .InclusiveBetween(0.0, 4.0).WithMessage("Grade Value must be between 0.0 and 4.0"); 
    }
}