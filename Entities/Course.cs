using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class Course
{
    public Course()
    {
        CourseStudents = new HashSet<CourseStudent>();
        LecturerCourses = new HashSet<LecturerCourse>();
        Grades = new HashSet<Grade>();
        CourseTimeSlots = new HashSet<CourseTimeSlot>();
    }

    [Key] public Guid CourseID { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public int CourseCredits { get; set; }

    public string CourseName { get; set; } = string.Empty;

    public string CourseDescription { get; set; } = string.Empty;

    [ForeignKey(nameof(Department))] public Guid DepartmentID { get; set; }

    // Navigation Properties
    public virtual Department Department { get; set; } = null!;

    // Collection Navigation Properties
    public virtual ICollection<CourseTimeSlot> CourseTimeSlots { get; set; }
    
    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<LecturerCourse> LecturerCourses { get; set; }
    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}