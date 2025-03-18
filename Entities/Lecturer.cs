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
    
    [Key] public string LecturerID { get; set; }

    public string LecturerFirstName { get; set; }
    public string LecturerLastName { get; set; }

    [EmailAddress] public string LecturerEmail { get; set; }

    public string Office { get; set; }
    public Gender Gender { get; set; }

    [ForeignKey(nameof(Department))] public Guid DepartmentID { get; set; }

    public string Credentials { get; set; }
    
    
    // Collection Properties
    public virtual ICollection<LecturerCourse> LecturerCourses { get; set; }
    public virtual ICollection<LecturerEvaluation> Evaluations { get; set; }
}