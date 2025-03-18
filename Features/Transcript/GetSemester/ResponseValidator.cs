using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Transcript.GetSemester.Models;

namespace iSchool_Solution.Features.Transcript.GetSemester;

public class ResponseValidator : Validator<SemesterTranscriptResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.SemesterRecordID)
            .NotNull().WithMessage("SemesterRecordID cannot be null");

        RuleFor(response => response.SemesterName)
            .NotNull().WithMessage("SemesterName cannot be null")
            .NotEmpty().WithMessage("SemesterName cannot be empty");

        RuleFor(response => response.AcademicYear)
            .NotEmpty().WithMessage("AcademicYear cannot be empty")
            .NotNull().WithMessage("AcademicYear cannot be null");

        RuleFor(response => response.SemesterGPA)
            .NotNull().WithMessage("SemesterGPA cannot be null")
            .InclusiveBetween(0.0, 4.0).WithMessage("GPA must be between 0.0 and 4.0");

        RuleFor(response => response.SemesterCredits)
            .NotNull().WithMessage("SemesterCredits cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("SemesterCredits cannot be negative");

        RuleFor(response => response.SemesterStanding)
            .NotEmpty().WithMessage("SemesterStanding cannot be empty");

        RuleFor(response => response.Courses)
            .NotNull().WithMessage("Courses cannot be null")
            .NotEmpty().WithMessage("Courses cannot be empty");
        // .ForEach(v => v.SetValidator(new TranscriptCourseInfoValidator())); validate each item in the list
    }
}