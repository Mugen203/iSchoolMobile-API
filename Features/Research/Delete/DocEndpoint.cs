using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Delete.Models;

namespace iSchool_Solution.Features.Research.Delete;

/// <summary>
/// Endpoint for deleting a research document
/// </summary>
[Authorize]
public class DocEndpoint : Endpoint<DeleteResearchDocumentRequest, DeleteResponse>
{
    private readonly ILogger<DocEndpoint> _logger;
    private readonly ResearchService _researchService;

    public DocEndpoint(ILogger<DocEndpoint> logger, ResearchService researchService)
    {
        _logger = logger;
        _researchService = researchService;
    }

    public override void Configure()
    {
        Delete("api/research/documents/{DocumentID}");
        Description(description => description
            .WithName("DeleteResearchDocument")
            .WithSummary("Deletes a research document")
            .WithTags("Research")
            .Produces<DeleteResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(DeleteResearchDocumentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("User ID not found in claims during document deletion");
                AddError("User ID is required but not found");
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
                return;
            }

            _logger.LogInformation("Processing document deletion request - Document ID: {DocumentID}, User: {UserID}", 
                request.DocumentID, userId);
            
            var result = await _researchService.DeleteDocumentAsync(request.DocumentID, userId);
            
            var response = new DeleteResponse
            {
                Success = result,
                Message = result 
                    ? "Document successfully deleted" 
                    : "Document deletion failed"
            };
            
            _logger.LogInformation("Document deletion completed - Document ID: {DocumentID}, Success: {Success}", 
                request.DocumentID, result);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Document not found - Document ID: {DocumentID}", request.DocumentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized document deletion attempt - Document ID: {DocumentID}", request.DocumentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status403Forbidden, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting document - Document ID: {DocumentID}", request.DocumentID);
            AddError("An unexpected error occurred while deleting the document");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}