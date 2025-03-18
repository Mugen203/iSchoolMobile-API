using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class ResearchContributor
{
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(ResearchProject))] public int ResearchProjectID { get; set; }

    public ResearchProject Project { get; set; }

    [ForeignKey(nameof(ResearchContributor))]
    public string ResearchContributorID { get; set; }

    public ApiUser Contributor { get; set; }

    public string Role { get; set; }

    public string ContributionDetails { get; set; }
}