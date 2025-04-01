using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Evaluation.Submit.Models;

namespace iSchool_Solution.Features.Evaluation.Submit;

public class RequestValidator : Validator<SubmitEvaluationRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.LecturerID)
            .NotEmpty().WithMessage("Lecturer ID is required.");

        RuleFor(x => x.CourseID)
            .NotEmpty().WithMessage("Course ID is required.");

        RuleFor(x => x.EvaluationPeriodID)
            .GreaterThan(0).WithMessage("Evaluation Period ID must be valid.");

        RuleFor(x => x.Responses)
            .NotEmpty().WithMessage("At least one evaluation response is required.")
            .ForEach(responseRule => { responseRule.SetValidator(new QuestionResponseValidator()); });

        RuleFor(x => x.Comments)
            .MaximumLength(1000).WithMessage("Comments cannot exceed 1000 characters.");
    }
}

public class QuestionResponseValidator : Validator<QuestionResponse>
{
    public QuestionResponseValidator()
    {
        RuleFor(x => x.QuestionID)
            .GreaterThan(0).WithMessage("Question ID must be valid.");

        // Ensure either RatingValue OR TextResponse is provided, but not necessarily both
        // More complex validation might be needed based on the actual QuestionType (fetched later in service)
        RuleFor(x => x.RatingValue)
            .InclusiveBetween(1, 5).When(r => r.RatingValue.HasValue)
            .WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.TextResponse)
            .MaximumLength(500).When(r => !string.IsNullOrEmpty(r.TextResponse))
            .WithMessage("Text response cannot exceed 500 characters.");

        // Add rule for SelectedOption if using multiple choice or storing rating string
        RuleFor(x => x.SelectedOption)
            .MaximumLength(100).When(r => !string.IsNullOrEmpty(r.SelectedOption))
            .WithMessage("Selected option cannot exceed 100 characters.");
    }
}