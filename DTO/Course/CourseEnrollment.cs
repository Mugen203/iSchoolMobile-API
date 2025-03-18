using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Course;

public record CourseEnrollment(
    Guid CourseID,
    string CourseCode,
    string CourseName,
    int CourseCredits,
    EnrollmentStatus EnrollmentStatus,
    DateTimeOffset CourseEnrollmentDate,
    string Grade,
    bool CanDrop,
    List<ScheduleConflict> PotentialScheduleConflicts,
    string StudentID,
    string StudentName,
    int RegistrationPeriodID,
    string RegistrationPeriodName,
    DateTimeOffset CourseRegistrationDate
);