using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Profile.Common.Models;

namespace iSchool_Solution.Features.Profile.Get;

[Authorize]
public class Endpoint : EndpointWithoutRequest<ProfileResponse>
{
    private readonly StudentService _studentService;
    
    public Endpoint(StudentService studentService)
    {
        _studentService = studentService;
    }
    
    public override void Configure()
    {
        Get("api/student/profile");
        Roles("Student");
        Description(description => description
            .Produces<ProfileResponse>()
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
        );
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var user = HttpContext.User;
        
        var studentIDClaim = user.FindFirst("StudentID");
        if (studentIDClaim == null || string.IsNullOrEmpty(studentIDClaim.Value))
        {
            await SendErrorsAsync(400, cancellationToken);
            return;
        }
        
        var studentID = studentIDClaim.Value;

        var profile = await _studentService.GetStudentProfileAsync(studentID);
        
        await SendOkAsync(profile, cancellationToken);
    }
}