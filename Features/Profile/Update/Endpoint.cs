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

    public Endpoint(StudentService studentService)
    {
        _studentService = studentService;
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
        // Get the student ID from the claims
        var user = HttpContext.User;
        var studentIDClaim = user.FindFirst("StudentID");
        if (studentIDClaim == null || string.IsNullOrEmpty(studentIDClaim.Value))
        {
            await SendErrorsAsync(400, cancellationToken);
            return;
        }
        
        var studentID = studentIDClaim.Value;
        try
        {
            // Update the student profile using StudentService
            var success = await _studentService.UpdateStudentProfileAsync(studentID, request);
            
            if (success)
            {
                // Fetch the updated profile to return
                var updatedProfile = await _studentService.GetStudentProfileAsync(studentID);
                await SendOkAsync(updatedProfile, cancellationToken);
            }
            else
            {
                AddError("Failed to update profile");
                await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
            }
        }
        catch (StudentProfileNotFoundException ex)
        {
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}