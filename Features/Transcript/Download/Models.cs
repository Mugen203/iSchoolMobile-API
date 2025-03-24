using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Transcript.Download;

public class Models
{
    public class DownloadTranscriptRequest
    {
        public string StudentID { get; set; } = string.Empty;
        public bool IsOfficial { get; set; } = false;
        public TranscriptFormat Format { get; set; }
        public Guid? SemesterID { get; set; } // If provided, downloads transcript for just one semester
        public string? Purpose { get; set; } // Why the transcript is being requested (for audit logs)
    }
    
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