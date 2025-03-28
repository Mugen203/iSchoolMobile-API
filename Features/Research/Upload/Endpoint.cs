using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Upload.Models;

namespace iSchool_Solution.Features.Research.Upload;

/// <summary>
/// Endpoint for uploading a document to a research project
/// </summary>
[Authorize]
public class Endpoint : Endpoint<UploadResearchDocumentRequest, UploadResearchDocumentResponse>
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
        Post("api/research/projects/{ProjectId}/documents");
        AllowFileUploads();
        Description(description => description
            .WithName("UploadResearchDocument")
            .WithSummary("Uploads a document to a research project")
            .WithTags("Research")
            .Produces<UploadResearchDocumentResponse>(200, "application/json")
            .ProducesProblem(400)
            .ProducesProblem(401)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(UploadResearchDocumentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("User ID not found in claims during document upload");
                AddError("User ID is required but not found");
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
                return;
            }

            _logger.LogInformation("Processing document upload - Project ID: {ProjectId}, Document: {DocumentTitle}, User: {UserId}",
                request.ProjectId, request.DocumentTitle, userId);

            var response = await _researchService.UploadDocumentAsync(request, userId);
            
            _logger.LogInformation("Document upload successful - Document ID: {DocumentId}, Project ID: {ProjectId}",
                response.DocumentId, request.ProjectId);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Project not found during document upload - Project ID: {ProjectId}", request.ProjectId);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during document upload - Project ID: {ProjectId}, Document: {DocumentTitle}",
                request.ProjectId, request.DocumentTitle);
            AddError("An unexpected error occurred during document upload");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}