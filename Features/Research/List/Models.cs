
using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Research.List;

public class Models
{
    public class ListResearchProjectsRequest
    {
        public string? Department { get; set; }
        public ResearchStatus? Status { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool MyProjectsOnly { get; set; } = false;
    }
    
    public class ListResearchProjectsResponse
    {
        public List<ResearchProjectListItem> Projects { get; set; } = [];
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    
    public class ResearchProjectListItem
    {
        public int ProjectID {get; set;}
        public string Title {get; set;}
        public string MainAuthorName {get; set;}
        public DateTimeOffset DateSubmitted {get; set;}
        public ResearchStatus Status {get; set;}
        public string Department {get; set;}
        public List<ContributorSummary> Contributors {get; set;} = [];
    }

    public class ContributorSummary
    {
        public string ContributorID {get; set;}
        public string Name {get; set;}
        public string Role {get; set;}
        public string Department {get; set;}
    }
}