using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Research.Get;

public class Models
{
    public class GetResearchProjectRequest
    {
        public int ProjectID { get; set; }
    }
    
    public class GetResearchProjectResponse
    {
        public ResearchProjectDetails Project { get; set; }
    }
    
    public class ResearchProjectDetails
    {
        public int ProjectID {get; set;}
        public string Title { get; set; } = string.Empty;
        public string Abstract {get; set;} = string.Empty;
        public string Keywords {get; set;} = string.Empty;
        public DateTimeOffset DateSubmitted {get; set;}
        public ResearchStatus Status {get; set;}
        public string Department {get; set;} = string.Empty;
        public string MainAuthor {get; set;} = string.Empty;
        public List<ResearchProjectContributorDetails> Contributors { get; set; } = [];
        public List<ResearchProjectDocumentDetails> Documents { get; set; } = [];
    }
    
    public class ResearchProjectContributorDetails
    {
        public int ProjectID {get; set;}
        public string ResearchContributorID { get; set; } = string.Empty;
        public string ContributorName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ContributionDetails { get; set; } = string.Empty;
    }

    public class ResearchProjectDocumentDetails
    {
        public int DocumentID {get; set;}
        public int ResearchProjectID {get; set;}
        public string DocumentTitle {get; set;} = string.Empty;
        public string FileType {get; set;} = string.Empty;
        public string FilePath {get; set;} = string.Empty;
        public long FileSize {get; set;}
        public DateTimeOffset UploadDate {get; set;}
        public string UploadedBy {get; set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DownloadCount {get; set;}
    }
}