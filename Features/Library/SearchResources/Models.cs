using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Library.SearchResources;

public class Models
{
    public class SearchResourcesRequest
    {
        public string? Query { get; set; } // Search text (Title, Author, ISBN, etc.)
        public string? Category { get; set; }
        public ResourceType? ResourceType { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SearchResourcesResponse
    {
        public List<LibraryResourceSummary> Resources { get; set; } = [];
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }

    public class LibraryResourceSummary
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public ResourceType ResourceType { get; set; }
        public bool IsAvailable { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}