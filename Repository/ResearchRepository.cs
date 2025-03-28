using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Entities.DTO.Research;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace iSchool_Solution.Repository;

public class ResearchRepository
{
    private readonly ILogger<ResearchRepository> _logger;
    private readonly ApplicationDbContext _context;

    public ResearchRepository(ILogger<ResearchRepository> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Research Project methods
    public async Task<ResearchProject?> GetResearchProjectByIdAsync(int projectID)
    {
        _logger.LogInformation("Getting research project with ID: {ProjectId}", projectID);

        var project = await _context.ResearchProjects
            .Include(rp => rp.MainAuthor)
            .Include(rp => rp.Contributors)
                .ThenInclude(rc => rc.Contributor)
            .Include(rp => rp.Documents)
            .FirstOrDefaultAsync(rp => rp.Id == projectID);

        if (project == null)
        {
            _logger.LogWarning("Research project with ID {ProjectId} not found", projectID);
        }
        else
        {
            _logger.LogInformation("Successfully retrieved research project: {ProjectId} - {Title}",
                project.Id, project.Title);
        }

        return project;
    }

    public async Task<List<ResearchProject>> GetResearchProjectsAsync(
        string? userId = null,
        string? department = null,
        ResearchStatus? status = null,
        int skip = 0,
        int take = 10)
    {
        _logger.LogInformation("Getting research projects with filters - UserId: {UserId}, Department: {Department}, Status: {Status}, Skip: {Skip}, Take: {Take}",
            userId ?? "None", department ?? "None", status?.ToString() ?? "None", skip, take);

        var stopwatch = Stopwatch.StartNew();

        var query = _context.ResearchProjects
            .Include(rp => rp.MainAuthor)
            .Include(rp => rp.Contributors)
                .ThenInclude(rc => rc.Contributor)
            .AsQueryable();

        // Filter by main author
        if (!string.IsNullOrEmpty(userId))
        {
            _logger.LogDebug("Filtering projects by user ID: {UserId}", userId);
            query = query.Where(rp => rp.MainAuthorID == userId ||
                                     rp.Contributors.Any(c => c.ResearchContributorID == userId));
        }

        // Filter by department
        if (!string.IsNullOrEmpty(department))
        {
            _logger.LogDebug("Filtering projects by department: {Department}", department);
            query = query.Where(rp => rp.Department == department);
        }

        // Filter by status
        if (status.HasValue)
        {
            _logger.LogDebug("Filtering projects by status: {Status}", status.Value);
            query = query.Where(rp => rp.Status == status.Value);
        }

        var results = await query
            .OrderByDescending(rp => rp.DateSubmitted)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        stopwatch.Stop();
        _logger.LogInformation("Retrieved {Count} research projects in {ElapsedMs}ms",
            results.Count, stopwatch.ElapsedMilliseconds);

        return results;
    }
    
    public async Task<int> GetResearchProjectsCountAsync(
        string? userId = null, 
        string? department = null,
        ResearchStatus? status = null)
    {
        _logger.LogInformation("Getting research projects count with filters - UserId: {UserId}, Department: {Department}, Status: {Status}",
            userId ?? "None", department ?? "None", status?.ToString() ?? "None");

        var query = _context.ResearchProjects.AsQueryable();
    
        // Filter by main author
        if (!string.IsNullOrEmpty(userId))
        {
            query = query.Where(rp => rp.MainAuthorID == userId ||
                                      rp.Contributors.Any(c => c.ResearchContributorID == userId));
        }
    
        // Filter by department
        if (!string.IsNullOrEmpty(department))
        {
            query = query.Where(rp => rp.Department == department);
        }
    
        // Filter by status
        if (status.HasValue)
        {
            query = query.Where(rp => rp.Status == status.Value);
        }
    
        int count = await query.CountAsync();
    
        _logger.LogInformation("Total research projects count: {Count}", count);
    
        return count;
    }

    public async Task<int> CreateResearchProjectAsync(ResearchProject project)
    {
        _logger.LogInformation("Creating new research project: {Title} by author {AuthorId}",
            project.Title, project.MainAuthorID);

        try
        {
            _context.ResearchProjects.Add(project);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully created research project with ID: {ProjectId}", project.Id);
            return project.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating research project: {Title}", project.Title);
            throw;
        }
    }

    public async Task UpdateResearchProjectAsync(ResearchProject project)
    {
        _logger.LogInformation("Updating research project: {ProjectId} - {Title}", project.Id, project.Title);

        try
        {
            _context.ResearchProjects.Update(project);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully updated research project: {ProjectId}", project.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating research project: {ProjectId}", project.Id);
            throw;
        }
    }

