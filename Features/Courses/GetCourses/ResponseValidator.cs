using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetCourses.Models;

namespace iSchool_Solution.Features.Courses.GetCourses;

public class ResponseValidator : Validator<CourseListResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.Courses)
            .NotNull().WithMessage("Courses list cannot be null")
            .ForEach(course => course.SetValidator(new CourseItemValidator()));
            
        RuleFor(response => response.Page)
            .GreaterThanOrEqualTo(1).WithMessage("Page must be greater than or equal to 1");
            
        RuleFor(response => response.PageSize)
            .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100");
            
        RuleFor(response => response.TotalPages)
            .GreaterThanOrEqualTo(0).WithMessage("Total pages must be non-negative");
            
        RuleFor(response => response.TotalCourses)
            .GreaterThanOrEqualTo(0).WithMessage("Total courses must be non-negative");
    }
}

public class CourseItemValidator : Validator<CourseItem>
{
    public CourseItemValidator()
    {
        RuleFor(course => course.CourseID)
            .NotEmpty().WithMessage("Course ID cannot be empty");
            
        RuleFor(course => course.CourseCode)
            .NotEmpty().WithMessage("Course code cannot be empty")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters");
            
        RuleFor(course => course.CourseName)
            .NotEmpty().WithMessage("Course name cannot be empty")
            .MaximumLength(100).WithMessage("Course name cannot exceed 100 characters");
            
        RuleFor(course => course.Credits)
            .GreaterThan(0).WithMessage("Credits must be greater than 0");
            
        RuleFor(course => course.Department)
            .NotEmpty().WithMessage("Department cannot be empty");
            
        RuleFor(course => course.MaxCapacity)
            .GreaterThan(0).WithMessage("Max capacity must be greater than 0");
            
        RuleFor(course => course.EnrollmentCount)
            .GreaterThanOrEqualTo(0).WithMessage("Enrollment count must be non-negative")
            .LessThanOrEqualTo(course => course.MaxCapacity)
            .WithMessage("Enrollment count cannot exceed max capacity");
    }
}