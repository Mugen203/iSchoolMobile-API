using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Enrollment : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public EnrollmentStatus Status { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime? DropDate { get; set; }
    public string EnrollmentNotes { get; set; }  // For registration issues/comments
    
    // Navigation properties
    public Student Student { get; set; }
    public Course Course { get; set; }
    public Grade Grade { get; set; }  // One-to-one relationship with Grade
}