    public async Task DeleteResearchProjectAsync(int projectId)
    {
        _logger.LogInformation("Deleting research project with ID: {ProjectId}", projectId);

        try
        {
            var project = await _context.ResearchProjects.FindAsync(projectId);
            if (project != null)
            {
                _context.ResearchProjects.Remove(project);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully deleted research project: {ProjectId} - {Title}",
                    projectId, project.Title);
            }
            else
            {
                _logger.LogWarning("Unable to delete research project {ProjectId} - not found", projectId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting research project: {ProjectId}", projectId);
            throw;
        }
    }

    // Document methods
    public async Task<ResearchDocument?> GetResearchDocumentByIdAsync(int documentID)
    {
        _logger.LogInformation("Getting research document with ID: {DocumentId}", documentID);

        var document = await _context.Set<ResearchDocument>()
            .Include(rd => rd.Project)
            .FirstOrDefaultAsync(rd => rd.Id == documentID);

        if (document == null)
        {
            _logger.LogWarning("Research document with ID {DocumentId} not found", documentID);
        }
        else
        {
            _logger.LogInformation("Successfully retrieved research document: {DocumentId} - {Title}",
                document.Id, document.DocumentTitle);
        }

        return document;
    }

    public async Task<List<ResearchDocument>> GetDocumentsByProjectIdAsync(int projectID)
    {
        _logger.LogInformation("Getting documents for research project ID: {ProjectId}", projectID);

        var documents = await _context.Set<ResearchDocument>()
            .Where(rd => rd.ResearchProjectID == projectID)
            .ToListAsync();

        _logger.LogInformation("Retrieved {Count} documents for project {ProjectId}",
            documents.Count, projectID);

        return documents;
    }

    public async Task<int> AddDocumentAsync(ResearchDocument document)
    {
        _logger.LogInformation("Adding new document '{Title}' to project {ProjectId}",
            document.DocumentTitle, document.ResearchProjectID);

        try
        {
            _context.Set<ResearchDocument>().Add(document);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully added document with ID: {DocumentId} to project {ProjectId}",
                document.Id, document.ResearchProjectID);

            return document.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding document '{Title}' to project {ProjectId}",
                document.DocumentTitle, document.ResearchProjectID);
            throw;
        }
    }

    public async Task UpdateDocumentAsync(ResearchDocument document)
    {
        _logger.LogInformation("Updating document: {DocumentId} - {Title}",
            document.Id, document.DocumentTitle);

        try
        {
            _context.Set<ResearchDocument>().Update(document);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully updated document: {DocumentId}", document.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating document: {DocumentId}", document.Id);
            throw;
        }
    }

    public async Task DeleteDocumentAsync(int documentID)
    {
        _logger.LogInformation("Deleting document with ID: {DocumentId}", documentID);

        try
        {
            var document = await _context.Set<ResearchDocument>().FindAsync(documentID);
            if (document != null)
            {
                _context.Set<ResearchDocument>().Remove(document);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Successfully deleted document: {DocumentId} - {Title}",
                    documentID, document.DocumentTitle);
            }
            else
            {
                _logger.LogWarning("Unable to delete document {DocumentId} - not found", documentID);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting document: {DocumentId}", documentID);
            throw;
        }
    }

    public async Task IncrementDownloadCountAsync(int documentID)
    {
        _logger.LogDebug("Incrementing download count for document ID: {DocumentId}", documentID);

        try
        {
            var document = await _context.Set<ResearchDocument>().FindAsync(documentID);
            if (document != null)
            {
                document.DownloadCount++;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Download count for document {DocumentId} incremented to {Count}",
                    documentID, document.DownloadCount);
            }
            else
            {
                _logger.LogWarning("Cannot increment download count - document {DocumentId} not found", documentID);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error incrementing download count for document: {DocumentId}", documentID);
            throw;
        }
    }

    // Contributor methods
    public async Task<List<ResearchContributor>> GetContributorsByProjectIdAsync(int projectID)
    {
        _logger.LogInformation("Getting contributors for research project ID: {ProjectId}", projectID);

        var contributors = await _context.Set<ResearchContributor>()
            .Include(rc => rc.Contributor)
            .Where(rc => rc.ResearchProjectID == projectID)
            .ToListAsync();

        _logger.LogInformation("Retrieved {Count} contributors for project {ProjectId}",
            contributors.Count, projectID);

        return contributors;
    }

    public async Task AddContributorAsync(ResearchContributor contributor)
    {
        _logger.LogInformation("Adding contributor {ContributorId} to project {ProjectId}",
            contributor.ResearchContributorID, contributor.ResearchProjectID);

        try
        {
            _context.Set<ResearchContributor>().Add(contributor);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Successfully added contributor {ContributorId} to project {ProjectId}",
                contributor.ResearchContributorID, contributor.ResearchProjectID);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding contributor {ContributorId} to project {ProjectId}",
                contributor.ResearchContributorID, contributor.ResearchProjectID);
            throw;
        }
    }

    public async Task RemoveContributorAsync(int contributorID)
    {
        _logger.LogInformation("Removing contributor with ID: {ContributorId}", contributorID);

        try
        {
            var contributor = await _context.Set<ResearchContributor>().FindAsync(contributorID);
            if (contributor != null)
            {
                _context.Set<ResearchContributor>().Remove(contributor);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Successfully removed contributor {ContributorId} from project {ProjectId}",
                    contributorID, contributor.ResearchProjectID);
            }
            else
            {
                _logger.LogWarning("Unable to remove contributor {ContributorId} - not found", contributorID);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing contributor: {ContributorId}", contributorID);
            throw;
        }
    }
}