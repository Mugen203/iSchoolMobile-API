using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class Course
{
    public Course()
    {
        Lecturers = new HashSet<Lecturer>();
        CourseStudents = new HashSet<CourseStudent>();
        LecturerCourses = new HashSet<LecturerCourse>();
        Grades = new HashSet<Grade>();
    }

    [Key] public Guid CourseID { get; set; }

    public string CourseCode { get; set; }

    public int CourseCredits { get; set; }

    public string CourseName { get; set; }

    public string CourseDescription { get; set; }

    [ForeignKey(nameof(Department))] public Guid DepartmentID { get; set; }

    // Navigation Properties
    public virtual Department Department { get; set; }

    // Collection Navigation Properties
    public virtual ICollection<CourseTimeSlot> CourseTimeSlots { get; set; }
    public virtual ICollection<Lecturer> Lecturers { get; set; }
    public virtual ICollection<Grade> Grades { get; set; }
    public virtual ICollection<LecturerCourse> LecturerCourses { get; set; }
    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}