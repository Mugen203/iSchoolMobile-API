using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Research;

public record CreateResearchProject
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; init; } = string.Empty;

    [Required(ErrorMessage = "Abstract is required")]
    public string Abstract { get; init; } = string.Empty;

    public string Keywords { get; init; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    public string Department { get; init; } = string.Empty;

    public List<string> ContributorIds { get; init; } = new();
}