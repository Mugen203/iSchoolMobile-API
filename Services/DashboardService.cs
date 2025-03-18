using iSchool_Solution.Data;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using static iSchool_Solution.Features.Dashboard.Models;

namespace iSchool_Solution.Services;

public class DashboardService
{
    private readonly StudentRepository _studentRepository;
    private readonly CourseRepository _courseRepository;
    private readonly TranscriptRepository _transcriptRepository;
    private readonly CommunicationRepository _communicationRepository;

    private readonly ApplicationDbContext
        _context; // Directly use ApplicationDbContext for financial status for now - consider FinancialRecordRepository later

    private readonly ILogger<DashboardService> _logger;

    public DashboardService(StudentRepository studentRepository,
        CourseRepository courseRepository,
        TranscriptRepository transcriptRepository,
        CommunicationRepository communicationRepository,
        ApplicationDbContext context,
        ILogger<DashboardService> logger)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _transcriptRepository = transcriptRepository;
        _communicationRepository = communicationRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Gets a summary of the student's dashboard information.
    /// </summary>
    /// <param name="studentID">The student's unique identifier.</param>
    /// <returns>Dashboard summary with academic progress, deadlines, next class, etc.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the student with the given ID is not found.</exception>
    public async Task<DashboardSummaryResponse> GetDashboardSummaryAsync(string studentID)
        {
            // Get student data
            var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
            if (student == null)
            {
                _logger.LogWarning($"Dashboard summary requested for non-existent student ID: {studentID}");
                throw new KeyNotFoundException($"Student with ID:{studentID} not found.");
            }

            // Get notifications
            var notifications = await _communicationRepository.GetNotificationsForStudentAsync(studentID);
            var unreadCount = notifications.Count(n => !n.IsRead);

            // Get transcript data for GPA information
            var transcript = await _transcriptRepository.GetStudentTranscriptAsync(studentID);
            
            // Get financial data
            var financialStatus = await GetFinancialStatusAsync(studentID);
            
            // Get next class information
            var nextClass = await GetNextClassInfoAsync(studentID);
            
            // Get announcements
            var announcements = await _communicationRepository.GetAllAnnouncementsAsync();
            var announcementCards = announcements.Select(a => new AnnouncementCardInfo
            {
                Title = a.Title,
                Date = a.PublishDate
            }).ToList();

            // Create the response object using only the DTOs from Models.cs
            var dashboardSummary = new DashboardSummaryResponse
            {
                Header = new HeaderInfo
                {
                    StudentID = student.StudentID,
                    StudentName = $"{student.FirstName} {student.LastName}",
                    UnreadNotificationCount = unreadCount
                },
                NextClass = nextClass,
                KeyMetrics = new KeyMetricsInfo
                {
                    GPAMetrics = new GPAMetric
                    {
                        CurrentGPA = transcript.CummulativeGPA,
                        LastSemesterGPA = transcript.Semesters.LastOrDefault()?.SemesterGPA
                    },
                    BalanceMetrics = new BalanceMetric
                    {
                        OutstandingBalance = financialStatus.OutstandingBalance,
                        NextDueDate = financialStatus.NextDueDate
                    }
                },
                Announcements = announcementCards
            };

            return dashboardSummary;
        }
    
    /// <summary>
    /// Gets the student's financial status information.
    /// </summary>
    /// <param name="studentID">The student's unique identifier.</param>
    /// <returns>Financial status information (OutstandingBalance, NextDueDate).</returns>
    private async Task<(decimal OutstandingBalance, DateTimeOffset? NextDueDate)> GetFinancialStatusAsync(string studentID)
    {
        // Get the total amount owed
        var pendingFees = await _context.FeeItems
            .Include(f => f.FinancialRecord) // Eager load FinancialRecord to access Student (though StudentID is not directly used in this query now)
            .Where(f => f.FinancialRecord.StudentID == studentID && f.PaymentStatus == Enums.PaymentStatus.Pending) // Now PaymentStatus is directly on FeeItem
            .ToListAsync();

        var outstandingBalance = pendingFees.Sum(f => f.Amount);

        // Find the next due date (closest due date in the future)
        var nextDueDate = pendingFees
            .Where(f => f.DueDate > DateTimeOffset.Now)
            .OrderBy(f => f.DueDate)
            .FirstOrDefault()?.DueDate;

        // If no future due dates, use the most recent past due date + 30 days as a fallback
        if (nextDueDate == null && pendingFees.Count != 0)
        {
            var lastDueDate = pendingFees
                .OrderByDescending(f => f.DueDate)
                .FirstOrDefault()?.DueDate;

            if (lastDueDate.HasValue) // Check if lastDueDate actually has a value before adding days
            {
                nextDueDate = lastDueDate.Value.AddDays(30);
            }
        }

        return (outstandingBalance, nextDueDate);
    }
    
    /// <summary>
    /// Gets information about the student's next scheduled class.
    /// </summary>
    /// <param name="studentID">The student's unique identifier.</param>
    /// <returns>NextClassInfo object or null if no next class is found.</returns>
    private async Task<NextClassInfo?> GetNextClassInfoAsync(string studentID)
    {
        var currentCourses = await _courseRepository.GetStudentCurrentCoursesAsync(studentID);

        var courseStudents = currentCourses.ToList();
        if (!courseStudents.Any())
            return null;

        // In a real implementation, you would determine the actual next class based on the current time
        // This is a simplified version that just takes the first available course and timeslot
        foreach (var course in courseStudents.Select(courseStudent => courseStudent.Course))
        {
            if (course.CourseTimeSlots.Count == 0)
                continue;

            // Find the lecturer's name
            var lecturer = course.LecturerCourses.FirstOrDefault()?.Lecturer;
            string? lecturerName = null;
                
            if (lecturer != null)
            {
                lecturerName = $"{lecturer.LecturerFirstName} {lecturer.LecturerLastName}";
            }

            // Get the first timeslot (in a real implementation, you would find the next timeslot based on current time)
            var timeslot = course.CourseTimeSlots.First();
                
            return new NextClassInfo
            {
                CourseName = course.CourseName,
                Location = timeslot.Location,
                StartTime = timeslot.StartTime.ToString(@"hh\:mm tt"),
                EndTime = timeslot.EndTime.ToString(@"hh\:mm tt"),
                LecturerName = lecturerName
            };
        }

        return null;
    }
}