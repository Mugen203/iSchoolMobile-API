using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Features.Transcript.Get;

public class ResponseValidator : Validator<TranscriptSummaryResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.TranscriptID)
            .NotNull().WithMessage("Transcript ID cannot be null");

        RuleFor(response => response.CummulativeGPA)
            .NotNull().WithMessage("GPA cannot be null")
            .InclusiveBetween(0.0, 4.0).WithMessage("GPA must be between 0.0 and 4.0");

        RuleFor(response => response.TotalCreditsEarned)
            .NotNull().WithMessage("Credits earned cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Credits earned cannot be negative");

        RuleFor(response => response.CreditsAttempted)
            .NotNull().WithMessage("Credits attempted cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Credits attempted cannot be negative");

        RuleFor(response => response.AcademicStanding)
            .NotEmpty().WithMessage("Academic standing cannot be empty");

        RuleFor(response => response.RemainingRequiredCredits)
            .NotNull().WithMessage("Remaining required credits cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Remaining required credits cannot be negative");

        RuleFor(response => response.LastSemesterGPA)
            .NotNull().WithMessage("Last semester GPA cannot be null")
            .InclusiveBetween(0.0, 4.0).WithMessage("Last semester GPA must be between 0.0 and 4.0");

        RuleFor(response => response.CanRequestOfficialTranscript)
            .NotNull().WithMessage("Can request official transcript cannot be null");

        RuleFor(response => response.Semesters)
            .NotNull().WithMessage("Semesters cannot be null")
            .NotEmpty().WithMessage("Semesters cannot be empty");
        // .ForEach(v => v.SetValidator(new SemesterSummaryInfoValidator())); validate each item in the list
    }

    public class SemesterSummaryInfoValidator : Validator<SemesterSummaryInfo>
    {
        public SemesterSummaryInfoValidator()
        {
            RuleFor(semester => semester.SemesterRecordID)
                .NotNull().WithMessage("Semester Record ID cannot be null");

            RuleFor(semester => semester.Semester)
                .NotEmpty().WithMessage("Semester cannot be empty");

            RuleFor(semester => semester.StartDate)
                .NotEmpty()
                .WithMessage("Start Date cannot be empty"); // Consider .NotNull() if DateTimeOffset is non-nullable

            RuleFor(semester => semester.EndDate)
                .NotEmpty()
                .WithMessage("End Date cannot be empty"); // Consider .NotNull() if DateTimeOffset is non-nullable

            RuleFor(semester => semester.SemesterGPA)
                .NotNull().WithMessage("Semester GPA cannot be null")
                .InclusiveBetween(0.0, 4.0).WithMessage("Semester GPA must be between 0.0 and 4.0");

            RuleFor(semester => semester.Credits)
                .NotNull().WithMessage("Credits cannot be null")
                .GreaterThanOrEqualTo(0).WithMessage("Credits cannot be negative");

            RuleFor(semester => semester.Grades)
                .NotNull().WithMessage("Grades list cannot be null")
                .NotEmpty().WithMessage("Grades list cannot be empty")
                .ForEach(grade =>
                    grade.SetValidator(
                        new TranscriptCourseInfoValidator())); // Validate each item in the list using TranscriptCourseInfoValidator
        }
    }

    public class TranscriptCourseInfoValidator : Validator<TranscriptCourseInfo>
    {
        public TranscriptCourseInfoValidator()
        {
            RuleFor(course => course.CourseCode)
                .NotEmpty().WithMessage("Course Code cannot be empty");

            RuleFor(course => course.CourseName)
                .NotEmpty().WithMessage("Course Name cannot be empty");

            RuleFor(course => course.Credits)
                .NotNull().WithMessage("Credits cannot be null")
                .GreaterThan(0).WithMessage("Credits must be greater than 0");

            RuleFor(course => course.Grade)
                .NotEmpty().WithMessage("Grade cannot be empty");

            RuleFor(course => course.GradePoints)
                .NotNull().WithMessage("Grade Points cannot be null");
        }
    }
}