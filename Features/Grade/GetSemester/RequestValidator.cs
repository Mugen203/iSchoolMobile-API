using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Grade.GetSemester.Models;

namespace iSchool_Solution.Features.Grade.GetSemester;

public class RequestValidator : Validator<SemesterGradesRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.Semester)
            .IsInEnum()
            .WithMessage("Semester must be a valid value (September or January)");

        RuleFor(x => x.AcademicYear)
            .NotEmpty().WithMessage("Academic year is required")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("Academic year must be in format YYYY-YYYY");
    }
}