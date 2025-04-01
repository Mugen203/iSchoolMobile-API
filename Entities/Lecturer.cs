using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Lecturer
{
    public Lecturer()
    {
        LecturerCourses = new HashSet<LecturerCourse>();
        Evaluations = new HashSet<LecturerEvaluation>();
    }

    [Key] public string LecturerID { get; set; } = string.Empty; 

    public string LecturerFirstName { get; set; } = string.Empty; 
    public string LecturerLastName { get; set; } = string.Empty; 

    [EmailAddress] public string LecturerEmail { get; set; } = string.Empty; 

    public string Office { get; set; } = string.Empty; 
    public Gender Gender { get; set; }

    [ForeignKey(nameof(Department))] public Guid DepartmentID { get; set; }
    public virtual Department Department { get; set; }

    public string Credentials { get; set; } = string.Empty;

    // Collection Properties
    public virtual ICollection<LecturerCourse> LecturerCourses { get; set; }
    public virtual ICollection<LecturerEvaluation> Evaluations { get; set; }
}