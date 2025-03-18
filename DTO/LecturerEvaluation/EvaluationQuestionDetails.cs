using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record EvaluationQuestionDetails( 
    int Id,
    string QuestionText,
    string Category,
    int DisplayOrder,
    bool IsActive,
    QuestionType QuestionType,
    string PossibleAnswers 
);