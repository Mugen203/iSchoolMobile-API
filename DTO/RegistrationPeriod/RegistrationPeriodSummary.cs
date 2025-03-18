namespace iSchool_Solution.Entities.DTO.RegistrationPeriod;

public record RegistrationPeriodSummary( // Created for list views, replaces RegistrationPeriodListDTO
    int RegistrationPeriodID,
    string AcademicYear,
    string Semester,
    bool IsActive
);