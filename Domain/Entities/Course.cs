using Domain.Enums;

namespace Domain.Entities;

public class Course
{
    public string CourseCode { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreditHours { get; set; }
    public int MaxStudents { get; set; }
    public CourseStatus Status { get; set; }
    public string Semester { get; set; }
    public int AcademicYear { get; set; }
    
    // Lecturer Info
    public string LecturerName { get; set; }
    public string LecturerId { get; set; }
    
    public string Prerequisites { get; set; }  // Comma-separated course codes
    public string Department { get; set; }
    public decimal Fee { get; set; }          // Course fee for payment calculations
    
    // Navigation Props
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Grade> Grades { get; set; }
    public ICollection<LecturerEvaluation> Evaluations { get; set; }

    public Course()
    {
        Enrollments = new List<Enrollment>();
        Grades = new List<Grade>();
        Evaluations = new List<LecturerEvaluation>();
    }
}