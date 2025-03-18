using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedEvaluationQuestions
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<EvaluationQuestion>().HasData(
            // Teaching Method Category
            new EvaluationQuestion
            {
                Id = 1,
                QuestionText = "How would you rate the teaching methods used in this course?",
                Category = QuestionCategory.TeachingMethod,
                DisplayOrder = 1,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 2,
                QuestionText =
                    "Were the course materials (handouts, slides, online resources) helpful for your learning?",
                Category = QuestionCategory.CourseMaterial,
                DisplayOrder = 2,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 3,
                QuestionText = "How effective was the lecturer in explaining difficult concepts?",
                Category = QuestionCategory.LecturerEffectiveness,
                DisplayOrder = 3,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 4,
                QuestionText = "The lecturer encouraged student participation and questions.",
                Category = QuestionCategory.InteractionAndEngagement,
                DisplayOrder = 4,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]" // Example Likert scale
            },
            new EvaluationQuestion
            {
                Id = 5,
                QuestionText = "How well did the lecturer manage the class time?",
                Category = QuestionCategory.ClassManagement,
                DisplayOrder = 5,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Poorly\", \"Fairly\", \"Moderately\", \"Well\", \"Very Well\"]" // Example descriptive scale
            },

            // Lecturer Knowledge and Expertise Category
            new EvaluationQuestion
            {
                Id = 6,
                QuestionText = "How knowledgeable was the lecturer in the subject matter?",
                Category = QuestionCategory.LecturerKnowledge,
                DisplayOrder = 6,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 7,
                QuestionText = "The lecturer demonstrated a clear understanding of the course content.",
                Category = QuestionCategory.LecturerKnowledge,
                DisplayOrder = 7,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]" // Example Likert scale
            },

            // Course Content and Organization Category
            new EvaluationQuestion
            {
                Id = 8,
                QuestionText = "How well was the course content organized?",
                Category = QuestionCategory.CourseOrganization,
                DisplayOrder = 8,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 9,
                QuestionText = "The learning objectives of the course were clearly communicated.",
                Category = QuestionCategory.CourseObjectives,
                DisplayOrder = 9,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]" // Example Likert scale
            },

            // Assessment and Feedback Category
            new EvaluationQuestion
            {
                Id = 10,
                QuestionText = "How fair and relevant were the assessment methods used in this course?",
                Category = QuestionCategory.AssessmentFairness,
                DisplayOrder = 10,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers = "[\"1\", \"2\", \"3\", \"4\", \"5\"]" // Example Rating scale
            },
            new EvaluationQuestion
            {
                Id = 11,
                QuestionText = "The feedback provided on assignments was helpful for my learning.",
                Category = QuestionCategory.FeedbackUsefulness,
                DisplayOrder = 11,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]" // Example Likert scale
            },

            // Overall Satisfaction Category - Open Text Question
            new EvaluationQuestion
            {
                Id = 12,
                QuestionText = "What are the strengths of this lecturer/course?",
                Category = QuestionCategory.OverallExperience,
                DisplayOrder = 12,
                IsActive = true,
                QuestionType = QuestionType.Text, // Open text for detailed feedback
                PossibleAnswers = "[]" // Empty array for text questions
            },
            new EvaluationQuestion
            {
                Id = 13,
                QuestionText = "What are some areas for improvement for this lecturer/course?",
                Category = QuestionCategory.OverallExperience,
                DisplayOrder = 13,
                IsActive = true,
                QuestionType = QuestionType.Text, // Open text for suggestions
                PossibleAnswers = "[]" // Empty array for text questions
            },
            new EvaluationQuestion
            {
                Id = 14,
                QuestionText = "Overall, how satisfied were you with this course and lecturer?",
                Category = QuestionCategory.OverallSatisfaction,
                DisplayOrder = 14,
                IsActive = true,
                QuestionType = QuestionType.Rating,
                PossibleAnswers =
                    "[\"Very Dissatisfied\", \"Dissatisfied\", \"Neutral\", \"Satisfied\", \"Very Satisfied\"]" // Example Satisfaction scale
            }
        );
    }
}