using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities;

public class Faculty
{
    public Faculty()
    {
        Departments = new HashSet<Department>();
    }

    [Key] public Guid FacultyID { get; set; }

    public string FacultyName { get; set; }
    public string? FacultyDescription { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset BirthYear { get; set; }

    // Navigation Properties
    public ICollection<Department> Departments { get; set; }
}