namespace iSchool_Solution.Entities.DTO.Transcript;

public record TranscriptDownloadDetails(
    Guid TranscriptID,
    bool IsOfficial,
    DateTimeOffset GeneratedDate,
    string FileName,
    string FileUrl,
    string FileType,
    string FileSize,
    int ExpiryDays,
    bool IsPasswordProtected,
    bool RequiresAuthentication
);