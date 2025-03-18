using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Student
{
    public Student()
    {
        CourseStudents = new HashSet<CourseStudent>();
        Transcripts = new HashSet<Transcript>();
        Grades = new HashSet<Grade>();
        FinancialRecords = new HashSet<FinancialRecord>();
    }

    [Key] [MaxLength(13)] public string StudentID { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";

    [EmailAddress] public string StudentEmail { get; set; }

    [Phone] public string StudentPhone { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset DateOfBirth { get; set; }

    public Gender Gender { get; set; }
    
    [MaxLength(50)] public string Address { get; set; }

    [MaxLength(20)] public string Degree { get; set; }

    [MaxLength(20)] public string DepartmentName { get; set; }
    
    [MaxLength] public string AcademicAdvisor { get; set; }
    
    public string StudentPhotoUrl { get; set; }

    [MaxLength(20)] public string EmergencyContactName { get; set; }

    [MaxLength(20)] public string EmergencyContactPhone { get; set; }

    [ForeignKey(nameof(Department))] public Guid DepartmentID { get; set; }

    // Navigation Properties
    public virtual Department Department { get; set; }

    // Collection Navigation Properties
    public virtual ICollection<FinancialRecord> FinancialRecords { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<Transcript> Transcripts { get; set; }
    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}