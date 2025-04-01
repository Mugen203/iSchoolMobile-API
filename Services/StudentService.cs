using FluentValidation;
using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Academics.GetAcademicProgress.Models;
using static iSchool_Solution.Features.Courses.Conflicts.Models;
using static iSchool_Solution.Features.Courses.GetSchedule.Models;
using static iSchool_Solution.Features.Courses.Register.Models;
using static iSchool_Solution.Features.Evaluation.Submit.Models;
using static iSchool_Solution.Features.Grade.GetSemester.Models;
using static iSchool_Solution.Features.Notifications.Common.Models;
using static iSchool_Solution.Features.Notifications.GetAnnouncements.Models;
using static iSchool_Solution.Features.Notifications.GetNotifications.Models;
using static iSchool_Solution.Features.Profile.Common.Models;
using static iSchool_Solution.Features.Transcript.Get.Models;
using static iSchool_Solution.Features.Grade.GetCurrent.Models;

namespace iSchool_Solution.Services;

public class StudentService
{
    private readonly StudentRepository _studentRepository;
    private readonly CourseRepository _courseRepository;
    private readonly CommunicationRepository _communicationRepository;
    private readonly TranscriptService _transcriptService;
    private readonly ILogger<StudentService> _logger;
    private readonly ApplicationDbContext _context;
    private readonly EvaluationRepository _evaluationRepository;

    public StudentService(
        StudentRepository studentRepository,
        CourseRepository courseRepository,
        ILogger<StudentService> logger,
        ApplicationDbContext context,
        CommunicationRepository communicationRepository,
        TranscriptService transcriptService,
        EvaluationRepository evaluationRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _communicationRepository = communicationRepository;
        _transcriptService = transcriptService;
        _logger = logger;
        _context = context;
        _evaluationRepository = evaluationRepository;
    }


    #region Profile Management

    /// <summary>
    /// Retrieves a student's profile by their ID
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>The student's profile information</returns>
    public async Task<ProfileResponse> GetStudentProfileAsync(string studentID)
    {
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);

        if (student == null) throw new StudentNotFoundException(studentID);

        var profile = new ProfileResponse
        {
            StudentID = student.StudentID,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            StudentEmail = student.StudentEmail,
            Address = student.Address,
            Degree = student.Degree,
            Gender = student.Gender,
            PhoneNumber = student.StudentPhone,
            StudentPhotoUrl = student.StudentPhotoUrl,
            AcademicAdvisor = student.AcademicAdvisor,
            EmergencyContactName = student.EmergencyContactName,
            EmergencyContactPhone = student.EmergencyContactPhone
        };

