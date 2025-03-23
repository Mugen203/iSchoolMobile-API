using FastEndpoints;
using FluentValidation;
using iSchool_Solution.Features.Transcript.GetSemester;

public class RequestValidator : Validator<Models.SemesterTranscriptRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.StudentID)
            .NotEmpty().WithMessage("Student ID is required");

        RuleFor(request => request.AcademicYear)
            .NotEmpty().WithMessage("Academic year is required")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("Academic year must be in format YYYY-YYYY");

        RuleFor(request => request.Semester)
            .IsInEnum().WithMessage("Semester must be a valid value (September or January)");
    }
}