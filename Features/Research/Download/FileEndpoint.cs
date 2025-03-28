using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Download.Models;

namespace iSchool_Solution.Features.Research.Download;

/// <summary>
/// Endpoint for downloading the actual research document file
/// </summary>
[Authorize]
public class FileEndpoint : Endpoint<DownloadResearchDocumentRequest>
{
    private readonly ILogger<FileEndpoint> _logger;
    private readonly ResearchService _researchService;

    public FileEndpoint(ILogger<FileEndpoint> logger, ResearchService researchService)
    {
        _logger = logger;
        _researchService = researchService;
    }

    public override void Configure()
    {
        Get("api/research/documents/{DocumentID}/download");
        Description(description => description
            .WithName("DownloadResearchDocument")
            .WithSummary("Downloads a research document file")
            .WithTags("Research")
            .ProducesProblem(401)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(DownloadResearchDocumentRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Processing file download request - Document ID: {DocumentID}", request.DocumentID);
            
            var (fileContents, contentType, fileName) = await _researchService.DownloadDocumentAsync(request.DocumentID);
            
            _logger.LogInformation("File download successful - Document ID: {DocumentID}, Size: {Size} bytes", 
                request.DocumentID, fileContents.Length);
            
            await SendBytesAsync(
                fileContents,
                contentType,
                fileName
                );
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Document not found during download - Document ID: {DocumentID}", request.DocumentID);
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError(ex, "Document file not found on server - Document ID: {DocumentID}", request.DocumentID);
            AddError("The requested document file could not be found on the server");
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error downloading document - Document ID: {DocumentID}", request.DocumentID);
            AddError("An unexpected error occurred during document download");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}