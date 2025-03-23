using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Courses.Conflicts.Models;

namespace iSchool_Solution.Features.Courses.Conflicts;

public class ResponseValidator : Validator<ScheduleConflictResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.HasConflicts)
            .NotNull().WithMessage("HasConflicts flag must be specified");
            
        RuleFor(response => response.Conflicts)
            .NotNull().WithMessage("Conflicts list cannot be null")
            .ForEach(conflict => conflict.SetValidator(new ScheduleConflictValidator()));
    }
}

public class ScheduleConflictValidator : Validator<ScheduleConflict>
{
    public ScheduleConflictValidator()
    {
        RuleFor(conflict => conflict.ConflictingCourseCode)
            .NotEmpty().WithMessage("Conflicting course code must be specified");
            
        RuleFor(conflict => conflict.ConflictingCourseName)
            .NotEmpty().WithMessage("Conflicting course name must be specified");
            
        RuleFor(conflict => conflict.ConflictDay)
            .IsInEnum().WithMessage("Conflict day must be a valid day of week");
            
        RuleFor(conflict => conflict.ConflictTime)
            .NotEmpty().WithMessage("Conflict time must be specified");
    }
}