using System.Security.AccessControl;
using Domain.Common;

namespace Domain.Entities;

public class LibraryAccess : BaseEntity
{
    public Guid StudentId { get; set; }
    public string ResourceId { get; set; }
    public string ResourceTitle { get; set; }
    public ResourceType Type { get; set; }
    public DateTime AccessDate { get; set; }
    public DateTime? ReturnDate { get; set; }     // For physical books
    public bool IsOverdue { get; set; }
    
    // Navigation property
    public Student Student { get; set; }
}