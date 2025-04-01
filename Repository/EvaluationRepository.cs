using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Repository;

public class EvaluationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EvaluationRepository> _logger;

    public EvaluationRepository(ApplicationDbContext context, ILogger<EvaluationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<EvaluationPeriod?> GetEvaluationPeriodByIdAsync(int periodId)
    {
        return await _context.EvaluationPeriods.FindAsync(periodId);
    }

    public async Task<EvaluationQuestion?> GetEvaluationQuestionByIdAsync(int questionId)
    {
        // Consider including PossibleAnswers if validation needs it
        return await _context.EvaluationQuestions.FindAsync(questionId);
    }

    public async Task<bool> HasStudentSubmittedEvaluationAsync(string studentId, Guid courseId, string lecturerId,
        int periodId)
    {
        return await _context.LecturerEvaluations
            .AnyAsync(
                le => /* le.StudentID == studentId && // Add StudentID to LecturerEvaluation entity if needed for this check */
                    le.CourseID == courseId &&
                    le.LecturerID == lecturerId &&
                    le.EvaluationPeriodID == periodId);
    }

    public async Task AddLecturerEvaluationAsync(LecturerEvaluation evaluation)
    {
        _logger.LogInformation("Adding LecturerEvaluation to context. CourseID: {CourseID}, LecturerID: {LecturerID}",
            evaluation.CourseID, evaluation.LecturerID);
        // Note: This adds the main evaluation record AND its child EvaluationResponse records
        // because they should be part of the evaluation object's collection.
        await _context.LecturerEvaluations.AddAsync(evaluation);
    }

    // Optional: Method to get Lecturer if not handled elsewhere
    public async Task<Lecturer?> GetLecturerByIdAsync(string lecturerId)
    {
        return await _context.Lecturers.FindAsync(lecturerId);
    }
}