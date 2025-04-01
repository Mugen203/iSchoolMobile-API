using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static iSchool_Solution.Features.Courses.Conflicts.Models;
using static iSchool_Solution.Features.Courses.Drop.Models;
using static iSchool_Solution.Features.Courses.GetRegistrationSlip.Models;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Services;

public class EnrollmentService
{
    private readonly CourseRepository _courseRepository;
    private readonly StudentRepository _studentRepository;
    private readonly RegistrationRepository _registrationRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<EnrollmentService> _logger;

    public EnrollmentService(
        CourseRepository courseRepository,
        StudentRepository studentRepository,
        RegistrationRepository registrationRepository,
        ApplicationDbContext context,
        ILogger<EnrollmentService> logger)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _registrationRepository = registrationRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Registers a student for courses using course codes
    /// </summary>
    public async Task<RegistrationReceiptResponse> RegisterForCoursesAsync(
        string studentID, CourseRegistrationRequest request)
    {
        if (request.CourseCodes == null || request.CourseCodes.Count == 0)
            throw new ArgumentException("Course codes are required for registration", nameof(request));

        // Check if student exists
        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        // Check if student is financially eligible for registration
        if (!await CheckFinancialEligibilityAsync(studentID))
            throw new RegistrationException("Student is not financially eligible for registration");

        // Get active registration period
        var registrationPeriod = await _registrationRepository.GetActiveRegistrationPeriodAsync();
        if (registrationPeriod == null) throw new RegistrationException("No active registration period found");

        // Registration period checks
        var now = DateTime.UtcNow; // Use UTC for comparisons
        var isWithinRegularPeriod = now >= registrationPeriod.StartDate && now <= registrationPeriod.EndDate &&
                                    registrationPeriod.AllowCourseAdd;
        var isWithinLatePeriod = registrationPeriod.LateRegistrationStart.HasValue &&
                                 registrationPeriod.LateRegistrationEnd.HasValue &&
                                 now >= registrationPeriod.LateRegistrationStart.Value &&
                                 now <= registrationPeriod.LateRegistrationEnd.Value &&
                                 registrationPeriod.AllowCourseAdd;

        if (!isWithinRegularPeriod && !isWithinLatePeriod)
        {
            _logger.LogWarning(
                "Course registration attempt outside allowed period for StudentID: {StudentID}. Current Time: {Now}, Period: {StartDate} - {EndDate}, Late Start: {LateStart}, Late End: {LateEnd}, AllowAdd: {AllowAdd}",
                studentID, now, registrationPeriod.StartDate, registrationPeriod.EndDate,
                registrationPeriod.LateRegistrationStart, registrationPeriod.LateRegistrationEnd,
                registrationPeriod.AllowCourseAdd);
            throw new RegistrationException("Course registration is not currently open or allowed for adding courses.");
        }

        // Get courses by their codes
        var courses = await _courseRepository.GetCoursesByCodesAsync(request.CourseCodes);

        // Verify all requested courses were found
        if (courses.Count != request.CourseCodes.Count)
        {
            var foundCodes = courses.Select(c => c.CourseCode).ToList();
            var missingCodes = request.CourseCodes.Where(code => !foundCodes.Contains(code)).ToList();
            throw new CourseNotFoundException(
                $"The following courses were not found: {string.Join(", ", missingCodes)}");
        }

        // Check for schedule conflicts
        var conflicts = await CheckScheduleConflictsForCoursesAsync(studentID, courses);
        if (conflicts.HasConflicts)
            throw new ScheduleConflictException("Schedule conflicts detected", conflicts.Conflicts);

        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var registeredCourses = new List<RegisteredCourseDetails>();
            var courseStudents = new List<CourseStudent>();

            foreach (var course in courses)
            {
                // Check if already registered for the current period
                var isAlreadyRegistered = await _context.CourseStudents
                    .AnyAsync(cs =>
                        cs.StudentID == studentID && cs.CourseID == course.CourseID &&
                        cs.RegistrationPeriodID == registrationPeriod.RegistrationPeriodID);

                if (isAlreadyRegistered)
                    throw new CourseAlreadyRegisteredException(studentID, course.CourseCode);

                // Create new registration
                var courseStudent = new CourseStudent
                {
                    StudentID = studentID,
                    CourseID = course.CourseID,
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
    /// Drops a course from a student's registration by course code
    /// </summary>
    public async Task<DropCourseResponse> DropCourseAsync(string studentID, string courseCode)
    {
        // Get course by code
        var course = await _courseRepository.GetCourseByCodeAsync(courseCode);
        if (course == null) throw new CourseNotFoundException($"Course with code {courseCode} not found");

        // Get the active registration period
        var activeRegistrationPeriod = await _registrationRepository.GetActiveRegistrationPeriodAsync();
        if (activeRegistrationPeriod == null)
            throw new RegistrationException("No active registration period found to drop course from.");

        // Get the student's active enrollment for the course
        var studentCourse = await _context.CourseStudents
            .Include(sc => sc.RegistrationPeriod)
            .Include(sc => sc.Course)
            .FirstOrDefaultAsync(sc =>
                sc.StudentID == studentID &&
                sc.CourseID == course.CourseID &&
                sc.RegistrationPeriodID == activeRegistrationPeriod.RegistrationPeriodID);

        if (studentCourse == null) throw new CourseNotFoundException(studentID, courseCode);

        var now = DateTime.UtcNow; // Use UTC

        // Check if dropping is allowed by the period rules AND within the allowed time frame
        // Note: The original check for AllowCourseDrop was good, but we add the time check.

        if (!activeRegistrationPeriod.AllowCourseDrop)
        {
            _logger.LogWarning(
                "Course drop attempt failed for StudentID: {StudentID}, CourseCode: {CourseCode}. Dropping not allowed by period rules (AllowCourseDrop=false).",
                studentID, courseCode);
            throw new RegistrationException(
                "Dropping courses is not allowed according to the current registration period rules.");
        }

        // Check if current time is within the allowed drop window (e.g., up to EndDate)
        var isWithinDropWindow = now >= activeRegistrationPeriod.StartDate && now <= activeRegistrationPeriod.EndDate;

        if (!isWithinDropWindow)
        {
            _logger.LogWarning(
                "Course drop attempt outside allowed timeframe for StudentID: {StudentID}, CourseCode: {CourseCode}. Current Time: {Now}, Period End: {EndDate}",
                studentID, courseCode, now, activeRegistrationPeriod.EndDate);
            throw new RegistrationException("The period for dropping courses has passed.");
        }

        // Check if drop is allowed in current registration period
        if (studentCourse.RegistrationPeriod is { AllowCourseDrop: false })
            throw new RegistrationException("Dropping courses is not allowed in the current registration period");

        try
        {
            // Instead of marking as dropped, completely remove the enrollment
            _context.CourseStudents.Remove(studentCourse);
            await _context.SaveChangesAsync();

            return new DropCourseResponse
            {
                Success = true,
                CourseID = course.CourseID.ToString(),
                Message = $"Course {course.CourseCode} has been successfully dropped.",
                DroppedAt = DateTime.UtcNow
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error dropping course {CourseCode} for student {StudentID}", courseCode, studentID);

            return new DropCourseResponse
            {
                Success = false,
                CourseID = course.CourseID.ToString(),
                Message = "An error occurred while dropping the course.",
                DroppedAt = null
            };
        }
    }

    /// <summary>
    /// Checks for schedule conflicts for a list of course objects
    /// </summary>
    private async Task<ScheduleConflictResponse> CheckScheduleConflictsForCoursesAsync(
        string studentID,
        List<Course> requestedCourses)
    {
        // Get active registration period
        var activeRegistrationPeriod = await _registrationRepository.GetActiveRegistrationPeriodAsync();
        if (activeRegistrationPeriod == null)
            return new ScheduleConflictResponse { HasConflicts = false, Conflicts = new List<ScheduleConflict>() };

        // Get student's current courses for the active registration period
        var studentCurrentCourseEnrollments = await _context.CourseStudents
            .Include(cs => cs.Course)
            .ThenInclude(c => c.CourseTimeSlots)
            .Where(cs =>
                cs.StudentID == studentID && cs.RegistrationPeriodID == activeRegistrationPeriod.RegistrationPeriodID)
            .Select(cs => cs.Course)
            .ToListAsync();

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
    /// Checks for schedule conflicts between course codes
    /// </summary>
    public async Task<ScheduleConflictResponse> CheckScheduleConflictsAsync(
        string studentID,
        List<string> courseCodes)
    {
        // Get courses by their codes
        var courses = await _courseRepository.GetCoursesByCodesAsync(courseCodes);

        // Verify all requested courses were found
        if (courses.Count != courseCodes.Count)
        {
            var foundCodes = courses.Select(c => c.CourseCode).ToList();
            var missingCodes = courseCodes.Where(code => !foundCodes.Contains(code)).ToList();

            _logger.LogWarning("Some course codes were not found: {MissingCodes}", string.Join(", ", missingCodes));
            // Continue checking conflicts for courses that were found
        }

        return await CheckScheduleConflictsForCoursesAsync(studentID, courses);
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

    /// <summary>
    /// Generates a registration slip PDF for a student and registration period.
    /// </summary>
    /// <param name="studentID">The student's ID.</param>
    /// <param name="registrationPeriodID">The ID of the registration period.</param>
    /// <returns>Tuple containing PDF bytes, content type, and filename.</returns>
    /// <exception cref="StudentNotFoundException"></exception>
    /// <exception cref="KeyNotFoundException">Thrown if RegistrationPeriod or enrollment not found.</exception>
    /// <exception cref="ApplicationException"></exception>
    public async Task<(byte[] FileContents, string ContentType, string FileName)> GenerateRegistrationSlipPdfAsync(
        string studentID, Guid registrationPeriodID)
    {
        _logger.LogInformation("Generating registration slip PDF for StudentID: {StudentID}, PeriodID: {PeriodID}",
            studentID, registrationPeriodID);

        var student = await _studentRepository.GetStudentByStudentIDAsync(studentID);
        if (student == null) throw new StudentNotFoundException(studentID);

        var registrationPeriod = await _registrationRepository.GetRegistrationPeriodByIdAsync(registrationPeriodID);
        if (registrationPeriod == null)
            throw new KeyNotFoundException($"Registration Period with ID {registrationPeriodID} not found.");

        // Fetch enrollments for the specific period including course details
        var enrollments =
            await _courseRepository.GetStudentCoursesByRegistrationPeriodAsync(studentID, registrationPeriodID);
        var courseStudents = enrollments.ToList();
        if (courseStudents.Count == 0)
        {
            _logger.LogWarning("No course enrollments found for StudentID: {StudentID} in PeriodID: {PeriodID}",
                studentID, registrationPeriodID);
            // Decide if throwing an error or returning an empty slip is appropriate
            throw new KeyNotFoundException($"No courses registered for student {studentID} in the specified period.");
        }

        var slipData = new RegistrationSlipData
        {
            StudentName = $"{student.FirstName} {student.LastName}",
            StudentID = student.StudentID,
            AcademicYear = registrationPeriod.AcademicYear,
            Semester = registrationPeriod.Semester,
            RegistrationDate = DateTime.UtcNow, // Or use a specific date if available
            RegisteredCourses = courseStudents.Select(e => new RegisteredCourseInfo
            {
                CourseCode = e.Course.CourseCode,
                CourseName = e.Course.CourseName,
                Credits = e.Course.CourseCredits
                // Map Lecturer/Schedule here if needed
            }).ToList(),
            TotalCredits = courseStudents.Sum(e => e.Course.CourseCredits)
        };

        _logger.LogDebug("Data prepared for PDF generation. Student: {StudentID}, Courses: {CourseCount}",
            slipData.StudentID, slipData.RegisteredCourses.Count);

        try
        {
            // Define QuestPDF Document
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Header
                    page.Header()
                        .AlignCenter()
                        .Column(col =>
                        {
                            col.Item().Text("Valley View University").Bold().FontSize(14);
                            col.Item().Text("Registration Slip").SemiBold().FontSize(12);
                            col.Spacing(5);
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(0.5f, Unit.Centimetre)
                        .Column(col =>
                        {
                            col.Spacing(8);
                            // Student Info Section
                            col.Item().Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text($"Student Name: {slipData.StudentName}").SemiBold();
                                    c.Item().Text($"Student ID: {slipData.StudentID}");
                                });
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text($"Department: {slipData.DepartmentName}");
                                    c.Item().Text($"Period: {slipData.Semester} {slipData.AcademicYear}").SemiBold();
                                });
                            });

                            col.Item().LineHorizontal(0.5f);

                            // Courses Table
                            col.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80); // Course Code
                                    columns.RelativeColumn(); // Course Name
                                    columns.ConstantColumn(50); // Credits
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Code").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Course Title")
                                        .Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).AlignCenter()
                                        .Text("Credits").Bold();
                                });

                                foreach (var course in slipData.RegisteredCourses)
                                {
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .Text(course.CourseCode);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .Text(course.CourseName);
                                    table.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .AlignCenter().Text(course.Credits.ToString());
                                }

                                // Total Credits Row
                                table.Cell().ColumnSpan(2).BorderTop(1).Padding(3).AlignRight().Text("Total Credits:")
                                    .SemiBold();
                                table.Cell().BorderTop(1).Padding(3).AlignCenter()
                                    .Text(slipData.TotalCredits.ToString()).SemiBold();
                            });

                            col.Item().PaddingTop(10).Text($"Date Generated: {DateTime.Now:yyyy-MM-dd HH:mm}")
                                .FontSize(8);
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                            x.Span(" of ");
                            x.TotalPages();
                        });
                });
            });

            // Generate PDF bytes
            byte[] pdfBytes = document.GeneratePdf();
            var fileName = $"RegistrationSlip_{studentID}_{slipData.AcademicYear}_{slipData.Semester}.pdf";
            var contentType = "application/pdf";

            _logger.LogInformation(
                "Registration slip PDF generated successfully for StudentID: {StudentID}, PeriodID: {PeriodID}. Size: {FileSize} bytes",
                studentID, registrationPeriodID, pdfBytes.Length);

            return (pdfBytes, contentType, fileName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Failed to generate registration slip PDF for StudentID: {StudentID}, PeriodID: {PeriodID}", studentID,
                registrationPeriodID);
            throw new ApplicationException("Failed to generate registration slip PDF.", ex);
        }
    }
}