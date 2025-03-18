using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedEvaluationResponses
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<EvaluationResponse>().HasData(
            // Responses for Lecturer Evaluation ID 1 (Example LecturerEval)

            // **Teaching Method Category** (Questions 1 & 2)
            new EvaluationResponse // Response to "How would you rate the teaching methods...?" (Question ID 1)
            {
                Id = 1,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 1,
                RatingValue = 4, // Rating of 4 out of 5
                TextResponse = null, // Not a text question
                SelectedOption = "4" // Selected option from PossibleAnswers
            },
            new EvaluationResponse // Response to "Were the course materials...helpful?" (Question ID 2)
            {
                Id = 2,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 2,
                RatingValue = 5, // Rating of 5 out of 5
                TextResponse = null,
                SelectedOption = "5"
            },

            // **Lecturer Effectiveness Category** (Question 3)
            new EvaluationResponse // Response to "How effective was the lecturer in explaining...?" (Question ID 3)
            {
                Id = 3,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 3,
                RatingValue = 5,
                TextResponse = null,
                SelectedOption = "5"
            },

            // **Interaction and Engagement Category** (Question 4)
            new EvaluationResponse // Response to "The lecturer encouraged student participation..." (Question ID 4)
            {
                Id = 4,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 4,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "Agree" // Selected "Agree" from Likert scale
            },

            // **Class Management Category** (Question 5)
            new EvaluationResponse // Response to "How well did the lecturer manage class time?" (Question ID 5)
            {
                Id = 5,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 5,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "Well" // Selected "Well" from descriptive scale
            },

            // **Lecturer Knowledge Category** (Questions 6 & 7)
            new EvaluationResponse // Response to "How knowledgeable was the lecturer...?" (Question ID 6)
            {
                Id = 6,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 6,
                RatingValue = 5,
                TextResponse = null,
                SelectedOption = "5"
            },
            new EvaluationResponse // Response to "The lecturer demonstrated a clear understanding..." (Question ID 7)
            {
                Id = 7,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 7,
                RatingValue = 5,
                TextResponse = null,
                SelectedOption = "Strongly Agree" // Selected "Strongly Agree" from Likert scale
            },

            // **Course Organization Category** (Question 8)
            new EvaluationResponse // Response to "How well was the course content organized?" (Question ID 8)
            {
                Id = 8,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 8,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "4"
            },

            // **Course Objectives Category** (Question 9)
            new EvaluationResponse // Response to "The learning objectives...were clearly communicated." (Question ID 9)
            {
                Id = 9,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 9,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "Agree" // Selected "Agree" from Likert scale
            },

            // **Assessment Fairness Category** (Question 10)
            new EvaluationResponse // Response to "How fair and relevant were assessment methods...?" (Question ID 10)
            {
                Id = 10,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 10,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "4"
            },

            // **Feedback Usefulness Category** (Question 11)
            new EvaluationResponse // Response to "The feedback provided on assignments was helpful..." (Question ID 11)
            {
                Id = 11,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 11,
                RatingValue = 3, // Example of a neutral/lower rating
                TextResponse = null,
                SelectedOption = "Neutral" // Selected "Neutral" from Likert scale
            },

            // **Overall Experience Category** (Questions 12 & 13 - Text Responses)
            new EvaluationResponse // Response to "What are the strengths of this lecturer/course?" (Question ID 12)
            {
                Id = 12,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 12,
                RatingValue = null, // Not a rating question
                TextResponse =
                    "The lecturer is very enthusiastic and knowledgeable. The course content was relevant and up-to-date.",
                SelectedOption = null // Not a selected option
            },
            new EvaluationResponse // Response to "What are some areas for improvement...?" (Question ID 13)
            {
                Id = 13,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 13,
                RatingValue = null, // Not a rating question
                TextResponse = "More practical examples and real-world case studies could be incorporated.",
                SelectedOption = null
            },

            // **Overall Satisfaction Category** (Question 14)
            new EvaluationResponse // Response to "Overall, how satisfied were you...?" (Question ID 14)
            {
                Id = 14,
                LecturerEvaluationID = 1,
                EvaluationQuestionID = 14,
                RatingValue = 4,
                TextResponse = null,
                SelectedOption = "Satisfied" // Selected "Satisfied" from Satisfaction scale
            }
        );
    }
}