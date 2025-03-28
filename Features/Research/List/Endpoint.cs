using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Repository;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Research.List.Models;

namespace iSchool_Solution.Features.Research.List;

/// <summary>
/// Endpoint for retrieving a paginated list of research projects with optional filtering
/// </summary>
[Authorize]
public class Endpoint : Endpoint<ListResearchProjectsRequest, ListResearchProjectsResponse>
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
        Get("api/research/projects");
        Description(description => description
            .WithName("ListResearchProjects")
            .WithSummary("Gets a paginated list of research projects with optional filtering")
            .WithTags("Research")
            .Produces<ListResearchProjectsResponse>(200, "application/json")
            .ProducesProblem(401)
            .ProducesProblem(403)
            .ProducesProblemFE(500));
    }

    public override async Task HandleAsync(ListResearchProjectsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var userId = request.MyProjectsOnly ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            
            _logger.LogInformation("Retrieving research projects - Filters: Department={Department}, Status={Status}, Page={Page}, Projects for user: {UserProjects}",
                request.Department, request.Status, request.Page, request.MyProjectsOnly);

            // Calculate skip for pagination
            int skip = (request.Page - 1) * request.PageSize;
            
            // Get filtered projects
            var projects = await _researchRepository.GetResearchProjectsAsync(
                userId,
                request.Department,
                request.Status,
                skip,
                request.PageSize);
            
            // Get total count for pagination info
            var totalCount = await _researchRepository.GetResearchProjectsCountAsync(
                userId,
                request.Department,
                request.Status);
            
            // Map to response models
            var projectItems = projects.Select(p => new ResearchProjectListItem
            {
                ProjectID = p.Id,
                Title = p.Title,
                MainAuthorName = p.MainAuthor?.UserName ?? "Unknown",
                DateSubmitted = p.DateSubmitted,
                Status = p.Status,
                Department = p.Department,
                Contributors = p.Contributors.Select(c => new ContributorSummary
                {
                    ContributorID = c.ResearchContributorID,
                    Name = c.Contributor?.UserName ?? "Unknown",
                    Role = c.Role
                }).ToList()
            }).ToList();

            var response = new ListResearchProjectsResponse
            {
                Projects = projectItems,
                TotalCount = totalCount,
                CurrentPage = request.Page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
            };

            _logger.LogInformation("Retrieved {Count} research projects (Page {Page}/{TotalPages})", 
                projectItems.Count, response.CurrentPage, response.TotalPages);
            
            await SendOkAsync(response, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving research projects");
            AddError("An unexpected error occurred while retrieving research projects");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}