using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.GetCourseDetails.Models;

namespace iSchool_Solution.Features.Courses.GetCourseDetails;

[Authorize]
public class Endpoint : Endpoint<CourseDetailsRequest, CourseDetailsResponse>
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
        Get("api/courses/{courseID}");
        Description(description => description
            .WithName("GetCourseDetails")
            .WithSummary("Gets detailed information about a specific course")
            .WithTags("Courses")
            .Produces<CourseDetailsResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(CourseDetailsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var courseDetails = await _courseQueryService.GetCourseDetailsAsync(request);
            _logger.LogInformation("Retrieved details for course {CourseID}: {CourseName}", 
                courseDetails.CourseID, courseDetails.CourseName);
            await SendOkAsync(courseDetails, cancellationToken);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid course code format: {CourseID}", request.CourseCode);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
        }
        catch (CourseNotFoundException ex)
        {
            _logger.LogWarning(ex, "Course not found: {CourseID}", request.CourseCode);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving course details for course: {CourseID}", request.CourseCode);
            AddError("An unexpected error occurred while retrieving course details");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}