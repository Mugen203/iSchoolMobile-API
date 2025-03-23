using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Courses.Conflicts.Models;
using static iSchool_Solution.Features.Courses.Drop.Models;
using static iSchool_Solution.Features.Courses.GetCourseDetails.Models;
using static iSchool_Solution.Features.Courses.GetCourses.Models;
using static iSchool_Solution.Features.Courses.GetEnrollments.Models;
using static iSchool_Solution.Features.Courses.GetSchedule.Models;
using static iSchool_Solution.Features.Courses.Register.Models;


namespace iSchool_Solution.Services;

public class CourseService
{
    private readonly CourseRepository _courseRepository;
    private readonly StudentRepository _studentRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CourseService> _logger;

    public CourseService(
        CourseRepository courseRepository,
        StudentRepository studentRepository,
        ApplicationDbContext context,
        ILogger<CourseService> logger)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _context = context;
        _logger = logger;
    }

    // public async Task CreateCourseAsync(CreateCourseRequest request) { ... }
    // public async Task UpdateCourseAsync(UpdateCourseRequest request) { ... }
    // public async Task DeleteCourseAsync(Guid courseId) { ... }
}