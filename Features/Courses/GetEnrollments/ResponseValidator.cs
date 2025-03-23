using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetEnrollments.Models;

namespace iSchool_Solution.Features.Courses.GetEnrollments;

public class ResponseValidator : Validator<EnrollmentsResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.StudentID)
            .NotEmpty().WithMessage("Student ID cannot be empty");
            
        RuleFor(response => response.Semester)
            .NotEmpty().WithMessage("Semester cannot be empty");
            
        RuleFor(response => response.AcademicYear)
            .NotEmpty().WithMessage("Academic year cannot be empty")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("Academic year must be in format YYYY-YYYY");
            
        RuleFor(response => response.Enrollments)
            .NotNull().WithMessage("Enrollments list cannot be null")
            .ForEach(enrollment => enrollment.SetValidator(new EnrollmentItemValidator()));
            
        RuleFor(response => response.TotalCredits)
            .GreaterThanOrEqualTo(0).WithMessage("Total credits must be non-negative");
            
        RuleFor(response => response.TotalCourses)
            .GreaterThanOrEqualTo(0).WithMessage("Total courses must be non-negative");
            
        RuleFor(response => response.TotalFees)
            .GreaterThanOrEqualTo(0).WithMessage("Total fees must be non-negative");
    }
}

public class EnrollmentItemValidator : Validator<EnrollmentItem>
{
    public EnrollmentItemValidator()
    {
        RuleFor(item => item.CourseID)
            .NotEmpty().WithMessage("Course ID cannot be empty");
            
        RuleFor(request => request.CourseCode)
            .NotNull().WithMessage("Course code cannot be null")
            .NotEmpty().WithMessage("Course code must be provided")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
            .Matches(@"^[A-Z0-9]{2,10}$").WithMessage("Course code must be in a valid format (e.g., CS101)");
            
        RuleFor(item => item.CourseName)
            .NotEmpty().WithMessage("Course name cannot be empty");
            
        RuleFor(item => item.Credits)
            .GreaterThan(0).WithMessage("Credits must be greater than 0");
            
        RuleFor(item => item.Department)
            .NotEmpty().WithMessage("Department cannot be empty");
            
        RuleFor(item => item.EnrollmentDate)
            .NotEmpty().WithMessage("Enrollment date cannot be empty");
            
        RuleFor(item => item.Status)
            .IsInEnum().WithMessage("Status must be a valid enrollment status");
            
        RuleFor(item => item.Schedule)
            .NotNull().WithMessage("Schedule cannot be null")
            .ForEach(schedule => schedule.SetValidator(new ScheduleInfoValidator()));
            
        RuleFor(item => item.Lecturer)
            .NotNull().WithMessage("Lecturer information cannot be null")
            .SetValidator(new LecturerInfoValidator());
            
        RuleFor(item => item.CourseFee)
            .GreaterThanOrEqualTo(0).WithMessage("Course fee must be non-negative");
    }
}

public class ScheduleInfoValidator : Validator<ScheduleInfo>
{
    public ScheduleInfoValidator()
    {
        RuleFor(info => info.Day)
            .NotEmpty().WithMessage("Day cannot be empty");
            
        RuleFor(info => info.Time)
            .NotEmpty().WithMessage("Time cannot be empty");
            
        RuleFor(info => info.Location)
            .IsInEnum().WithMessage("Location must be a valid location type");
    }
}

public class LecturerInfoValidator : Validator<LecturerInfo>
{
    public LecturerInfoValidator()
    {
        RuleFor(info => info.Name)
            .NotEmpty().WithMessage("Lecturer name cannot be empty");
            
        RuleFor(info => info.Email)
            .NotEmpty().WithMessage("Lecturer email cannot be empty")
            .EmailAddress().WithMessage("Invalid email format");
    }
}