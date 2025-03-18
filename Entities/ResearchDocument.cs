using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class ResearchDocument
{
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(ResearchContributor))]
    public int ResearchProjectID { get; set; }

    public ResearchProject Project { get; set; }

    public string DocumentTitle { get; set; }

    public string FileType { get; set; }

    public string FilePath { get; set; }

    public long FileSize { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset UploadDate { get; set; }

    public string UploadedBy { get; set; }

    public string Description { get; set; }

    public int DownloadCount { get; set; }
}