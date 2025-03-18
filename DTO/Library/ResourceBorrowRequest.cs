using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Library;

public record ResourceBorrowRequest
{
    [Required(ErrorMessage = "LibraryResourceID is required")]
    public int LibraryResourceID { get; init; }

    public DateTime RequestedBorrowDate { get; init; } // Consider validation for date range if needed
}