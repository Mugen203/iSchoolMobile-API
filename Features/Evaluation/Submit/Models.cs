namespace iSchool_Solution.Features.Evaluation.Submit;

public class Models
{
    public class SubmitEvaluationRequest
    {
        public string LecturerID { get; init; } = string.Empty;

        public Guid CourseID { get; init; }
        
        public int EvaluationPeriodID { get; init; }

        public string? Comments { get; init; } // Nullable if comments are optional
        
        public List<QuestionResponse> Responses { get; init; } = new();
    }
    
    public class QuestionResponse
    {
        public int QuestionID { get; init; }
        public int? RatingValue { get; init; } // Nullable for text responses
        public string? TextResponse { get; init; } // Nullable for rating responses
        public string? SelectedOption { get; init; } // For multiple choice (if used) or storing rating string
    }

    // Simple response for confirmation
    public class SubmitEvaluationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int? EvaluationId { get; set; } // Return the ID of the created evaluation
    }
}