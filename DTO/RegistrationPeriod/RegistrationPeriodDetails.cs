

namespace iSchool_Solution.Entities.DTO.RegistrationPeriod;

public record RegistrationPeriodDetails(
    int RegistrationPeriodID,
    string AcademicYear,
    string Semester,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    bool IsActive,
    string Description,
    bool AllowCourseAdd,
    bool AllowCourseDrop,
    DateTimeOffset? LateRegistrationStart,
    DateTimeOffset? LateRegistrationEnd,
    decimal? LateRegistrationFee
);