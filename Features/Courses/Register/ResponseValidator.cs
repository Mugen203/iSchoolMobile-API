using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Features.Courses.Register;

public class ResponseValidator : Validator<RegistrationReceiptResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.ReceiptID)
            .NotEmpty().WithMessage("Receipt ID cannot be empty");
            
        RuleFor(response => response.RegistrationDate)
            .NotEmpty().WithMessage("Registration date cannot be empty");

        RuleFor(response => response.StudentID)
            .NotEmpty()
            .WithMessage("StudentID is required")
            .MinimumLength(10)
            .WithMessage("StudentID must be at least 13 characters long");
            
        RuleFor(response => response.RegisteredCourses)
            .NotNull().WithMessage("Registered courses list cannot be null")
            .NotEmpty().WithMessage("At least one course must be registered")
            .ForEach(course => course.SetValidator(new RegisteredCourseDetailsValidator()));
            
        RuleFor(response => response.TotalFees)
            .GreaterThanOrEqualTo(0).WithMessage("Total fees must be non-negative");
            
        RuleFor(response => response.PaymentStatus)
            .IsInEnum().WithMessage("Payment status must be a valid status");
    }
}

public class RegisteredCourseDetailsValidator : Validator<RegisteredCourseDetails>
{
    public RegisteredCourseDetailsValidator()
    {
        RuleFor(course => course.CourseCode)
            .NotEmpty().WithMessage("Course code cannot be empty");
            
        RuleFor(course => course.CourseName)
            .NotEmpty().WithMessage("Course name cannot be empty");
            
        RuleFor(course => course.Credits)
            .GreaterThan(0).WithMessage("Credits must be greater than 0");
            
        RuleFor(course => course.CourseFee)
            .GreaterThanOrEqualTo(0).WithMessage("Course fee must be non-negative");
    }
}