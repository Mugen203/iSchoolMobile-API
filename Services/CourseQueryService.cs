using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Courses.GetCourseDetails.Models;
using static iSchool_Solution.Features.Courses.GetCourses.Models;
using static iSchool_Solution.Features.Courses.GetEnrollments.Models;
using static iSchool_Solution.Features.Courses.GetSchedule.Models;

namespace iSchool_Solution.Services;

public class CourseQueryService
{
    private readonly CourseRepository _courseRepository;
    private readonly StudentRepository _studentRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CourseQueryService> _logger;

    public CourseQueryService(
        CourseRepository courseRepository,
        StudentRepository studentRepository,
        ApplicationDbContext context,
        ILogger<CourseQueryService> logger)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Gets a paginated list of available courses with optional filtering
    /// </summary>
    public async Task<CourseListResponse> GetCoursesAsync(CourseListRequest request)
    {
        var query = _context.Courses
            .Include(c => c.Department)
            .Include(c => c.CourseStudents)
            .Include(c => c.CourseTimeSlots)
            .AsQueryable();

        // Apply department filter if specified
        if (!string.IsNullOrEmpty(request.DepartmentId) && Guid.TryParse(request.DepartmentId, out var departmentID))
            query = query.Where(c => c.DepartmentID == departmentID);

        // Apply semester filter if specified
        if (!string.IsNullOrEmpty(request.Semester) && Enum.TryParse<Semester>(request.Semester, out var semester))
        {
            var academicYear = request.AcademicYear ?? DateTime.Now.Year;
            var academicYearStr = $"{academicYear}-{academicYear + 1}";

            query = query.Where(c => c.LecturerCourses.Any(lc =>
                lc.Semester == semester &&
                lc.AcademicYear == academicYearStr));
        }

        // Get total count for pagination
        var totalCourses = await query.CountAsync();

        // Apply pagination
        var pageSize = request.PageSize ?? 10;
        var page = request.Page ?? 1;
        var courses = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // Map to response model
        var courseItems = courses.Select(c => new CourseItem
        {
            CourseID = c.CourseID,
            CourseCode = c.CourseCode,
            CourseName = c.CourseName,
            Credits = c.CourseCredits,
            Department = c.Department.DepartmentName,
            EnrollmentCount = c.CourseStudents.Count,
            MaxCapacity = 30, // Default capacity
            IsAvailable = true, // Assuming all listed courses are available
            Schedule = c.CourseTimeSlots.Select(ts =>
                $@"{ts.DayOfWeek} {ts.StartTime:hh\:mm tt} - {ts.EndTime:hh\:mm tt} ({ts.Location})"
            ).ToList()
        }).ToList();

        // Calculate total pages
        var totalPages = (int)Math.Ceiling(totalCourses / (double)pageSize);

        return new CourseListResponse
        {
            Courses = courseItems,
            TotalCourses = totalCourses,
            Page = page,
            PageSize = pageSize,
            TotalPages = totalPages
        };
    }

