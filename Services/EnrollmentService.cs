using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using static iSchool_Solution.Features.Courses.Conflicts.Models;
using static iSchool_Solution.Features.Courses.Drop.Models;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Services;

public class EnrollmentService
{
    private readonly CourseRepository _courseRepository;
    private readonly StudentRepository _studentRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EnrollmentService> _logger;

    public EnrollmentService(
        CourseRepository courseRepository,
        StudentRepository studentRepository,
        ApplicationDbContext context,
        ILogger<EnrollmentService> logger)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Registers a student for courses
    /// </summary>
    public async Task<RegistrationReceiptResponse> RegisterForCoursesAsync(
        string studentID, CourseRegistrationRequest request)
    {
        if (request.CourseIDs == null || request.CourseIDs.Count == 0)
            throw new ArgumentException("Course IDs are required for registration", nameof(request));

        // Check if student exists
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        // Check if student is financially eligible for registration
        if (!await CheckFinancialEligibilityAsync(studentID))
            throw new RegistrationException("Student is not financially eligible for registration");

        // Check for schedule conflicts
        var conflicts = await CheckScheduleConflictsAsync(studentID, request.CourseIDs);
        if (conflicts.HasConflicts)
            throw new ScheduleConflictException("Schedule conflicts detected", conflicts.Conflicts);

        // Get active registration period
        var registrationPeriod = await _courseRepository.GetActiveRegistrationPeriodAsync();
        if (registrationPeriod == null) throw new RegistrationException("No active registration period found");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var registeredCourses = new List<RegisteredCourseDetails>();
            var courseStudents = new List<CourseStudent>();

            foreach (var courseID in request.CourseIDs)
            {
                if (!Guid.TryParse(courseID, out var courseGuid))
                    throw new ArgumentException($"Invalid course ID format: {courseID}");

                var course = await _courseRepository.GetCourseByIDAsync(courseID);
                if (course == null) throw new CourseNotFoundException(studentID, courseID);

                // Check if already registered for the current period
                var isAlreadyRegistered = await _context.CourseStudents
                    .AnyAsync(cs =>
                        cs.StudentID == studentID && cs.CourseID == courseGuid &&
                        cs.RegistrationPeriodID == registrationPeriod.RegistrationPeriodID);
                if (isAlreadyRegistered) throw new CourseAlreadyRegisteredException(studentID, courseID);

                // Create new registration
                var courseStudent = new CourseStudent
                {
                    StudentID = studentID,
                    CourseID = courseGuid,
                    RegistrationPeriodID = registrationPeriod.RegistrationPeriodID
                };
                courseStudents.Add(courseStudent);

                // Add details for receipt
                var courseFee = course.CourseCredits * 100m; // Example fee calculation
                registeredCourses.Add(new RegisteredCourseDetails
                {
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    Credits = course.CourseCredits,
                    CourseFee = courseFee
                });
            }

            // Save course registrations
            if (courseStudents.Any())
            {
                await _context.AddRangeAsync(courseStudents);
                await _context.SaveChangesAsync();
            }

            // Calculate total fees
            var totalFees = registeredCourses.Sum(c => c.CourseFee);

            // Create registration receipt
            var receipt = new RegistrationReceiptResponse
            {
                ReceiptID = Guid.NewGuid(),
                StudentID = studentID,
                RegistrationDate = DateTime.UtcNow,
                RegisteredCourses = registeredCourses,
                TotalFees = totalFees,
                PaymentStatus = PaymentStatus.Pending
            };

            await transaction.CommitAsync();
            return receipt;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error during course registration for student {StudentID}", studentID);
            throw;
        }
    }

    /// <summary>
    /// Drops a course from a student's registration
    /// </summary>
    public async Task<DropCourseResponse> DropCourseAsync(string studentID, string courseID)
    {
        if (!Guid.TryParse(courseID, out var courseGuid))
            throw new ArgumentException($"Invalid course ID format: {courseID}");

        // Get the active registration period
        var activeRegistrationPeriod = await _courseRepository.GetActiveRegistrationPeriodAsync();
        if (activeRegistrationPeriod == null)
            throw new RegistrationException("No active registration period found to drop course from.");

        // Get the student's active enrollment for the course
        var studentCourse = await _context.CourseStudents
            .Include(sc => sc.RegistrationPeriod)
            .Include(sc => sc.Course)
            .FirstOrDefaultAsync(sc =>
                sc.StudentID == studentID &&
                sc.CourseID == courseGuid &&
                sc.RegistrationPeriodID == activeRegistrationPeriod.RegistrationPeriodID);

        if (studentCourse == null) throw new CourseNotFoundException(studentID, courseID);

        // Check if drop is allowed in current registration period
        if (studentCourse.RegistrationPeriod is { AllowCourseDrop: false })
            throw new RegistrationException("Course drop is not allowed in the current registration period");

        try
        {
            // Instead of marking as dropped, completely remove the enrollment
            _context.CourseStudents.Remove(studentCourse);
            await _context.SaveChangesAsync();

            return new DropCourseResponse
            {
                Success = true,
                CourseID = courseID,
                Message = $"Course {studentCourse.Course.CourseCode} has been successfully dropped.",
                DroppedAt = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error dropping course {CourseID} for student {StudentID}", courseID, studentID);

            return new DropCourseResponse
            {
                Success = false,
                CourseID = courseID,
                Message = "An error occurred while dropping the course.",
                DroppedAt = null
            };
        }
    }

    /// <summary>
    /// Checks for schedule conflicts between courses
    /// </summary>
    public async Task<ScheduleConflictResponse> CheckScheduleConflictsAsync(
        string studentID,
        List<string> courseIDs)
    {
        // Get student's current courses for the active registration period
        var activeRegistrationPeriod = await _courseRepository.GetActiveRegistrationPeriodAsync();
        if (activeRegistrationPeriod == null)
            return new ScheduleConflictResponse { HasConflicts = false, Conflicts = new List<ScheduleConflict>() };

        var studentCurrentCourseEnrollments = await _context.CourseStudents
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Where(cs =>
                cs.StudentID == studentID && cs.RegistrationPeriodID == activeRegistrationPeriod.RegistrationPeriodID)
            .Select(cs => cs.Course)
            .ToListAsync();

        // Get requested courses
        var requestedCourses = await _courseRepository.GetCoursesByIdsAsync(courseIDs);

        // Combine current and requested courses for conflict checking
        var allCoursesToCheck = studentCurrentCourseEnrollments.Concat(requestedCourses).ToList();
        var conflicts = new List<ScheduleConflict>();

        // Check for conflicts between all courses
        for (var i = 0; i < allCoursesToCheck.Count; i++)
        for (var j = i + 1; j < allCoursesToCheck.Count; j++)
        {
            var course1 = allCoursesToCheck[i];
            var course2 = allCoursesToCheck[j];

            foreach (var slot1 in course1.CourseTimeSlots)
            foreach (var slot2 in course2.CourseTimeSlots)
                if (slot1.DayOfWeek == slot2.DayOfWeek)
                    // Check for time overlap
                    if (!(slot1.EndTime <= slot2.StartTime || slot2.EndTime <= slot1.StartTime))
                        conflicts.Add(new ScheduleConflict
                        {
                            ConflictingCourseCode = $"{course1.CourseCode} and {course2.CourseCode}",
                            ConflictingCourseName = $"{course1.CourseName} and {course2.CourseName}",
                            ConflictDay = slot1.DayOfWeek,
                            ConflictTime = string.Format("{0:hh\\:mm tt} - {1:hh\\:mm tt}",
                                slot1.StartTime, slot1.EndTime)
                        });
        }

        return new ScheduleConflictResponse
        {
            HasConflicts = conflicts.Count != 0,
            Conflicts = conflicts
        };
    }

    /// <summary>
    /// Checks if a student is financially eligible for registration
    /// </summary>
    private async Task<bool> CheckFinancialEligibilityAsync(string studentID)
    {
        // This is a simplified check - in a real system, this would examine
        // financial records, outstanding balances, etc.
        var financialRecord = await _context.FinancialRecords
            .FirstOrDefaultAsync(fr => fr.StudentID == studentID);

        if (financialRecord == null) return true; // No financial record found, assume eligible

        // Check for outstanding balance
        var outstandingBalance = await _context.FeeItems
            .Where(fi => fi.FinancialRecordID == financialRecord.FinancialRecordID &&
                         fi.PaymentStatus != PaymentStatus.Completed)
            .SumAsync(fi => fi.Amount);

        // Student is eligible if outstanding balance is below a certain threshold
        const decimal threshold = 500.0m; // Example threshold
        return outstandingBalance < threshold;
    }
}