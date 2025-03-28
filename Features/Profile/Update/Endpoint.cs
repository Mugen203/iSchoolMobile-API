using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Profile.Common.Models;

namespace iSchool_Solution.Features.Profile.Update;

[Authorize]
public class Endpoint : Endpoint<ProfileRequest, ProfileResponse>
{
    private readonly StudentService _studentService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(StudentService studentService, ILogger<Endpoint> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    public override void Configure()
    {
        Patch("api/student/profile");
        Roles("Student");
        Description(description => description
            .WithName("UpdateStudentProfile")
            .WithSummary("Updates a student's profile information")
            .WithTags("Profile")
            .Produces<ProfileResponse>()
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
        );
    }

    public override async Task HandleAsync(ProfileRequest request, CancellationToken cancellationToken)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(studentID)) 
        {
            _logger.LogWarning("Student ID (NameIdentifier) claim was not found in token for profile update.");
            await SendUnauthorizedAsync(cancellationToken);
            return;
        }

        _logger.LogInformation("Attempting to update profile for StudentID: {StudentID}", studentID);

        try
        {
            var success = await _studentService.UpdateStudentProfileAsync(studentID, request);

            if (success)
            {
                _logger.LogInformation("Profile successfully updated for StudentID: {StudentID}. Fetching updated profile.", studentID);
                var updatedProfile = await _studentService.GetStudentProfileAsync(studentID);
                await SendOkAsync(updatedProfile, cancellationToken);
            }
            else
            {
                _logger.LogError("Profile update failed for StudentID: {StudentID} (Service returned false).", studentID);
                AddError("Failed to update profile due to an internal issue.");
                await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
            }
        }
        catch (StudentProfileNotFoundException ex)
        {
            _logger.LogWarning(ex, "Profile not found during update attempt for StudentID: {StudentID}", studentID);
            AddError(ex.Message);
            await SendNotFoundAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating profile for StudentID: {StudentID}", studentID);
            AddError(ex.Message); 
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}