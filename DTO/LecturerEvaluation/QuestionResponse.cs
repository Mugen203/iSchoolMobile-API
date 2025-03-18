namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record QuestionResponse
{
    public int QuestionID { get; init; }
    public int? Rating { get; init; }
    public string TextResponse { get; init; } = string.Empty;
    public string SelectedOption { get; init; } = string.Empty;
}