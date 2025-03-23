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
        if (Guid.TryParse(courseId, out var courseGuid))
        {
            return await _context.Courses
                .Include(c => c.CourseTimeSlots)
                .Include(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .FirstOrDefaultAsync(c => c.CourseID == courseGuid);
        }

        _logger.LogWarning($"Invalid Course ID format: {courseId}");
        return null;
    }

    public async Task<Course?> GetCourseByCodeAsync(string courseCode)
    {
        if (string.IsNullOrEmpty(courseCode))
        {
            _logger.LogWarning("Empty course code provided");
            return null;
        }

        return await _context.Courses
            .Include(c => c.CourseTimeSlots)
            .Include(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .FirstOrDefaultAsync(c => c.CourseCode == courseCode);
    }

    public async Task<List<Course>> GetCoursesByCodesAsync(List<string> courseCodes)
    {
        if (courseCodes == null || !courseCodes.Any())
        {
            _logger.LogWarning("Empty course codes list provided");
            return new List<Course>();
        }

        return await _context.Courses
            .Include(c => c.CourseTimeSlots)
            .Include(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .Where(c => courseCodes.Contains(c.CourseCode))
            .ToListAsync();
    }

    public async Task<bool> IsStudentEnrolledInCourseByCodeAsync(string studentID, string courseCode)
    {
        var course = await GetCourseByCodeAsync(courseCode);
        if (course == null)
        {
            _logger.LogWarning($"Course with code {courseCode} not found");
            return false;
        }

        var currentRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (currentRegistrationPeriod == null)
        {
            return false;
        }

        return await _context.CourseStudents
            .AnyAsync(cs =>
                cs.StudentID == studentID &&
                cs.CourseID == course.CourseID &&
                cs.RegistrationPeriodID == currentRegistrationPeriod.RegistrationPeriodID);
    }

    public async Task<IEnumerable<CourseStudent>> GetActiveStudentCoursesAsync(string studentID)
    {
        var currentRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (currentRegistrationPeriod == null)
        {
            _logger.LogInformation(
                $"No active registration period found when fetching active courses for student {studentID}.");
            return new List<CourseStudent>();
        }

        return await _context.CourseStudents
            .Where(cs =>
                cs.StudentID == studentID &&
                cs.RegistrationPeriodID == currentRegistrationPeriod.RegistrationPeriodID)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .ToListAsync();
    }

    public async Task<CourseStudent?> GetActiveStudentCourseAsync(string studentID, string courseID)
    {
        if (!Guid.TryParse(courseID, out var courseGuid))
        {
            _logger.LogWarning($"Invalid Course ID format when fetching StudentCourse: {courseID} for student {studentID}");
            return null;
        }

        var currentRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (currentRegistrationPeriod == null)
        {
            _logger.LogWarning(
                $"No active registration period found while fetching StudentCourse for student {studentID}, course {courseID}.");
            return null;
        }

        return await _context.CourseStudents
            .FirstOrDefaultAsync(cs =>
                cs.StudentID == studentID &&
                cs.CourseID == courseGuid &&
                cs.RegistrationPeriodID == currentRegistrationPeriod.RegistrationPeriodID);
    }

    public async Task<IEnumerable<CourseStudent>> GetStudentCoursesByRegistrationPeriodAsync(
        string studentID, Guid registrationPeriodID)
    {
        return await _context.CourseStudents
            .Where(cs =>
                cs.StudentID == studentID &&
                cs.RegistrationPeriodID == registrationPeriodID)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .Include(cs => cs.RegistrationPeriod)
            .ToListAsync();
    }

    public async Task<bool> IsStudentEnrolledInCourseAsync(string studentID, string courseID)
    {
        if (!Guid.TryParse(courseID, out var courseGuid))
        {
            _logger.LogWarning($"Invalid Course ID format: {courseID}");
            return false;
        }

        var currentRegistrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (currentRegistrationPeriod == null)
        {
            return false;
        }

        return await _context.CourseStudents
            .AnyAsync(cs =>
                cs.StudentID == studentID &&
                cs.CourseID == courseGuid &&
                cs.RegistrationPeriodID == currentRegistrationPeriod.RegistrationPeriodID);
    }

    public async Task AddStudentCoursesAsync(List<CourseStudent> courseStudents)
    {
        if (courseStudents == null || !courseStudents.Any())
        {
            _logger.LogWarning("Attempted to add empty or null list of CourseStudents.");
            throw new ArgumentException("Course students list cannot be empty or null", nameof(courseStudents));
        }

        try
        {
            await _context.CourseStudents.AddRangeAsync(courseStudents);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding CourseStudents to database.");
            throw;
        }
    }

    public async Task AddStudentCourseAsync(CourseStudent courseStudent)
    {
        if (courseStudent == null)
        {
            _logger.LogWarning("Attempted to add null CourseStudent entity.");
            throw new ArgumentNullException(nameof(courseStudent));
        }

        try
        {
            await _context.CourseStudents.AddAsync(courseStudent);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error adding CourseStudent with CourseID: {courseStudent.CourseID}, StudentID: {courseStudent.StudentID}.");
            throw;
        }
    }

    public async Task RemoveStudentCourseAsync(CourseStudent courseStudent)
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
            throw;
        }
    }

    public async Task<RegistrationPeriod?> GetActiveRegistrationPeriodAsync()
    {
        return await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);
    }

    public async Task<List<Course>> GetCoursesByIdsAsync(List<string> courseIds)
    {
        var courses = new List<Course>();

        foreach (var id in courseIds)
        {
            if (Guid.TryParse(id, out var courseGuid))
            {
                var course = await _context.Courses
                    .Include(c => c.CourseTimeSlots)
                    .Include(c => c.LecturerCourses)
                    .ThenInclude(lc => lc.Lecturer)
                    .FirstOrDefaultAsync(c => c.CourseID == courseGuid);

                if (course != null)
                {
                    courses.Add(course);
                }
            }
        }

        return courses;
    }
}