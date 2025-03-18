using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Academics.GetAcademicProgress.Models;

namespace iSchool_Solution.Features.Academics.GetAcademicProgress;

public class ResponseValidator : Validator<AcademicSummaryResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.CumulativeGPA)
            .NotNull().WithMessage("Cumulative GPA cannot be null")
            .InclusiveBetween(0.0, 4.0).WithMessage("Cumulative GPA must be between 0.0 and 4.0");

        RuleFor(response => response.CreditsAttempted)
            .NotNull().WithMessage("Credits Attempted cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Credits Attempted cannot be negative");

        RuleFor(response => response.CreditsEarned)
            .NotNull().WithMessage("Credits Earned cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Credits Earned cannot be negative");

        RuleFor(response => response.AcademicStanding)
            .IsInEnum().WithMessage("Academic Standing must be a valid value"); // Validate if it's an enum

        RuleFor(response => response.Semesters)
            .NotNull().WithMessage("Semesters list cannot be null")
            .NotEmpty().WithMessage("Semesters list cannot be empty")
            .ForEach(semester => semester.SetValidator(new SemesterProgressInfoValidator())); // Validate each SemesterProgressInfo in the list
    }

    public class SemesterProgressInfoValidator : Validator<SemesterProgressInfo>
    {
        public SemesterProgressInfoValidator()
        {
            RuleFor(semester => semester.SemesterName)
                .NotEmpty().WithMessage("Semester Name is required.");

            RuleFor(semester => semester.StartDate)
                .NotNull().WithMessage("Start Date is required.");

            RuleFor(semester => semester.EndDate)
                .NotNull().WithMessage("End Date is required.");

            RuleFor(semester => semester.SemesterGPA)
                .NotNull().WithMessage("Semester GPA cannot be null")
                .InclusiveBetween(0.0, 4.0).WithMessage("Semester GPA must be between 0.0 and 4.0");

            RuleFor(semester => semester.CreditsAttemptedThisSemester) // Updated to use CreditsAttemptedThisSemester
                .NotNull().WithMessage("Credits Attempted this semester cannot be null")
                .GreaterThanOrEqualTo(0).WithMessage("Credits Attempted this semester cannot be negative");

            RuleFor(semester => semester.CreditsEarnedThisSemester) // Added validation for CreditsEarnedThisSemester
                .NotNull().WithMessage("Credits Earned this semester cannot be null")
                .GreaterThanOrEqualTo(0).WithMessage("Credits Earned this semester cannot be negative");


            RuleFor(semester => semester.Courses)
                .NotNull().WithMessage("Courses list cannot be null")
                .NotEmpty().WithMessage("Courses list cannot be empty")
                .ForEach(course => course.SetValidator(new CourseProgressInfoValidator())); // Validate each CourseProgressInfo
        }
    }

    public class CourseProgressInfoValidator : Validator<CourseProgressInfo>
    {
        public CourseProgressInfoValidator()
        {
            RuleFor(course => course.CourseID)
                .NotEmpty().WithMessage("Course ID is required.")
                .NotNull().WithMessage("Course ID cannot be null.");

            RuleFor(course => course.CourseCode)
                .NotEmpty().WithMessage("Course Code is required.");

            RuleFor(course => course.CourseName)
                .NotEmpty().WithMessage("Course Name is required.");

            RuleFor(course => course.Credits)
                .NotNull().WithMessage("Credits cannot be null.")
                .GreaterThan(0).WithMessage("Credits must be greater than zero.");

            RuleFor(course => course.CurrentGrade)
                .NotEmpty().WithMessage("Current Grade is required.");
        }
    }
}