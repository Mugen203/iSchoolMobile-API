using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class LecturerCourse
{
    [ForeignKey(nameof(Lecturer))]
    public string LecturerID { get; set; }
    public Lecturer Lecturer { get; set; }
    
    [ForeignKey(nameof(Course))]
    public Guid CourseID { get; set; }
    public Course Course { get; set; }
    
    public Semester Semester { get; set; }
    public string AcademicYear { get; set; }
}