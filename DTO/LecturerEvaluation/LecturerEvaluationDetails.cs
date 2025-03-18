namespace iSchool_Solution.Entities.DTO.LecturerEvaluation;

public record LecturerEvaluationDetails(
    int EvaluationRecordID,
    EvaluationPeriodSummary EvaluationPeriod,
    CourseSummaryForEvaluation Course,
    LecturerSummaryForEvaluation Lecturer,
    DateTimeOffset SubmissionDate,
    string Comments,
    List<EvaluationQuestionResponseDetails> Responses
);