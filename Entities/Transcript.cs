using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Transcript
{
    public Transcript()
    {
        SemesterRecords = new HashSet<SemesterRecord>();
    }

    [Key] public Guid TranscriptID { get; set; }

    [ForeignKey(nameof(Student))] [MaxLength(13)] public string StudentID { get; set; }

    public Student Student { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset GeneratedDate { get; set; }

    public double CummulativeGPA { get; set; }

    public int CreditsAttempted { get; set; }

    public int CreditsEarned { get; set; }

    public bool isOfficial { get; set; }

    public AcademicStanding AcademicStanding { get; set; }

    // Navigation Properties
    public virtual ICollection<SemesterRecord> SemesterRecords { get; set; }
    
    public void CalculateCummulativeGPA()
    {
        double totalCummulativeGradePoints = 0;
        var totalCummulativeCreditsAttempted = 0;
        var totalCummulativeCreditsEarned = 0;

        foreach (var semesterRecord in SemesterRecords)
        {
            foreach (var grade in semesterRecord.Grades)
            {
                 if (grade.GradeLetter.IsIncludedInGPA())
                 {
                     totalCummulativeGradePoints += grade.GradeLetter.GetGradePoints() * grade.Course.CourseCredits;
                     totalCummulativeCreditsAttempted += grade.Course.CourseCredits;
                      if (grade.GradeLetter != GradeLetter.F) // Earned credits if not Fail
                     {
                         totalCummulativeCreditsEarned += grade.Course.CourseCredits;
                     }
                 }
                 else switch (grade.GradeLetter)
                 {
                     // Pass counts as earned credits
                     case GradeLetter.P:
                         totalCummulativeCreditsEarned += grade.Course.CourseCredits;
                         totalCummulativeCreditsAttempted += grade.Course.CourseCredits;
                         break;
                     case GradeLetter.NP:
                     // Count NP and NA as attempted credits (even if not GPA impacting)
                     case GradeLetter.NA:
                         totalCummulativeCreditsAttempted += grade.Course.CourseCredits;
                         break;
                 }
            }
        }

        CreditsAttempted = totalCummulativeCreditsAttempted;
        CreditsEarned = totalCummulativeCreditsEarned;

        if (totalCummulativeCreditsAttempted > 0)
        {
            CummulativeGPA = totalCummulativeGradePoints / totalCummulativeCreditsAttempted;
        }
        else
        {
            CummulativeGPA = 0;
        }
    }
}