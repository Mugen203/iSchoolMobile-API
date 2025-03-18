using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Repository;

public class CourseRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CourseRepository> _logger;

    public CourseRepository(ApplicationDbContext context, ILogger<CourseRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Course?> GetCourseByIDAsync(string courseId)
    {
        if (Guid.TryParse(courseId, out var courseGuid)) // Parse string courseId to Guid
            return await _context.Courses
                .Include(c =>
                    c.CourseTimeSlots) // Include related entities if needed for later use, e.g., registration process
                .Include(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .FirstOrDefaultAsync(c => c.CourseID == courseGuid); // Use Guid to find course

        _logger.LogWarning($"Invalid Course ID format: {courseId}");
        return null;
    }

    public async Task<IEnumerable<CourseStudent>> GetStudentCurrentCoursesAsync(string studentID)
    {
        var currentRegistrationPeriod = await _context.RegistrationPeriods.FirstOrDefaultAsync(rp => rp.IsActive);

        if (currentRegistrationPeriod == null)
        {
            _logger.LogInformation(
                $"No active registration period found when fetching current courses for student {studentID}.");
            return new List<CourseStudent>(); // Log and return empty list if no active period
        }

        return await _context.CourseStudents
            .Where(cs =>
                cs.StudentID == studentID && cs.RegistrationPeriodID == currentRegistrationPeriod.RegistrationPeriodID)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots) // Include CourseTimeSlots for schedule info
            .Include(cs => cs.Course)
            .ThenInclude(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer) // Include Lecturers for lecturer info
            .ToListAsync();
    }

    public async Task<CourseStudent?> GetStudentCourseAsync(string studentID, string courseID)
    {
        if (Guid.TryParse(courseID, out var courseGuid))
        {
            var currentRegistrationPeriod = await _context.RegistrationPeriods.FirstOrDefaultAsync(rp => rp.IsActive);
            if (currentRegistrationPeriod == null)
            {
                _logger.LogWarning(
                    $"No active registration period found while fetching StudentCourse for student {studentID}, course {courseID}.");
                return null; // TODO: Handle as appropriate when no active registration period
            }

            return await _context.CourseStudents
                .FirstOrDefaultAsync(cs =>
                    cs.StudentID == studentID &&
                    cs.CourseID == courseGuid &&
                    cs.RegistrationPeriodID ==
                    currentRegistrationPeriod.RegistrationPeriodID); // Match Registration Period
        }

        _logger.LogWarning($"Invalid Course ID format when fetching StudentCourse: {courseID} for student {studentID}");
        return null; //TODO: Handle invalid course ID
    }

    public async Task AddStudentCoursesAsync(List<CourseStudent> courseStudents)
    {
        if (courseStudents.Count <= 0)
        {
            _logger.LogWarning("Attempted to add empty or null list of CourseStudents.");
            throw new ArgumentNullException(nameof(courseStudents));
        }

        try
        {
            await _context.CourseStudents.AddRangeAsync(courseStudents);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding CourseStudents to database.");
            throw; // TODO: Re-throw exception to be handled by service layer, or handle error and return specific result
        }
    }

    public async Task DeleteStudentCourseAsync(CourseStudent courseStudent)
    {
        if (courseStudent == null)
        {
            _logger.LogWarning("Attempted to delete a null CourseStudent entity.");
            throw new ArgumentNullException(nameof(courseStudent), "CourseStudent entity cannot be null for deletion.");
        }

        try
        {
            _context.CourseStudents.Remove(courseStudent);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                $"Error deleting CourseStudent entity with CourseID: {courseStudent.CourseID}, StudentID: {courseStudent.StudentID}.");
            throw; // TODO: Re-throw to service layer for handling
        }
    }
}