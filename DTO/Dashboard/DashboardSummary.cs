using iSchool_Solution.Entities.DTO.Dashboard;

namespace iSchool_Solution.DTO.Dashboard;

public record DashboardSummary(
    string StudentID,
    string FullName,
    string DepartmentName,
    double CumulativeGPA,
    int CurrentEnrolledCourses,
    decimal OutstandingBalance,
    int UnreadNotifications,
    List<DeadlineSummary> UpcomingDeadlines,
    List<GradeSummary> RecentGrades
);