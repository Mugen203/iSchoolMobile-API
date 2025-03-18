using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class ResearchProject
{
    public ResearchProject()
    {
        Contributors = new HashSet<ResearchContributor>();
        Documents = new HashSet<ResearchDocument>();
    }

    [Key] public int Id { get; set; }

    public string Title { get; set; }

    [ForeignKey(nameof(MainAuthor))] public string MainAuthorID { get; set; }

    public ApiUser MainAuthor { get; set; }

    public string Abstract { get; set; }

    public string Keywords { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset DateSubmitted { get; set; }

    public ResearchStatus Status { get; set; }

    public string Department { get; set; }

    // Navigation Properties
    public virtual ICollection<ResearchContributor> Contributors { get; set; }
    public virtual ICollection<ResearchDocument> Documents { get; set; }
}