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
using static iSchool_Solution.Features.Grade.GetSemester.Models;
using static iSchool_Solution.Features.Notifications.Common.Models;
using static iSchool_Solution.Features.Notifications.GetAnnouncements.Models;
using static iSchool_Solution.Features.Notifications.GetNotifications.Models;
using static iSchool_Solution.Features.Profile.Common.Models;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Services;

public class StudentService
{
    private readonly StudentRepository _studentRepository;
    private readonly CourseRepository _courseRepository;
    private readonly CommunicationRepository _communicationRepository;
    private readonly TranscriptService _transcriptService; // Add this
    private readonly ILogger<StudentService> _logger;
    private readonly ApplicationDbContext _context;

    public StudentService(
        StudentRepository studentRepository,
        CourseRepository courseRepository,
        ILogger<StudentService> logger,
        ApplicationDbContext context,
        TranscriptRepository transcriptRepository,
        CommunicationRepository communicationRepository,
        TranscriptService transcriptService) // Add this
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _communicationRepository = communicationRepository;
        _transcriptService = transcriptService; // Add this
        _logger = logger;
        _context = context;
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
            DepartmentName = student.DepartmentName,
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

    #region Course Management

    /// <summary>
    /// Gets the student's current course schedule
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>The student's course schedule</returns>
    public async Task<ScheduleResponse> GetStudentScheduleAsync(string studentID)
    {
        var currentCourses = await _courseRepository.GetActiveStudentCoursesAsync(studentID);
        var scheduledCourses = new List<ScheduledCourseInfo>();

        foreach (var courseStudent in currentCourses)
        {
            var course = courseStudent.Course;
            if (course.CourseTimeSlots.Count > 0)
                foreach (var timeslot in course.CourseTimeSlots)
                {
                    var lecturer = course.LecturerCourses.FirstOrDefault()?.Lecturer;
                    scheduledCourses.Add(new ScheduledCourseInfo
                    {
                        CourseID = course.CourseID,
                        CourseCode = course.CourseCode,
                        CourseName = course.CourseName,
                        Day = timeslot.DayOfWeek,
                        StartTime = timeslot.StartTime.ToString(@"hh\:mm tt"),
                        EndTime = timeslot.EndTime.ToString(@"hh\:mm tt"),
                        Location = timeslot.Location.ToString(),
                        LecturerName = $"{lecturer?.LecturerFirstName} {lecturer?.LecturerLastName}"
                    });
                }
        }

        return new ScheduleResponse
        {
            Courses = scheduledCourses
        };
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
    /// <param name="year">The academic year</param>
    /// <returns>List of course grades</returns>
    public async Task<List<SemesterGradesResponse>> GetSemesterGradesAsync(string studentID, Semester semester,
        int year)
    {
        var semesterRecord = await _context.SemesterRecords
            .Include(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(sr =>
                sr.StudentID == studentID &&
                sr.Semester == semester &&
                sr.AcademicYear == $"{year}-{year + 1}");

        if (semesterRecord == null) throw new SemesterRecordNotFoundException(studentID, semester, year);

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
}