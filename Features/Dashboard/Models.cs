using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Dashboard;

public class Models
{
    public sealed class DashboardSummaryResponse
    {
        public HeaderInfo Header { get; set; } = new HeaderInfo();
        public NextClassInfo? NextClass { get; set; } // Nullable if no next class
        public KeyMetricsInfo KeyMetrics { get; set; } = new KeyMetricsInfo();
        public List<AnnouncementCardInfo> Announcements { get; set; } = new List<AnnouncementCardInfo>();
    }

    public class HeaderInfo
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public int UnreadNotificationCount { get; set; }
    }

    public class NextClassInfo
    {
        public string CourseName { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public ClassLocation Location { get; set; }
        public string? LecturerName { get; set; }
    }

    public class GPAMetric
    {
        public double CurrentGPA { get; set; }
        public double? LastSemesterGPA { get; set; }
    }
    
    public class BalanceMetric
    {
        public decimal OutstandingBalance { get; set; }
        public DateTimeOffset? NextDueDate { get; set; }
    }
    
    public class KeyMetricsInfo
    {
        public GPAMetric GPAMetrics { get; set; } = new GPAMetric();
        public BalanceMetric BalanceMetrics { get; set; } = new BalanceMetric();
    }
    
    public class AnnouncementCardInfo
    {
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; } 
    }
}