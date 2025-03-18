using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class CourseTimeSlot
{
    [Key]
    public Guid CourseTimeSlotID { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    [MaxLength(50)]
    public ClassLocation Location { get; set; }

    [ForeignKey(nameof(Course))]
    public Guid CourseID { get; set; }

    // Navigation Property
    public virtual Course Course { get; set; } // Course this time slot belongs to
    
    [ForeignKey(nameof(Lecturer))]
    public string LecturerID { get; set; }
    public virtual Lecturer Lecturer { get; set; }
}