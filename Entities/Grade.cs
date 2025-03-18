using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Grade
{
    [Key] public Guid GradeID { get; set; }

    [ForeignKey(nameof(SemesterRecord))] public Guid SemesterRecordID { get; set; }

    public SemesterRecord SemesterRecord { get; set; }

    public Guid CourseID { get; set; }

    [ForeignKey(nameof(Student))] public string StudentID { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset DateAwarded { get; set; }

    public GradeLetter GradeLetter { get; set; }

    public double GradePoints { get; set; }

    public bool isCompleted { get; set; }

    public Semester Semester { get; set; }

    public string? Remarks { get; set; } = string.Empty;

    // Navigation Properties
    public Student Student { get; set; }
    
    [ForeignKey(nameof(CourseID))]
    public Course Course { get; set; }
}