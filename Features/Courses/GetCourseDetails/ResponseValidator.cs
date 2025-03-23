using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetCourseDetails.Models;

namespace iSchool_Solution.Features.Courses.GetCourseDetails;

public class ResponseValidator : Validator<CourseDetailsResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.CourseID)
            .NotEmpty().WithMessage("Course ID cannot be empty");
            
        RuleFor(response => response.CourseCode)
            .NotEmpty().WithMessage("Course code cannot be empty")
            .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters");
            
        RuleFor(response => response.CourseName)
            .NotEmpty().WithMessage("Course name cannot be empty")
            .MaximumLength(100).WithMessage("Course name cannot exceed 100 characters");
            
        RuleFor(response => response.Credits)
            .GreaterThan(0).WithMessage("Credits must be greater than 0");
            
        RuleFor(response => response.Department)
            .NotEmpty().WithMessage("Department cannot be empty");
            
        RuleFor(response => response.Lecturers)
            .NotNull().WithMessage("Lecturers list cannot be null")
            .ForEach(lecturer => lecturer.SetValidator(new LecturerInfoValidator()));
            
        RuleFor(response => response.Schedule)
            .NotNull().WithMessage("Schedule list cannot be null")
            .ForEach(item => item.SetValidator(new ScheduleItemValidator()));
    }
}

public class LecturerInfoValidator : Validator<LecturerInfo>
{
    public LecturerInfoValidator()
    {
        RuleFor(lecturer => lecturer.LecturerID)
            .NotEmpty().WithMessage("Lecturer ID cannot be empty");
            
        RuleFor(lecturer => lecturer.Name)
            .NotEmpty().WithMessage("Lecturer name cannot be empty");
            
        RuleFor(lecturer => lecturer.Email)
            .NotEmpty().WithMessage("Lecturer email cannot be empty")
            .EmailAddress().WithMessage("Invalid email format");
    }
}

public class ScheduleItemValidator : Validator<ScheduleItem>
{
    public ScheduleItemValidator()
    {
        RuleFor(item => item.Day)
            .IsInEnum().WithMessage("Day must be a valid day of week");
            
        RuleFor(item => item.StartTime)
            .NotEmpty().WithMessage("Start time cannot be empty");
            
        RuleFor(item => item.EndTime)
            .NotEmpty().WithMessage("End time cannot be empty");
            
        RuleFor(item => item.Location)
            .IsInEnum().WithMessage("Location must be a valid location type");
    }
}