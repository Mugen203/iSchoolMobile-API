using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.GetSchedule.Models;

namespace iSchool_Solution.Features.Courses.GetSchedule;

public class ResponseValidator : Validator<ScheduleResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.Courses)
            .NotNull().WithMessage("Course list cannot be null")
            .ForEach(course => course.SetValidator(new ScheduledCourseInfoValidator()));
    }
    
    public class ScheduledCourseInfoValidator : Validator<ScheduledCourseInfo>
    {
        public ScheduledCourseInfoValidator()
        {
            RuleFor(course => course.CourseID)
                .NotEmpty().WithMessage("Course ID cannot be empty");
            
            RuleFor(request => request.CourseCode)
                .NotNull().WithMessage("Course code cannot be null")
                .NotEmpty().WithMessage("Course code must be provided")
                .MaximumLength(20).WithMessage("Course code cannot exceed 20 characters")
                .Matches(@"^[A-Z0-9]{2,10}$").WithMessage("Course code must be in a valid format (e.g., CS101)");
            
            RuleFor(course => course.CourseName)
                .NotEmpty().WithMessage("Course name cannot be empty");
            
            RuleFor(course => course.Day)
                .IsInEnum().WithMessage("Day must be a valid day of week");
            
            RuleFor(course => course.StartTime)
                .NotEmpty().WithMessage("Start time cannot be empty");
            
            RuleFor(course => course.EndTime)
                .NotEmpty().WithMessage("End time cannot be empty");
            
            RuleFor(course => course.Location)
                .NotEmpty().WithMessage("Location cannot be empty");
            
            RuleFor(course => course.LecturerName)
                .NotEmpty().WithMessage("Lecturer name cannot be empty");
        }
    }
}