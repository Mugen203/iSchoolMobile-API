using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.GetCourses.Models;

namespace iSchool_Solution.Features.Courses.GetCourses;

[Authorize]
public class Endpoint: Endpoint<CourseListRequest, CourseListResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly CourseQueryService _courseQueryService;

    public Endpoint(ILogger<Endpoint> logger, CourseQueryService courseQueryService)
    {
        _logger = logger;
        _courseQueryService = courseQueryService;
    }

    public override void Configure()
    {
        Get("api/courses");
        Roles("Student");
        Description(description => description
            .WithName("GetCourses")
            .WithSummary("Gets a paginated list of courses with optional filtering")
            .WithTags("Courses")
            .Produces<CourseListResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(CourseListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var courseResponse = await _courseQueryService.GetCoursesAsync(request);
            _logger.LogInformation("Retrieved {CourseCount} courses (Page {Page}/{TotalPages})",
                courseResponse.Courses.Count, courseResponse.Page, courseResponse.TotalPages);
            await SendOkAsync(courseResponse, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving course listings");
            AddError("An unexpected error occurred while retrieving course listings");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}