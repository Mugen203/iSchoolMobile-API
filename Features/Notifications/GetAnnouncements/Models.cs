using static iSchool_Solution.Features.Notifications.Common.Models;

namespace iSchool_Solution.Features.Notifications.GetAnnouncements;

public class Models
{
    public class StudentAnnouncementsResponse
    {
        public List<NotificationSummary> Announcements { get; set; } = new();
    }
}