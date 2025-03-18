using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class Department
{
    public Department()
    {
        Courses = new HashSet<Course>();
        Students = new HashSet<Student>();
    }

    [Key] public Guid DepartmentID { get; set; }

    public string DepartmentName { get; set; }
    public string? DepartmentDescription { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset BirthYear { get; set; }

    [ForeignKey(nameof(Faculty))] public Guid FacultyID { get; set; }
    public Faculty Faculty { get; set; }
    
    public int RequiredCredits { get; set; }

    // Navigation Properties
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}