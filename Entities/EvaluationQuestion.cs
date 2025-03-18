using System.ComponentModel.DataAnnotations;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class EvaluationQuestion
{
    public EvaluationQuestion()
    {
        Responses = new List<EvaluationResponse>();
    }

    [Key] public int Id { get; set; }

    public string QuestionText { get; set; }
    
    public QuestionCategory Category { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    public QuestionType QuestionType { get; set; }

    public string PossibleAnswers { get; set; } // JSON array of options for multiple choice

    // Navigation property
    public virtual IList<EvaluationResponse> Responses { get; set; }
}