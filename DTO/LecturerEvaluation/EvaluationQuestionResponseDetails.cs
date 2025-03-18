namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record EvaluationQuestionResponseDetails(
    int QuestionID,
    string QuestionText,
    string Category,
    string QuestionType,
    int? RatingValue,
    string TextResponse,
    string SelectedOption
);