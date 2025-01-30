using Domain.Common;

namespace Domain.Entities;

public class Student : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public string TwoFactorSecret { get; set; }
    
    // Academic Information
    public string StudentId { get; set; }
    public string Program { get; set; }
    public int CurrentSemester { get; set; }
    public decimal Cgpa { get; set; }
    
    // Navigation Props
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Research> ResearchProjects { get; set; }
    public ICollection<LibraryAccess> LibraryAccesses { get; set; }

    public Student()
    {
        Enrollments = new List<Enrollment>();
        Grades = new List<Grade>();
        Payments = new List<Payment>();
        ResearchProjects = new List<Research>();
        LibraryAccesses = new List<LibraryAccess>();
    }
}