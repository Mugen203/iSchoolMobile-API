using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Repository;

public class LibraryRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<LibraryRepository> _logger;

    public LibraryRepository(ApplicationDbContext context, ILogger<LibraryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<LibraryResource>> SearchResourcesAsync(
        string? queryText,
        string? category,
        ResourceType? resourceType,
        int skip,
        int take)
    {
        _logger.LogDebug("Searching library resources. Query: '{Query}', Category: '{Category}', Type: {Type}, Skip: {Skip}, Take: {Take}",
            queryText ?? "N/A", category ?? "N/A", resourceType?.ToString() ?? "N/A", skip, take);

        var query = _context.LibraryResources.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryText))
        {
            query = query.Where(r => r.Title.Contains(queryText) || r.Author.Contains(queryText) || r.ISBN.Contains(queryText) || r.Description.Contains(queryText));
        }
        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(r => r.Category == category);
        }
        if (resourceType.HasValue)
        {
            query = query.Where(r => r.ResourceType == resourceType.Value);
        }

        return await query
            .OrderBy(r => r.Title)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<int> GetResourceCountAsync(
        string? queryText,
        string? category,
        ResourceType? resourceType)
    {
        _logger.LogDebug("Counting library resources. Query: '{Query}', Category: '{Category}', Type: {Type}",
            queryText ?? "N/A", category ?? "N/A", resourceType?.ToString() ?? "N/A");

        var query = _context.LibraryResources.AsQueryable();

        if (!string.IsNullOrWhiteSpace(queryText))
        {
            query = query.Where(r => r.Title.Contains(queryText) || r.Author.Contains(queryText) || r.ISBN.Contains(queryText) || r.Description.Contains(queryText));
        }
        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(r => r.Category == category);
        }
        if (resourceType.HasValue)
        {
            query = query.Where(r => r.ResourceType == resourceType.Value);
        }

        return await query.CountAsync();
    }


    public async Task<List<ResourceBorrowing>> GetBorrowedByStudentAsync(string studentId)
    {
        _logger.LogDebug("Fetching borrowed resources for StudentID: {StudentID}", studentId);
        return await _context.ResourceBorrowings
            .Include(rb => rb.Resource) // Include the resource details
            .Where(rb => rb.StudentId == studentId && rb.Status == BorrowStatus.Borrowed) // Only currently borrowed
            .OrderBy(rb => rb.DueDate)
            .ToListAsync();
    }

    public async Task<LibraryResource?> GetResourceByIdAsync(int resourceId)
    {
        return await _context.LibraryResources.FindAsync(resourceId);
    }
}