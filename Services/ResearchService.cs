using iSchool_Solution.Entities;
using iSchool_Solution.Repository;
using System.Diagnostics;
using static iSchool_Solution.Features.Research.Download.Models;
using static iSchool_Solution.Features.Research.Upload.Models;

namespace iSchool_Solution.Services;

public class ResearchService
{
    private readonly ResearchRepository _researchRepository;
    private readonly ILogger<ResearchService> _logger;
    private readonly IWebHostEnvironment _environment;

    public ResearchService(
        ResearchRepository researchRepository,
        ILogger<ResearchService> logger,
        IWebHostEnvironment environment)
    {
        _researchRepository = researchRepository;
        _logger = logger;
        _environment = environment;
    }

    public async Task<UploadResearchDocumentResponse> UploadDocumentAsync(
        UploadResearchDocumentRequest request,
        string uploadedBy)
    {
        var stopwatch = Stopwatch.StartNew();
        _logger.LogInformation("Starting document upload process - Project ID: {ProjectId}, Title: {Title}, User: {User}",
            request.ProjectId, request.DocumentTitle, uploadedBy);

        try
        {
            // 1. Validate the project exists
            _logger.LogDebug("Validating project existence - Project ID: {ProjectId}", request.ProjectId);
            var project = await _researchRepository.GetResearchProjectByIdAsync(request.ProjectId);

            if (project == null)
            {
                _logger.LogWarning("Upload failed - Project with ID {ProjectId} not found", request.ProjectId);
                throw new KeyNotFoundException($"Research project with ID {request.ProjectId} not found");
            }

            _logger.LogDebug("Project validation successful - Project: {ProjectId} - {Title}",
                project.Id, project.Title);

            // 2. Save the file to disk
            var originalFileName = request.File.FileName;
            var fileExtension = Path.GetExtension(originalFileName);
            var uniqueFileName = Guid.NewGuid() + fileExtension;
            var documentsPath = Path.Combine(_environment.ContentRootPath, "uploads", "research");

            _logger.LogDebug("Preparing to save file - Original name: {OriginalFileName}, Size: {Size} bytes, Type: {ContentType}",
                originalFileName, request.File.Length, request.File.ContentType);

            // Ensure directory exists
            if (!Directory.Exists(documentsPath))
            {
                _logger.LogInformation("Creating research uploads directory: {Path}", documentsPath);
                Directory.CreateDirectory(documentsPath);
            }

            var filePath = Path.Combine(documentsPath, uniqueFileName);
            _logger.LogDebug("File will be saved to: {FilePath}", filePath);

            // Track file save performance
            var fileStopwatch = Stopwatch.StartNew();

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            fileStopwatch.Stop();
            _logger.LogInformation("File saved successfully in {ElapsedMs}ms - Path: {FilePath}, Size: {Size} bytes",
                fileStopwatch.ElapsedMilliseconds, filePath, request.File.Length);

            // 3. Create document entity
            _logger.LogDebug("Creating document database entity");
            var document = new ResearchDocument
            {
                ResearchProjectID = request.ProjectId,
                DocumentTitle = request.DocumentTitle,
                Description = request.Description,
                FilePath = filePath,
                FileType = request.File.ContentType,
                FileSize = request.File.Length,
                UploadDate = DateTimeOffset.UtcNow,
                UploadedBy = uploadedBy,
                DownloadCount = 0
            };

            // 4. Save to database
            _logger.LogDebug("Saving document metadata to database");
            var documentID = await _researchRepository.AddDocumentAsync(document);

            stopwatch.Stop();
            _logger.LogInformation("Document upload completed successfully in {TotalElapsedMs}ms - Document ID: {DocumentId}",
                stopwatch.ElapsedMilliseconds, document.Id);

            // 5. Return response
            return new UploadResearchDocumentResponse
            {
                DocumentId = document.Id,
                DocumentTitle = document.DocumentTitle,
                FileName = originalFileName,
                FileSize = document.FileSize,
                FileType = document.FileType,
                UploadDate = document.UploadDate,
                UploadedBy = document.UploadedBy
            };
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            _logger.LogError(ex, "Document upload failed after {ElapsedMs}ms - Project ID: {ProjectId}, Title: {Title}, User: {User}",
                stopwatch.ElapsedMilliseconds, request.ProjectId, request.DocumentTitle, uploadedBy);
            throw;
        }
    }

    public async Task<DownloadResearchDocumentResponse> GetDocumentDownloadInfoAsync(int documentID)
    {
        _logger.LogInformation("Getting download info for document ID: {DocumentId}", documentID);

        try
        {
            var document = await _researchRepository.GetResearchDocumentByIdAsync(documentID);
            if (document == null)
            {
                _logger.LogWarning("Download info request failed - Document with ID {DocumentId} not found", documentID);
                throw new KeyNotFoundException($"Research document with ID {documentID} not found");
            }

            // Generate document URL
            var fileName = Path.GetFileName(document.FilePath);
            var fileUrl = $"/api/research/documents/{documentID}/download";

            _logger.LogDebug("Generated download URL: {FileUrl} for document: {DocumentId}", fileUrl, documentID);

            // Increment download count
            await _researchRepository.IncrementDownloadCountAsync(documentID);

            _logger.LogInformation("Download info retrieved successfully for document: {DocumentId} - {Title}",
                document.Id, document.DocumentTitle);

            return new DownloadResearchDocumentResponse
            {
                DocumentID = document.Id,
                DocumentTitle = document.DocumentTitle,
                FileName = fileName,
                FileType = document.FileType,
                FileUrl = fileUrl,
                FileSize = document.FileSize,
                DownloadCount = document.DownloadCount + 1 // Add 1 for the current download
            };
        }
        catch (Exception ex) when (!(ex is KeyNotFoundException))
        {
            _logger.LogError(ex, "Error retrieving download info for document: {DocumentId}", documentID);
            throw;
        }
    }

