namespace iSchool_Solution.Features.Research.Upload;

public class Models
{
    public class UploadResearchDocumentRequest
    {
        public int ProjectId { get; set; }
        
        public string DocumentTitle { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public IFormFile File { get; set; } = null!;
    }
    
    public class UploadResearchDocumentResponse
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string FileType { get; set; } = string.Empty;
        public DateTimeOffset UploadDate { get; set; }
        public string UploadedBy { get; set; } = string.Empty;
    }
}