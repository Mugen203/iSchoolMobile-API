using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Download.Models;

namespace iSchool_Solution.Features.Research.Download;

/// <summary>
/// Endpoint for downloading research documents
/// </summary>
[Authorize]
public class Endpoint : Endpoint<DownloadResearchDocumentRequest, DownloadResearchDocumentResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly ResearchService _researchService;

    public Endpoint(ILogger<Endpoint> logger, ResearchService researchService)
    {
        _logger = logger;
        _researchService = researchService;
    }

    public override void Configure()
    {
        Get("api/research/documents/{DocumentID}/info");
        Description(description => description
            .WithName("GetResearchDocumentDownloadInfo")
            .WithSummary("Gets information for downloading a research document")
            .WithTags("Research")
            .Produces<DownloadResearchDocumentResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(DownloadResearchDocumentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Getting download info for document ID: {DocumentID}", request.DocumentID);
            
            var response = await _researchService.GetDocumentDownloadInfoAsync(request.DocumentID);
            
            _logger.LogInformation("Successfully retrieved download info for document ID: {DocumentID}", request.DocumentID);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Document not found - Document ID: {DocumentID}", request.DocumentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving document download info - Document ID: {DocumentID}", request.DocumentID);
            AddError("An unexpected error occurred while retrieving document information");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}