        return profile;
    }

    /// <summary>
    /// Updates a student's profile information
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="profileRequest">The updated profile information</param>
    /// <returns>The updated student profile</returns>
    public async Task<bool> UpdateStudentProfileAsync(string studentID, ProfileRequest profileRequest)
    {
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);

        if (student == null) throw new StudentNotFoundException(studentID);

        student.Address = profileRequest.Address;
        student.StudentPhone = profileRequest.PhoneNumber;
        student.StudentPhotoUrl = profileRequest.StudentPhotoUrl;
        student.EmergencyContactName = profileRequest.EmergencyContactName;
        student.EmergencyContactPhone = profileRequest.EmergencyContactPhone;

        await _studentRepository.UpdateStudentAsync(student);
        return true;
    }

    #endregion

    #region Academic Records

    /// <summary>
    /// Gets the academic records and transcript for a student
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>The student's academic transcript</returns>
    public async Task<TranscriptSummaryResponse> GetStudentTranscriptAsync(string studentID)
    {
        return await _transcriptService.GetStudentTranscriptAsync(studentID);
    }

    /// <summary>
    /// Gets the course grades for a specific semester
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="semester">The semester to get grades for</param>
    /// <param name="academicYear">The academic year</param>
    /// <returns>List of course grades</returns>
    public async Task<List<SemesterGradesResponse>> GetSemesterGradesAsync(string studentID, Semester semester,
        string academicYear)
    {
        var semesterRecord = await _context.SemesterRecords
            .Include(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(sr =>
                sr.StudentID == studentID &&
                sr.Semester == semester &&
                sr.AcademicYear == academicYear);

        if (semesterRecord == null) throw new SemesterRecordNotFoundException(studentID, academicYear, semester);

        semesterRecord.CalculateSemesterGPA();
        await _context.SaveChangesAsync();

        var gradesResponse = new List<SemesterGradesResponse>();
        var courseGradeInfoList = semesterRecord.Grades.Select(grade => new CourseGradeInfo
            {
                GradeID = grade.GradeID,
                CourseID = grade.CourseID,
                CourseCode = grade.Course.CourseCode,
                CourseName = grade.Course.CourseName,
                Credits = grade.Course.CourseCredits,
                Grade = grade.GradeLetter,
                GradePoints = grade.GradeLetter.GetGradePoints(),
                Remarks = grade.Remarks
            })
            .ToList();

        gradesResponse.Add(new SemesterGradesResponse
        {
            SemesterGPA = semesterRecord.SemesterGPA,
            CreditsAttempted = semesterRecord.CreditsAttempted,
            CreditsEarned = semesterRecord.CreditsEarned,
            Grades = courseGradeInfoList
        });

        return gradesResponse;
    }


    /// <summary>
    /// Gets a summary of the student's academic progress
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>Summary of academic progress</returns>
    public async Task<AcademicSummaryResponse> GetAcademicProgressSummaryAsync(string studentID)
    {
        var transcript = await _context.Transcripts
            .Include(t => t.SemesterRecords)
            .ThenInclude(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(t => t.StudentID == studentID);

        if (transcript == null) throw new TranscriptNotFoundException(studentID);

        await RecalculateTranscriptGPAAsync(transcript);

        await _context.SaveChangesAsync();


        var academicSummaryResponse = new AcademicSummaryResponse
        {
            CumulativeGPA = transcript.CummulativeGPA,
            CreditsAttempted = transcript.CreditsAttempted,
            CreditsEarned = transcript.CreditsEarned,
            AcademicStanding = transcript.AcademicStanding,
            Semesters = new List<SemesterProgressInfo>()
        };

        foreach (var semesterRecord in transcript.SemesterRecords)
        {
            var semesterProgressInfo = new SemesterProgressInfo
            {
                SemesterName = semesterRecord.Semester.ToString() + " " + semesterRecord.AcademicYear,
                StartDate = semesterRecord.StartDate,
                EndDate = semesterRecord.EndDate,
                SemesterGPA = semesterRecord.SemesterGPA,
                CreditsAttemptedThisSemester = semesterRecord.CreditsAttempted,
                CreditsEarnedThisSemester = semesterRecord.CreditsEarned,
                Courses = new List<CourseProgressInfo>() // Initialize Courses list for each semester
            };

            foreach (var grade in semesterRecord.Grades)
                semesterProgressInfo.Courses.Add(new CourseProgressInfo
                {
                    CourseID = grade.CourseID,
                    CourseCode = grade.Course.CourseCode,
                    CourseName = grade.Course.CourseName,
                    Credits = grade.Course.CourseCredits,
                    CurrentGrade = grade.GradeLetter.ToString() // String representation of GradeLetter
                });
            academicSummaryResponse.Semesters.Add(semesterProgressInfo); // Add SemesterProgressInfo to the list
        }

        return academicSummaryResponse;
    }

    /// <summary>
    /// Gets the current grades for a student's enrolled courses
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>The student's current course grades</returns>
    public async Task<CurrentGradesResponse> GetCurrentGradesAsync(string studentID)
    {
        // Check if student exists
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        // Get active registration period
        var activeRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (activeRegistrationPeriod == null)
        {
            _logger.LogWarning("No active registration period found for student {StudentID}", studentID);
            return new CurrentGradesResponse { CurrentCourses = new List<CurrentCourseGradeInfo>() };
        }

        // Get current enrolled courses
        var currentEnrollments = await _courseRepository.GetActiveStudentCoursesAsync(studentID);
        var currentCourses = new List<CurrentCourseGradeInfo>();

        foreach (var enrollment in currentEnrollments)
        {
            var course = enrollment.Course;

            // Look for an existing grade for this course
            var existingGrade = await _context.Grades
                .FirstOrDefaultAsync(g =>
                    g.StudentID == studentID &&
                    g.CourseID == course.CourseID &&
                    g.SemesterRecord.StartDate >= activeRegistrationPeriod.StartDate);

            // Create the course grade info with available data
            var courseGradeInfo = new CurrentCourseGradeInfo
            {
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.CourseCredits,
                CurrentGrade = existingGrade?.GradeLetter.ToString() ?? "N/A",
                GradeValue = existingGrade?.GradeLetter.GetGradePoints() ?? 0.0
            };

            currentCourses.Add(courseGradeInfo);
        }

        return new CurrentGradesResponse
        {
            CurrentCourses = currentCourses
        };
    }

    #endregion

    #region Communication & Notifications

    /// <summary>
    /// Gets all notifications for a student
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>List of notifications</returns>
    public async Task<StudentNotificationsResponse> GetStudentNotificationsAsync(string studentID)
    {
        var notifications = await _communicationRepository.GetNotificationsForStudentAsync(studentID);

        var notificationSummaries = notifications.Select(n => new NotificationSummary(
            n.Id,
            n.Title,
            n.Message,
            n.NotificationType,
            n.CreatedDate,
            n.IsRead,
            n.Priority,
            n.RedirectUrl
        )).ToList();

        return new StudentNotificationsResponse { Notifications = notificationSummaries };
    }

    /// <summary>
    /// Marks a notification as read
    /// </summary>
    /// <param name="notificationID">The notification ID</param>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>True if successful</returns>
    public async Task<bool> MarkNotificationAsReadAsync(string notificationID, string studentID)
    {
        var notificationGuid = Guid.Parse(notificationID);

        var notification = await _context.Notifications.FindAsync(notificationGuid);
        if (notification == null) throw new NotificationNotFoundException(studentID, notificationID);

        if (notification.StudentID != studentID)
            //Optional: Add authorization check to ensure student can only mark their own notifications as read
            return false;

        notification.IsRead = true;
        await _communicationRepository.UpdateNotificationAsync(notification);
        return true;
    }

    /// <summary>
    /// Gets all announcements for the student's department and general announcements
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>List of announcements</returns>
    public async Task<StudentAnnouncementsResponse> GetStudentAnnouncementsAsync(string studentID)
    {
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        var allAnnouncements = await _communicationRepository.GetAllAnnouncementsAsync();

        var announcementSummaries = allAnnouncements.Select(a => new NotificationSummary(
            a.Id,
            a.Title,
            a.Content,
            (NotificationType)a.Category,
            a.PublishDate,
            false,
            Priority.Medium,
            a.AttachmentUrl
        )).ToList();

        return new StudentAnnouncementsResponse { Announcements = announcementSummaries };
    }

    #endregion

    #region Helpers

    private async Task RecalculateTranscriptGPAAsync(Transcript transcript)
    {
        transcript.CalculateCummulativeGPA();
        foreach (var semesterRecord in transcript.SemesterRecords) semesterRecord.CalculateSemesterGPA();
        await _context.SaveChangesAsync(); // Persist GPA values
    }

    #endregion

    /// <summary>
    /// Submits a lecturer/course evaluation from a student.
    /// </summary>
    public async Task<SubmitEvaluationResponse> SubmitEvaluationAsync(string studentId, SubmitEvaluationRequest request)
    {
        _logger.LogInformation(
            "Attempting evaluation submission by StudentID: {StudentID} for CourseID: {CourseID}, LecturerID: {LecturerID}, PeriodID: {PeriodID}",
            studentId, request.CourseID, request.LecturerID, request.EvaluationPeriodID);

        // 1. Validate Evaluation Period
        var period = await _evaluationRepository.GetEvaluationPeriodByIdAsync(request.EvaluationPeriodID);
        if (period == null)
            throw new KeyNotFoundException($"Evaluation Period with ID {request.EvaluationPeriodID} not found.");
        if (!period.IsActive || DateTime.UtcNow < period.StartDate || DateTime.UtcNow > period.EndDate)
            throw new InvalidOperationException("Evaluation submission is not currently active for this period.");

        // 2. Validate Course and Lecturer exist
        var course =
            await _courseRepository.GetCourseByIDAsync(request.CourseID
                .ToString());
        if (course == null) throw new KeyNotFoundException($"Course with ID {request.CourseID} not found.");
        var lecturer = await _evaluationRepository.GetLecturerByIdAsync(request.LecturerID);
        if (lecturer == null) throw new KeyNotFoundException($"Lecturer with ID {request.LecturerID} not found.");
        // Optional: Validate lecturer actually taught this course in this period (requires LecturerCourse check)

        // 3. Verify Student Enrollment (Refined Logic)
        // Find the RegistrationPeriod matching the EvaluationPeriod's term
        var relevantRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp =>
                rp.AcademicYear == period.AcademicYear &&
                rp.Semester.ToString() == period.Semester.ToString()); // Compare Semester enum/string carefully

        if (relevantRegistrationPeriod == null)
        {
            _logger.LogWarning(
                "Could not find matching RegistrationPeriod for EvaluationPeriodID: {EvaluationPeriodID} (Term: {Semester} {AcademicYear})",
                period.Id, period.Semester, period.AcademicYear);
            throw new InvalidOperationException(
                $"Cannot verify enrollment: No matching registration period found for {period.Semester} {period.AcademicYear}.");
        }

        var isEnrolled = await _context.CourseStudents
            .AnyAsync(cs => cs.StudentID == studentId &&
                            cs.CourseID == request.CourseID &&
                            cs.RegistrationPeriodID ==
                            relevantRegistrationPeriod
                                .RegistrationPeriodID); 

        if (!isEnrolled)
        {
            _logger.LogWarning(
                "Student {StudentID} not enrolled in Course {CourseID} during registration period {RegistrationPeriodID} ({Semester} {AcademicYear})",
                studentId, request.CourseID, relevantRegistrationPeriod.RegistrationPeriodID, period.Semester,
                period.AcademicYear);
            throw new InvalidOperationException(
                $"Student {studentId} was not enrolled in course {course.CourseCode} during the {period.Semester} {period.AcademicYear} registration period.");
        }

        _logger.LogInformation("Enrollment verified for Student {StudentID} in Course {CourseID} for Period {PeriodID}",
            studentId, request.CourseID, relevantRegistrationPeriod.RegistrationPeriodID);

        // 4. Check for Prior Submission
        // TODO: Add StudentID to LecturerEvaluation entity to enable this check accurately.
        // For now, commenting out the check:
        /*
        var alreadySubmitted = await _evaluationRepository.HasStudentSubmittedEvaluationAsync(
                                    studentId, request.CourseID, request.LecturerID, request.EvaluationPeriodID);
        if (alreadySubmitted)
        {
            throw new InvalidOperationException("Evaluation already submitted for this course and lecturer during this period.");
        }
        */


        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // 5. Create Main Evaluation Record
            var newEvaluation = new LecturerEvaluation
            {
                EvaluationPeriodID = request.EvaluationPeriodID,
                CourseID = request.CourseID,
                LecturerID = request.LecturerID,
                SubmissionDate = DateTimeOffset.UtcNow,
                Comments = request.Comments ?? string.Empty,
                Responses = new List<EvaluationResponse>() // Initialize collection
            };

            // 6. Process and Validate Individual Responses
            foreach (var reqResponse in request.Responses)
            {
                var question = await _evaluationRepository.GetEvaluationQuestionByIdAsync(reqResponse.QuestionID);
                if (question == null)
                    throw new ValidationException($"Invalid QuestionID ({reqResponse.QuestionID}) submitted.");

                // Validate response type matches question type
                if (question.QuestionType == QuestionType.Rating && !reqResponse.RatingValue.HasValue)
                    throw new ValidationException(
                        $"Rating value is required for question ID {question.Id} ({question.QuestionText}).");
                if (question.QuestionType == QuestionType.Text && string.IsNullOrWhiteSpace(reqResponse.TextResponse))
                    throw new ValidationException(
                        $"Text response is required for question ID {question.Id} ({question.QuestionText}).");
                // Add more validation if needed (e.g., check RatingValue against PossibleAnswers for rating type)

                var dbResponse = new EvaluationResponse
                {
                    EvaluationQuestionID = reqResponse.QuestionID,
                    RatingValue = reqResponse.RatingValue,
                    TextResponse = reqResponse.TextResponse,
                    SelectedOption = reqResponse.SelectedOption,
                    Evaluation = newEvaluation // Link back to the parent evaluation
                };
                newEvaluation.Responses.Add(dbResponse);
            }

            // 7. Save Evaluation and Responses
            await _evaluationRepository.AddLecturerEvaluationAsync(newEvaluation);
            await _context.SaveChangesAsync(); // Save within transaction

            await transaction.CommitAsync();

            _logger.LogInformation("Successfully submitted evaluation ID: {EvaluationID} by StudentID: {StudentID}",
                newEvaluation.Id, studentId);

            return new SubmitEvaluationResponse
            {
                Success = true,
                Message = "Evaluation submitted successfully.",
                EvaluationId = newEvaluation.Id
            };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error submitting evaluation for StudentID: {StudentID}", studentId);
            // Re-throw specific exceptions if needed, otherwise let the endpoint handle generic error
            throw;
        }
    }
}