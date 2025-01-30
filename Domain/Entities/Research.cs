using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Research : BaseEntity
{
    public Guid StudentId { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public string DocumentUrl { get; set; }
    public ResearchStatus Status { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string SupervisorName { get; set; }
    public string SupervisorId { get; set; }
    public string Keywords { get; set; }
    public bool IsPublic { get; set; }  // Whether other students can view it
    
    // Navigation property
    public Student Student { get; set; }   
}