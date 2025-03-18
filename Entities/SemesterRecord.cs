using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class SemesterRecord
{
    public SemesterRecord()
    {
        Grades = new HashSet<Grade>();
    }

    [Key]
    public Guid SemesterRecordID { get; set; }

    [ForeignKey(nameof(Transcript))]
    public Guid TranscriptID { get; set; }
    public Transcript Transcript { get; set; }
    
    [ForeignKey(nameof(Student))]
    public string StudentID { get; set; }
    
    public Student Student { get; set; }
    
    public string AcademicYear { get; set; } 

    public Semester Semester { get; set; }

    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public double SemesterGPA { get; set; }

    public int CreditsAttempted { get; set; }

    public int CreditsEarned { get; set; }

    // Navigation Properties
    public virtual ICollection<Grade> Grades { get; set; }
    
    public void CalculateSemesterGPA()
    {
        double totalGradePoints = 0;
        var totalCreditsAttempted = 0;
        var totalCreditsEarned = 0;

        foreach (var grade in Grades)
        {
            if (grade.GradeLetter.IsIncludedInGPA()) // Only include GPA grades
            {
                totalGradePoints += grade.GradeLetter.GetGradePoints() * grade.Course.CourseCredits;
                totalCreditsAttempted += grade.Course.CourseCredits;
                if (grade.GradeLetter != GradeLetter.F) // Earned credits if not Fail
                {
                    totalCreditsEarned += grade.Course.CourseCredits;
                }
            }
            else switch (grade.GradeLetter)
            {
                // Pass counts as earned credits
                case GradeLetter.P:
                    totalCreditsEarned += grade.Course.CourseCredits;
                    totalCreditsAttempted += grade.Course.CourseCredits; 
                    break;
                case GradeLetter.NP:
                // Count NP and NA as attempted credits (even if not GPA impacting)
                case GradeLetter.NA:
                    totalCreditsAttempted += grade.Course.CourseCredits;
                    break;
            }
        }

        CreditsAttempted = totalCreditsAttempted;
        CreditsEarned = totalCreditsEarned;

        if (totalCreditsAttempted > 0)
        {
            SemesterGPA = totalGradePoints / totalCreditsAttempted;
        }
        else
        {
            SemesterGPA = 0; // Or perhaps null, or a specific value indicating no GPA
        }
    }
}