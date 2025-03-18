namespace iSchool_Solution.Entities.DTO.Research;

public record ResearchProjectDocumentDetails(
    int Id,
    int ResearchProjectID,
    string DocumentTitle,
    string FileType,
    string FilePath,
    long FileSize,
    DateTimeOffset UploadDate,
    string UploadedBy,
    string Description,
    int DownloadCount
);