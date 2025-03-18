using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
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
    private readonly TranscriptRepository _transcriptRepository;
    private readonly ILogger<StudentService> _logger;
    private readonly ApplicationDbContext _context;

    public StudentService(StudentRepository studentRepository,CourseRepository courseRepository, ILogger<StudentService> logger,
        ApplicationDbContext context, TranscriptRepository transcriptRepository, CommunicationRepository communicationRepository)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _transcriptRepository = transcriptRepository;
        _communicationRepository = communicationRepository;
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
        var currentCourses = await _courseRepository.GetStudentCurrentCoursesAsync(studentID);
        var scheduledCourses = new List<ScheduledCourseInfo>();

        foreach (var courseStudent in currentCourses)
        {
            var course = courseStudent.Course;
            if (course.CourseTimeSlots.Count > 0)
            {
                foreach (var timeslot in course.CourseTimeSlots)
                {
                    var lecturer = course.LecturerCourses.FirstOrDefault()?.Lecturer;
                    scheduledCourses.Add(new ScheduledCourseInfo
                    {
                        CourseCode = course.CourseCode,
                        CourseName = course.CourseName,
                        DayOfWeek = timeslot.DayOfWeek.ToString(),
                        StartTime = timeslot.StartTime.ToString(@"hh\:mm tt"),
                        EndTime = timeslot.EndTime.ToString(@"hh\:mm tt"),
                        Location = timeslot.Location.ToString(),
                        LecturerName = $"{lecturer?.LecturerFirstName} {lecturer?.LecturerLastName}"
                    });
                }
            }
        }

        return new ScheduleResponse
        {
            Courses = scheduledCourses
        };
    }
    

    /// <summary>
    /// Registers a student for courses
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="request">The course registration request</param>
    /// <returns>A registration receipt with details of the registered courses</returns>
    public async Task<RegistrationReceiptResponse> RegisterForCoursesAsync(string studentID, CourseRegistrationRequest request)
    {
        if (request == null || request.CourseIDs.Count <= 0)
        {
            throw new ArgumentException("CourseIDs are required for registration.", nameof(request));
        }

        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null)
        {
            throw new KeyNotFoundException($"Student with ID {studentID} not found.");
        }

        if (!await CheckFinancialEligibilityAsync(studentID))
        {
            throw new InvalidOperationException("Student is not financially eligible for registration.");
        }

        await using var transaction = await _context.Database.BeginTransactionAsync(); // Start transaction
    try
    {
        var registeredCoursesDetails = new List<RegisteredCourseDetails>();
        var registeredCourses = new List<CourseStudent>();

        foreach (var courseId in request.CourseIDs)
        {
            var course = await _courseRepository.GetCourseByIDAsync(courseId);
            if (course == null)
            {
                _logger.LogWarning($"Course with ID {courseId} not found during registration for student {studentID}.");
                throw new CourseNotFoundException(studentID, courseId);
            }

            // Create CourseStudent entity to represent registration
            var courseStudent = new CourseStudent
            {
                StudentID = studentID,
                CourseID = Guid.Parse(courseId),
                RegistrationPeriodID = Guid.NewGuid()
            };
            registeredCourses.Add(courseStudent);
            registeredCoursesDetails.Add(new RegisteredCourseDetails
            {
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.CourseCredits,
            });
        }

        if (registeredCourses.Any())
        {
            await _courseRepository.AddStudentCoursesAsync(registeredCourses);
        }

        // Calculate total fees based on registered courses
        decimal totalFees = registeredCoursesDetails.Sum(c => c.CourseFee);

        // Create Registration Receipt
        var receipt = new RegistrationReceiptResponse
        {
            ReceiptID = Guid.NewGuid(),
            StudentID = studentID,
            RegistrationDate = DateTime.UtcNow,
            RegisteredCourses = registeredCoursesDetails,
            TotalFees = totalFees,
            PaymentStatus = PaymentStatus.Pending
        };

        await transaction.CommitAsync(); // Commit transaction if everything succeeds
        return receipt;
    }
    catch (Exception ex)
    {
        await transaction.RollbackAsync(); // Rollback transaction on any exception
        _logger.LogError(ex, "Error during course registration for student {StudentID}.", studentID);
        throw; // Re-throw the exception to be handled by global exception handler
    }
    }

    /// <summary>
    /// Checks for schedule conflicts between courses
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="courseIDs">List of course IDs to check</param>
    /// <returns>List of schedule conflicts if any</returns>
    private async Task<List<ScheduleConflict>> CheckScheduleConflictsAsync(string studentID, List<string> courseIDs)
    {
        var studentCurrentCourses = await _courseRepository.GetStudentCurrentCoursesAsync(studentID);
        var requestedCourses = new List<Course>();
        foreach (var courseId in courseIDs)
        {
            var course = await _courseRepository.GetCourseByIDAsync(courseId);
            if (course != null)
            {
                requestedCourses.Add(course);
            }
        }

        var allCoursesToCheck = studentCurrentCourses.Select(sc => sc.Course).Concat(requestedCourses).ToList();
        var conflicts = new List<ScheduleConflict>();

        for (var i = 0; i < allCoursesToCheck.Count; i++)
        {
            for (var j = i + 1; j < allCoursesToCheck.Count; j++)
            {
                var course1 = allCoursesToCheck[i];
                var course2 = allCoursesToCheck[j];

                foreach (var slot1 in course1.CourseTimeSlots)
                {
                    foreach (var slot2 in course2.CourseTimeSlots)
                    {
                        if (slot1.DayOfWeek == slot2.DayOfWeek)
                        {
                            // Check for time overlap
                            if (!(slot1.EndTime <= slot2.StartTime || slot2.EndTime <= slot1.StartTime))
                            {
                                conflicts.Add(new ScheduleConflict(
                                    ConflictingCourseCode: course2.CourseCode,
                                    ConflictingCourseName: course2.CourseName,
                                    ConflictDay: slot1.DayOfWeek.ToString(),
                                    ConflictTime: $"{slot1.StartTime:hh\\:mm tt} - {slot1.EndTime:hh\\:mm tt}"
                                ));
                            }
                        }
                    }
                }
            }
        }
        return conflicts;
    }

    /// <summary>
    /// Drops a course from the student's registration
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="courseID">The course ID to drop</param>
    /// <returns>True if successful</returns>
    public async Task<bool> DropCourseAsync(string studentID, string courseID)
    {
        var studentCourse = await _courseRepository.GetStudentCourseAsync(studentID, courseID);
        if (studentCourse == null)
        {
            throw new CourseNotFoundException(studentID, courseID);
        }

        try
        {
            await _courseRepository.DeleteStudentCourseAsync(studentCourse);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error dropping course {courseID} for student {studentID}.");
            return false;
        }
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
        // Fetch the transcript and related data (SemesterRecords, Grades, Courses) in one go for efficiency
        var transcript = await _context.Transcripts
            .Include(t => t.SemesterRecords)
            .ThenInclude(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(t => t.StudentID == studentID);

        if (transcript == null)
        {
            throw new TranscriptNotFoundException(studentID);
        }

        await RecalculateTranscriptGPAAsync(transcript);
        
        await _context.SaveChangesAsync();
        
        // Get Transcript Details
        var transcriptDetails = await _transcriptRepository.GetStudentTranscriptAsync(studentID);
        
        // Update TranscriptSummaryResponse with Calculated GPA Values
        transcriptDetails.CummulativeGPA = transcript.CummulativeGPA;
        transcriptDetails.CreditsAttempted = transcript.CreditsAttempted;
        transcriptDetails.TotalCreditsEarned = transcript.CreditsEarned;
        transcriptDetails.Semesters = transcriptDetails.Semesters.Select(
            srDto => 
            {
                var semesterRecordEntity =
                    transcript.SemesterRecords.FirstOrDefault(srEntity =>
                        srEntity.SemesterRecordID == srDto.SemesterRecordID);
                if (semesterRecordEntity != null)
                {
                    srDto.SemesterGPA = semesterRecordEntity.SemesterGPA;
                    srDto.Credits =
                        semesterRecordEntity.CreditsAttempted; 
                }

                return srDto;
            }).ToList();
        
        return transcriptDetails;
    }

    /// <summary>
    /// Gets the course grades for a specific semester
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <param name="semester">The semester to get grades for</param>
    /// <param name="year">The academic year</param>
    /// <returns>List of course grades</returns>
    public async Task<List<SemesterGradesResponse>> GetSemesterGradesAsync(string studentID, Semester semester, int year)
    {
        var semesterRecord = await _context.SemesterRecords
            .Include(sr => sr.Grades)
            .ThenInclude(g => g.Course)
            .FirstOrDefaultAsync(sr => 
                sr.StudentID == studentID &&  
                sr.Semester == semester && 
                sr.AcademicYear == $"{year}-{year + 1}");

        if (semesterRecord == null)
        {
            throw new SemesterRecordNotFoundException(studentID, semester, year);
        }
        
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

        if (transcript == null)
        {
            throw new TranscriptNotFoundException(studentID);
        }

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
            {
                semesterProgressInfo.Courses.Add(new CourseProgressInfo
                {
                    CourseID = grade.CourseID,
                    CourseCode = grade.Course.CourseCode,
                    CourseName = grade.Course.CourseName,
                    Credits = grade.Course.CourseCredits,
                    CurrentGrade = grade.GradeLetter.ToString() // String representation of GradeLetter
                });
            }
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
            Id: n.Id,
            Title: n.Title,
            Message: n.Message,
            Type: n.NotificationType,
            CreatedDate: n.CreatedDate,
            IsRead: n.IsRead,
            Priority: n.Priority,
            RedirectUrl: n.RedirectUrl
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
        if (notification == null)
        {
            throw new NotificationNotFoundException(studentID, notificationID);
        }

        if (notification.StudentID != studentID)
        {
            //Optional: Add authorization check to ensure student can only mark their own notifications as read
            return false;
        }

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
        if (student == null)
        {
            throw new StudentNotFoundException(studentID);
        }

        var allAnnouncements = await _communicationRepository.GetAllAnnouncementsAsync();

        var announcementSummaries = allAnnouncements.Select(a => new NotificationSummary(
            Id: a.Id,
            Title: a.Title,
            Message: a.Content,
            Type: (NotificationType)a.Category,
            CreatedDate: a.PublishDate, 
            IsRead: false,
            Priority: Priority.Medium,
            RedirectUrl: a.AttachmentUrl
        )).ToList();

        return new StudentAnnouncementsResponse { Announcements = announcementSummaries };
    }

    #endregion

    #region Helpers
    
    /// <summary>
    /// Checks if the student has fulfilled financial obligations for registration
    /// </summary>
    /// <param name="studentID">The student's unique identifier</param>
    /// <returns>True if eligible, false otherwise</returns>
    private async Task<bool> CheckFinancialEligibilityAsync(string studentID)
    {
        // Example: Check if student has any outstanding balance.
        var totalOwed = await _context.FeeItems
            .Include(f => f.FinancialRecord)
            .Where(f => f.FinancialRecord.StudentID == studentID && f.PaymentStatus == PaymentStatus.Pending)
            .SumAsync(f => f.Amount);

        return totalOwed <= 0; // Financially eligible if no outstanding balance
    }

    private async Task RecalculateTranscriptGPAAsync(Transcript transcript)
    {
        transcript.CalculateCummulativeGPA();
        foreach (var semesterRecord in transcript.SemesterRecords)
        {
            semesterRecord.CalculateSemesterGPA();
        }
        await _context.SaveChangesAsync(); // Persist GPA values
    }

    #endregion
}