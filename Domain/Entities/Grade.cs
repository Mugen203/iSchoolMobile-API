namespace Domain.Entities;

public class Grade
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Guid EnrollmentId { get; set; }
    
    // Grade components
    public decimal Midterm { get; set; }
    public decimal Final { get; set; }
    public decimal Assignments { get; set; }
    public decimal Attendance { get; set; }
    public decimal TotalScore { get; set; }
    public string LetterGrade { get; set; }  // e.g., "A", "B+"
    public decimal GradePoint { get; set; }  // e.g., 4.0, 3.5
    
    // Navigation properties
    public Student Student { get; set; }
    public Course Course { get; set; }
    public Enrollment Enrollment { get; set; }
}