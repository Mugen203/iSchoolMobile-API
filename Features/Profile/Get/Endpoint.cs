using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Profile.Common.Models;

namespace iSchool_Solution.Features.Profile.Get;

[Authorize]
public class Endpoint : EndpointWithoutRequest<ProfileResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly StudentService _studentService;
    
    public Endpoint(StudentService studentService, ILogger<Endpoint> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }
    
    public override void Configure()
    {
        Get("api/student/profile");
        Roles("Student");
        Description(description => description
            .WithName("GetStudentProfile")
            .WithSummary("Gets an authenticated student's profile")
            .WithTags("Profile")
            .Produces<ProfileResponse>()
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
        );
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (string.IsNullOrEmpty(studentID))
        {
            _logger.LogWarning("Student ID (NameIdentifier) claim was not found in token for profile get.");
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        _logger.LogInformation("Fetching profile for StudentID: {StudentID}", studentID);

        try
        {
            var profile = await _studentService.GetStudentProfileAsync(studentID);
            _logger.LogInformation("Successfully fetched profile for StudentID: {StudentID}", studentID);
            await SendOkAsync(profile, cancellationToken);
        }
        catch (StudentNotFoundException ex) 
        {
            _logger.LogWarning(ex, "Profile not found for StudentID: {StudentID}", studentID);
            await SendNotFoundAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching profile for StudentID: {StudentID}", studentID);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken); 
        }
    }
}