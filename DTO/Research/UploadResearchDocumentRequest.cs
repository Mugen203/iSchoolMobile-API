using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Research;

public record UploadResearchDocumentRequest(
    [Required] int ResearchProjectID,
    [Required] string DocumentTitle,
    [Required] string FileType,
    [Required] string FilePath,
    [Required] long FileSize,
    [Required] DateTimeOffset UploadDate,
    [Required] string UploadedBy,
    string Description
);