    public async Task<(byte[] FileContents, string ContentType, string FileName)> DownloadDocumentAsync(int documentId)
    {
        var stopwatch = Stopwatch.StartNew();
        _logger.LogInformation("Processing download request for document ID: {DocumentId}", documentId);

        try
        {
            var document = await _researchRepository.GetResearchDocumentByIdAsync(documentId);
            if (document == null)
            {
                _logger.LogWarning("Download failed - Document with ID {DocumentId} not found", documentId);
                throw new KeyNotFoundException($"Research document with ID {documentId} not found");
            }

            _logger.LogDebug("Document found: {DocumentId} - {Title}, Path: {FilePath}",
                document.Id, document.DocumentTitle, document.FilePath);

            if (!File.Exists(document.FilePath))
            {
                _logger.LogError("Document file not found on server - Document ID: {DocumentId}, Expected path: {FilePath}",
                    documentId, document.FilePath);
                throw new FileNotFoundException($"Research document file not found on server", document.FilePath);
            }

            _logger.LogDebug("Reading file contents from: {FilePath}", document.FilePath);
            var fileStopwatch = Stopwatch.StartNew();
            var fileContents = await File.ReadAllBytesAsync(document.FilePath);
            fileStopwatch.Stop();

            _logger.LogDebug("File read completed in {ElapsedMs}ms - Size: {Size} bytes",
                fileStopwatch.ElapsedMilliseconds, fileContents.Length);

            var fileName = Path.GetFileName(document.FilePath);

            await _researchRepository.IncrementDownloadCountAsync(documentId);

            stopwatch.Stop();
            _logger.LogInformation("Download processed successfully in {TotalElapsedMs}ms - Document: {DocumentId}, Size: {Size} bytes",
                stopwatch.ElapsedMilliseconds, documentId, fileContents.Length);

            return (fileContents, document.FileType, fileName);
        }
        catch (Exception ex) when (!(ex is KeyNotFoundException || ex is FileNotFoundException))
        {
            stopwatch.Stop();
            _logger.LogError(ex, "Unexpected error during document download after {ElapsedMs}ms - Document ID: {DocumentId}",
                stopwatch.ElapsedMilliseconds, documentId);
            throw;
        }
    }

    public async Task<bool> DeleteDocumentAsync(int documentId, string userId)
    {
        _logger.LogInformation("Processing document deletion request - Document ID: {DocumentId}, User: {UserId}",
            documentId, userId);

        try
        {
            var document = await _researchRepository.GetResearchDocumentByIdAsync(documentId);
            if (document == null)
            {
                _logger.LogWarning("Deletion failed - Document with ID {DocumentId} not found", documentId);
                throw new KeyNotFoundException($"Research document with ID {documentId} not found");
            }

            // Check if user is author or contributor
            var project = document.Project;
            bool isAuthorized = project.MainAuthorID == userId ||
                              project.Contributors.Any(c => c.ResearchContributorID == userId);

            _logger.LogDebug("Authorization check for document deletion - User: {UserId}, IsAuthor: {IsAuthor}, IsContributor: {IsContributor}",
                userId, project.MainAuthorID == userId, project.MainAuthorID != userId && isAuthorized);

            if (!isAuthorized)
            {
                _logger.LogWarning("Unauthorized document deletion attempt - Document: {DocumentId}, User: {UserId}",
                    documentId, userId);
                throw new UnauthorizedAccessException("You are not authorized to delete this document");
            }

            // Delete the file if it exists
            if (File.Exists(document.FilePath))
            {
                _logger.LogDebug("Deleting file from disk: {FilePath}", document.FilePath);
                File.Delete(document.FilePath);
                _logger.LogInformation("File successfully deleted from disk: {FilePath}", document.FilePath);
            }
            else
            {
                _logger.LogWarning("Document file not found on disk during deletion - Path: {FilePath}", document.FilePath);
            }

            _logger.LogDebug("Removing document record from database: {DocumentId}", documentId);
            await _researchRepository.DeleteDocumentAsync(documentId);

            _logger.LogInformation("Document successfully deleted - ID: {DocumentId}, Title: {Title}",
                documentId, document.DocumentTitle);

            return true;
        }
        catch (Exception ex) when (!(ex is KeyNotFoundException || ex is UnauthorizedAccessException))
        {
            _logger.LogError(ex, "Unexpected error during document deletion - Document ID: {DocumentId}, User: {UserId}",
                documentId, userId);
            throw;
        }
    }
}