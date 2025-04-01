using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Library.SearchResources.Models;

namespace iSchool_Solution.Features.Library.SearchResources;

[Authorize] // All authenticated users can search
public class Endpoint : Endpoint<SearchResourcesRequest, SearchResourcesResponse>
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
        Get("/api/library/resources");
        Description(d => d
            .WithName("SearchLibraryResources")
            .WithSummary("Searches or lists available library resources with pagination.")
            .WithTags("Library")
            .Produces<SearchResourcesResponse>(200)
            .ProducesProblem(401)
            .ProducesProblemFE(500)
        );
        // Define query parameter bindings explicitly for Swagger documentation
    }

    public override async Task HandleAsync(SearchResourcesRequest req, CancellationToken ct)
    {
        _logger.LogInformation("Handling library resource search request. Query: '{Query}'", req.Query ?? "None");
        try
        {
            var response = await _libraryService.SearchResourcesAsync(req);
            await SendOkAsync(response, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching library resources.");
            AddError("An unexpected error occurred while searching for resources.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
        }
    }
}