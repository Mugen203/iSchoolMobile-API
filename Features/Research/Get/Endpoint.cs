using FastEndpoints;
using iSchool_Solution.Repository;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.Get.Models;

namespace iSchool_Solution.Features.Research.Get;

/// <summary>
/// Endpoint for retrieving detailed information about a specific research project
/// </summary>
[Authorize]
public class Endpoint : Endpoint<GetResearchProjectRequest, GetResearchProjectResponse>
{
    private readonly ILogger<Endpoint> _logger;
    private readonly ResearchRepository _researchRepository;

    public Endpoint(ILogger<Endpoint> logger, ResearchRepository researchRepository)
    {
        _logger = logger;
        _researchRepository = researchRepository;
    }

    public override void Configure()
    {
        Get("api/research/projects/{ProjectID}");
        Description(description => description
            .WithName("GetResearchProject")
            .WithSummary("Gets detailed information about a specific research project")
            .WithTags("Research")
            .Produces<GetResearchProjectResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(404)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(GetResearchProjectRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Retrieving research project details - Project ID: {ProjectID}", request.ProjectID);
            
            var project = await _researchRepository.GetResearchProjectByIdAsync(request.ProjectID);
            
            if (project == null)
            {
                _logger.LogWarning("Research project not found - Project ID: {ProjectID}", request.ProjectID);
                AddError($"Research project with ID {request.ProjectID} not found");
                await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
                return;
            }

            var response = new GetResearchProjectResponse
            {
                Project = new ResearchProjectDetails
                {
                    ProjectID = project.Id,
                    Title = project.Title,
                    Abstract = project.Abstract,
                    Keywords = project.Keywords,
                    DateSubmitted = project.DateSubmitted,
                    Status = project.Status,
                    Department = project.Department,
                    MainAuthor = project.MainAuthor.UserName ?? "Unknown",
                    Contributors = project.Contributors.Select(c => new ResearchProjectContributorDetails
                    {
                        ProjectID = c.ResearchProjectID,
                        ResearchContributorID = c.ResearchContributorID,
                        ContributorName = c.Contributor.UserName ?? "Unknown",
                        Role = c.Role,
                        ContributionDetails = c.ContributionDetails
                    }).ToList(),
                    Documents = project.Documents.Select(d => new ResearchProjectDocumentDetails
                    {
                        DocumentID = d.Id,
                        ResearchProjectID = d.ResearchProjectID,
                        DocumentTitle = d.DocumentTitle,
                        FileType = d.FileType,
                        FilePath = d.FilePath,
                        FileSize = d.FileSize,
                        UploadDate = d.UploadDate,
                        UploadedBy = d.UploadedBy,
                        Description = d.Description,
                        DownloadCount = d.DownloadCount
                    }).ToList()
                }
            };

            _logger.LogInformation("Successfully retrieved research project - Project ID: {ProjectID}, Title: {Title}",
                project.Id, project.Title);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving research project - Project ID: {ProjectID}", request.ProjectID);
            AddError("An unexpected error occurred while retrieving the research project");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}