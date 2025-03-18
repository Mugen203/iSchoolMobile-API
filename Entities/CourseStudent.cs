using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class CourseStudent
{
    // Foreign Keys
    [ForeignKey(nameof(Course))] public Guid CourseID { get; set; }

    public Course Course { get; set; }

    [ForeignKey(nameof(Student))] public string StudentID { get; set; }

    public Student Student { get; set; }

    public Guid RegistrationPeriodID { get; set; }

    [ForeignKey(nameof(RegistrationPeriodID))]
    public RegistrationPeriod RegistrationPeriod { get; set; }
}