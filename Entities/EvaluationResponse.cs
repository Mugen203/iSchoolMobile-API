using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class EvaluationResponse
{
    
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(LecturerEvaluation))]
    public int LecturerEvaluationID { get; set; }
    
    public LecturerEvaluation Evaluation { get; set; }

    [ForeignKey(nameof(EvaluationQuestion))]
    public int EvaluationQuestionID { get; set; }

    public EvaluationQuestion Question { get; set; }

    public int? RatingValue { get; set; } // 1-5 rating or null

    public string? TextResponse { get; set; } // For text-based answers

    public string? SelectedOption { get; set; } // For multi-choice questions
    
}