using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record SubmitEvaluation
{
    [Required(ErrorMessage = "LecturerID is required")]
    public string LecturerID { get; init; } = string.Empty;

    [Required(ErrorMessage = "CourseID is required")]
    public Guid CourseID { get; init; }

    [Required(ErrorMessage = "EvaluationPeriodID is required")]
    public int EvaluationPeriodID { get; init; }

    public string Comments { get; init; } = string.Empty;

    [Required(ErrorMessage = "Responses are required")]
    [MinLength(1, ErrorMessage = "At least one response is required")] // Example validation on list
    public List<QuestionResponse> Responses { get; init; } = new();
}