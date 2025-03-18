using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Course;

public record CourseRegistrationRequest
{
    [Required(ErrorMessage = "CourseID is required")]
    public Guid CourseID { get; init; }

    [Required(ErrorMessage = "RegistrationPeriodID is required")]
    public Guid RegistrationPeriodID { get; init; }
}