using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Library.BorrowedResources.Models;

namespace iSchool_Solution.Features.Library.BorrowedResources;

[Authorize]
public class Endpoint : EndpointWithoutRequest<MyBorrowedResourcesResponse>
{
    private readonly LibraryService _libraryService;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(LibraryService libraryService, ILogger<Endpoint> logger)
    {
        _libraryService = libraryService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/student/library/borrowed");
        Roles("Student"); // Only students can see their own borrowed items
        Description(d => d
            .WithName("GetMyBorrowedResources")
            .WithSummary("Retrieves the list of resources currently borrowed by the student.")
            .WithTags("Library", "Student")
            .Produces<MyBorrowedResourcesResponse>(200)
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblemFE(500)
        );
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var studentID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentID))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Fetching borrowed resources for StudentID: {StudentID}", studentID);

        try
        {
            var response = await _libraryService.GetStudentBorrowedResourcesAsync(studentID);
            await SendOkAsync(response, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching borrowed resources for StudentID: {StudentID}", studentID);
            AddError("An unexpected error occurred while retrieving borrowed resources.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}