namespace iSchool_Solution.Features.Transcript.Download;

public class Models
{
    public class DownloadTranscriptResponse
    {
        public Guid TranscriptID { get; set; }
        public bool IsOfficial { get; set; }
        public DateTimeOffset GeneratedDate { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public int ExpiryDays { get; set; }
        public bool IsPasswordProtected { get; set; }
        public bool RequiresAuthentication { get; set; }
    }
}