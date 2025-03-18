using FastEndpoints;
using FluentValidation;
using iSchool_Solution.Enums;
using static iSchool_Solution.Features.Grade.GetSemester.Models;

namespace iSchool_Solution.Features.Grade.GetSemester;

public class ResponseValidator : Validator<SemesterGradesResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.SemesterGPA)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(4.0)
            .WithMessage("Semester GPA must be a non-negative value and within a reasonable range.");

        RuleFor(x => x.CreditsAttempted)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Credits Attempted must be a non-negative integer.");

        RuleFor(x => x.CreditsEarned)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Credits Earned must be a non-negative integer.")
            .LessThanOrEqualTo(x => x.CreditsAttempted)
            .WithMessage("Credits Earned cannot exceed Credits Attempted.");

        RuleFor(x => x.Grades)
            .NotNull()
            .WithMessage("Grades list cannot be null.")
            .ForEach(grade =>
            {
                grade.SetValidator(new CourseGradeInfoValidator()); // Apply validator for each CourseGradeInfo in the list
            });
    }
}

public class CourseGradeInfoValidator : Validator<CourseGradeInfo>
{
    public CourseGradeInfoValidator()
    {
        RuleFor(x => x.GradeID)
            .NotEmpty()
            .WithMessage("Grade ID is required and cannot be empty.");

        RuleFor(x => x.CourseID)
            .NotEmpty()
            .WithMessage("Course ID is required and cannot be empty.");

        RuleFor(x => x.CourseCode)
            .NotEmpty()
            .NotNull()
            .WithMessage("Course Code is required.")
            .MaximumLength(20)
            .WithMessage("Course Code cannot exceed 20 characters.");

        RuleFor(x => x.CourseName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Course Name is required.")
            .MaximumLength(100)
            .WithMessage("Course Name cannot exceed 100 characters.");

        RuleFor(x => x.Credits)
            .GreaterThan(0)
            .WithMessage("Credits must be a positive integer.");

        RuleFor(x => x.Grade)
            .IsInEnum() // Validate that Grade is a valid GradeLetter enum value
            .WithMessage("Grade must be a valid Grade Letter.");

        RuleFor(x => x.GradePoints)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Grade Points must be a non-negative value.")
            .Custom((points, context) => // Custom validation for GradePoints consistency
            {
                var gradeLetter = context.InstanceToValidate.Grade; // Get the GradeLetter enum directly

                if (gradeLetter.IsIncludedInGPA()) // Only check GradePoints for GPA-included grades
                {
                    double expectedGradePoints = gradeLetter.GetGradePoints();
                    if (Math.Abs(points - expectedGradePoints) > 0.001) // Allow small floating-point tolerance
                    {
                        context.AddFailure($"Grade Points for '{gradeLetter}' ({gradeLetter.ToString()}) should be approximately {expectedGradePoints}.");
                    }
                }
                // TODO: Check if validation for non-GPA grades (P, NP, I, W, NA) is needed
            });


        RuleFor(x => x.Remarks)
            .MaximumLength(200)
            .WithMessage("Remarks cannot exceed 200 characters.");
    }
}