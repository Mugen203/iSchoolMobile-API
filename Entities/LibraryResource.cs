using System.ComponentModel.DataAnnotations;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class LibraryResource
{
    public LibraryResource()
    {
        BorrowingRecords = new HashSet<ResourceBorrowing>();
    }

    [Key] public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string ISBN { get; set; }

    public string Category { get; set; }

    public string Publisher { get; set; }

    public int YearPublished { get; set; }

    public string Edition { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public ResourceType ResourceType { get; set; }

    public bool IsDigital { get; set; }

    public string DigitalAccessLink { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }

    // Navigation Properties
    public virtual ICollection<ResourceBorrowing> BorrowingRecords { get; set; }
}