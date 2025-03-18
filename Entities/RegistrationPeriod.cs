using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities;

public class RegistrationPeriod
{
    public RegistrationPeriod()
    {
        CourseEnrollments = new HashSet<CourseStudent>();
    }
    
    [Key] public Guid RegistrationPeriodID { get; set; }

    public string AcademicYear { get; set; }

    public string Semester { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public string Description { get; set; }

    public bool AllowCourseAdd { get; set; }

    public bool AllowCourseDrop { get; set; }

    public DateTime? LateRegistrationStart { get; set; }

    public DateTime? LateRegistrationEnd { get; set; }

    public decimal? LateRegistrationFee { get; set; }
    
    // Collection Property
    public virtual ICollection<CourseStudent> CourseEnrollments { get; set; }
}