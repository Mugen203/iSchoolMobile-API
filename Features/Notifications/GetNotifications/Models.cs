using static iSchool_Solution.Features.Notifications.Common.Models;

namespace iSchool_Solution.Features.Notifications.GetNotifications;

public class Models
{
    public class StudentNotificationsResponse
    {
        public List<NotificationSummary> Notifications { get; set; } = new();
    }
}