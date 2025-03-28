using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Repository;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Delete.Models;

namespace iSchool_Solution.Features.Research.Delete;

/// <summary>
/// Endpoint for deleting an entire research project
/// </summary>
[Authorize]
public class ProjectEndpoint : Endpoint<DeleteResearchProjectRequest, DeleteResponse>
{
    private readonly ILogger<ProjectEndpoint> _logger;
    private readonly ResearchRepository _researchRepository;

    public ProjectEndpoint(ILogger<ProjectEndpoint> logger, ResearchRepository researchRepository)
    {
        _logger = logger;
        _researchRepository = researchRepository;
    }

    public override void Configure()
    {
        Delete("api/research/projects/{ProjectID}");
        Description(description => description
            .WithName("DeleteResearchProject")
            .WithSummary("Deletes a research project and all associated documents")
            .WithTags("Research")
            .Produces<DeleteResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(DeleteResearchProjectRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                _logger.LogWarning("User ID not found in claims during project deletion");
                AddError("User ID is required but not found");
                await SendErrorsAsync(StatusCodes.Status401Unauthorized, cancellationToken);
                return;
            }

            _logger.LogInformation("Processing project deletion request - Project ID: {ProjectID}, User: {UserID}", 
                request.ProjectID, userId);
            
            // Verify the user is authorized to delete this project (main author only)
            var project = await _researchRepository.GetResearchProjectByIdAsync(request.ProjectID);
            
            if (project == null)
            {
                _logger.LogWarning("Project not found - Project ID: {ProjectID}", request.ProjectID);
                AddError($"Research project with ID {request.ProjectID} not found");
                await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
                return;
            }
            
            if (project.MainAuthorID != userId && !User.IsInRole("Admin"))
            {
                _logger.LogWarning("Unauthorized project deletion attempt - Project ID: {ProjectID}, User: {UserID}", 
                    request.ProjectID, userId);
                AddError("Only the main author or an administrator can delete a research project");
                await SendErrorsAsync(StatusCodes.Status403Forbidden, cancellationToken);
                return;
            }
            
            // Delete all documents associated with the project first
            // Note: This might be handled by cascade delete in the database,
            // but we need to ensure file system files are cleaned up too
            foreach (var document in project.Documents)
            {
                if (File.Exists(document.FilePath))
                {
                    File.Delete(document.FilePath);
                    _logger.LogInformation("Deleted document file - Path: {FilePath}", document.FilePath);
                }
            }
            
            // Now delete the project
            await _researchRepository.DeleteResearchProjectAsync(request.ProjectID);
            
            var response = new DeleteResponse
            {
                Success = true,
                Message = "Research project successfully deleted"
            };
            
            _logger.LogInformation("Project deletion completed - Project ID: {ProjectID}", request.ProjectID);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting project - Project ID: {ProjectID}", request.ProjectID);
            AddError("An unexpected error occurred while deleting the research project");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}