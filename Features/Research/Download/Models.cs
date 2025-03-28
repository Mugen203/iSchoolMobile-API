namespace iSchool_Solution.Features.Research.Download;

public class Models
{
    public class DownloadResearchDocumentRequest
    {
        public int DocumentID { get; set; }
    }
    
    public class DownloadResearchDocumentResponse
    {
        public int DocumentID { get; set; }
        public string DocumentTitle { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public int DownloadCount { get; set; }
    }
}