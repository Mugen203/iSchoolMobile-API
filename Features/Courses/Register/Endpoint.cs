using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Courses.Register.Models;

namespace iSchool_Solution.Features.Courses.Register;

[Authorize]
public class Endpoint : Endpoint<CourseRegistrationRequest, RegistrationReceiptResponse>
{
    public override void Configure()
    {
        Get("api/courses/register");
        Roles("Student");

    }

    public override async Task HandleAsync(CourseRegistrationRequest request, CancellationToken cancellationToken)
    {
        
    }
}