    /// <summary>
    /// Gets detailed information about a specific course
    /// </summary>
    public async Task<CourseDetailsResponse> GetCourseDetailsAsync(CourseDetailsRequest request)
    {
        if (!Guid.TryParse(request.CourseID.ToString(), out var courseGuid))
            throw new ArgumentException("Invalid course ID format", nameof(request.CourseID));

        var course = await _context.Courses
            .Include(c => c.Department)
            .Include(c => c.CourseStudents)
            .Include(c => c.CourseTimeSlots)
            .Include(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .FirstOrDefaultAsync(c => c.CourseID == courseGuid);

        if (course == null) throw new CourseNotFoundException(request.CourseID.ToString());

        // Get department name
        var departmentName = course.Department.DepartmentName;

        // Get lecturers for this course
        var lecturerDetails = course.LecturerCourses
            .Select(lc => new Features.Courses.GetCourseDetails.Models.LecturerInfo
            {
                LecturerID = lc.LecturerID,
                Name = $"{lc.Lecturer.LecturerFirstName} {lc.Lecturer.LecturerLastName}",
                Email = lc.Lecturer.LecturerEmail,
                Office = lc.Lecturer.Office,
                ContactHours = "By appointment"
            })
            .ToList();

        // Get schedule information
        var scheduleItems = course.CourseTimeSlots
            .Select(cts => new ScheduleItem()
            {
                Day = cts.DayOfWeek,
                StartTime = cts.StartTime.ToString(@"hh\:mm tt"),
                EndTime = cts.EndTime.ToString(@"hh\:mm tt"),
                Location = cts.Location
            })
            .ToList();

        // Check if registration is currently open
        var isRegistrationOpen = await _context.RegistrationPeriods
            .AnyAsync(rp => rp.IsActive && DateTime.Now >= rp.StartDate && DateTime.Now <= rp.EndDate);

        // Calculate course fee based on credits
        var courseFee = course.CourseCredits * 100m; // Example fee calculation

        return new CourseDetailsResponse
        {
            CourseID = course.CourseID,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            Description = course.CourseDescription,
            Credits = course.CourseCredits,
            Department = departmentName,
            Lecturers = lecturerDetails,
            Schedule = scheduleItems,
            EnrollmentCount = course.CourseStudents.Count,
            MaxCapacity = 45,
            CourseFee = courseFee,
            Prerequisites = [], // Placeholder for prerequisites
            Syllabus = "Syllabus details will be provided by the instructor.", 
            IsRegistrationOpen = isRegistrationOpen
        };
    }

    /// <summary>
    /// Gets the list of courses a student is enrolled in
    /// </summary>
    public async Task<EnrollmentsResponse> GetStudentEnrolledCoursesAsync(string studentID, EnrollmentsRequest request)
    {
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        // Prepare query for course students
        var query = _context.CourseStudents
            .Include(cs => cs.Course)
            .ThenInclude(c => c.Department)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .Include(courseStudent => courseStudent.RegistrationPeriod)
            .Where(cs => cs.StudentID == studentID);

        // Apply current semester filter if requested
        if (request.CurrentOnly)
        {
            var currentSemester = await _context.SemesterRecords
                .Where(sr => sr.EndDate >= DateTime.Now && sr.StartDate <= DateTime.Now)
                .FirstOrDefaultAsync();

            if (currentSemester != null)
                query = query.Where(cs =>
                    cs.RegistrationPeriod.Semester.ToString() == currentSemester.Semester.ToString() &&
                    cs.RegistrationPeriod.AcademicYear == currentSemester.AcademicYear);
        }
        // Otherwise apply specific semester/year filters if provided
        else
        {
            if (!string.IsNullOrEmpty(request.Semester) && Enum.TryParse<Semester>(request.Semester, out var semester))
                query = query.Where(cs => cs.RegistrationPeriod.Semester.ToString() == semester.ToString());

            if (!string.IsNullOrEmpty(request.AcademicYear))
                query = query.Where(cs => cs.RegistrationPeriod.AcademicYear == request.AcademicYear);
        }

        // Get enrollments
        var enrollments = await query.ToListAsync();

        // Map to response model
        var enrollmentItems = new List<EnrollmentItem>();
        decimal totalFees = 0;
        var totalCredits = 0;

        // Get the active registration period to determine current enrollments
        var activeRegistrationPeriod = await _courseRepository.GetActiveRegistrationPeriodAsync();

        foreach (var enrollment in enrollments)
        {
            var course = enrollment.Course;

            // Get primary lecturer
            var lecturer = course.LecturerCourses
                .FirstOrDefault()?.Lecturer;

            // Calculate fee for this course
            var courseFee = course.CourseCredits * 100m; // Example fee calculation
            totalFees += courseFee;
            totalCredits += course.CourseCredits;

            // Get schedules
            var schedules = course.CourseTimeSlots
                .Select(ts => new ScheduleInfo
                {
                    Day = ts.DayOfWeek.ToString(),
                    Time = $@"{ts.StartTime:hh\:mm tt} - {ts.EndTime:hh\:mm tt}",
                    Location = ts.Location
                })
                .ToList();

            var enrollmentStatus = EnrollmentStatus.Enrolled;
            if (activeRegistrationPeriod != null &&
                enrollment.RegistrationPeriodID != activeRegistrationPeriod.RegistrationPeriodID)
                enrollmentStatus = EnrollmentStatus.Completed; 

            enrollmentItems.Add(new EnrollmentItem
            {
                CourseID = course.CourseID,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                Credits = course.CourseCredits,
                Department = course.Department.DepartmentName,
                Status = enrollmentStatus,
                Schedule = schedules,
                Lecturer = new Features.Courses.GetEnrollments.Models.LecturerInfo
                {
                    Name = lecturer != null ? $"{lecturer.LecturerFirstName} {lecturer.LecturerLastName}" : "TBA",
                    Email = lecturer?.LecturerEmail ?? "N/A"
                },
                CourseFee = courseFee
            });
        }

        // Get semester and academic year information
        var semesterStr = "Current";
        var academicYearStr = DateTime.Now.Year.ToString();

        if (enrollments.Count != 0)
        {
            var firstEnrollment = enrollments.First();
            semesterStr = firstEnrollment.RegistrationPeriod.Semester;
            academicYearStr = firstEnrollment.RegistrationPeriod.AcademicYear;
        }

        return new EnrollmentsResponse
        {
            StudentID = studentID,
            Semester = semesterStr,
            AcademicYear = academicYearStr,
            Enrollments = enrollmentItems,
            TotalCredits = totalCredits,
            TotalCourses = enrollmentItems.Count,
            TotalFees = totalFees
        };
    }

    /// <summary>
    /// Gets a student's course schedule
    /// </summary>
    public async Task<ScheduleResponse> GetStudentScheduleAsync(string studentID)
    {
        var registrationPeriod = await _courseRepository.GetActiveRegistrationPeriodAsync();
        if (registrationPeriod == null)
            return new ScheduleResponse
            {
                Courses = []
            };

        var currentCourses = await _context.CourseStudents
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Include(cs => cs.Course)
            .ThenInclude(c => c.LecturerCourses)
            .ThenInclude(lc => lc.Lecturer)
            .Where(cs =>
                cs.StudentID == studentID && cs.RegistrationPeriodID == registrationPeriod.RegistrationPeriodID)
            .ToListAsync();

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
                        LecturerName = lecturer != null
                            ? $"{lecturer.LecturerFirstName} {lecturer.LecturerLastName}"
                            : "TBA"
                    });
                }
            else
                // If no timeslots are defined, still include the course with TBA schedule
                scheduledCourses.Add(new ScheduledCourseInfo
                {
                    CourseID = course.CourseID,
                    CourseCode = course.CourseCode,
                    CourseName = course.CourseName,
                    Day = DayOfWeek.Monday, // Default day if no timeslots
                    StartTime = "TBA",
                    EndTime = "TBA",
                    Location = "TBA",
                    LecturerName = "TBA"
                });
        }

        return new ScheduleResponse
        {
            Courses = scheduledCourses
        };
    }
}