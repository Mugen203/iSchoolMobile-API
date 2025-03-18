using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.Notification;

public record NotificationSummary(
    int Id,
    string Title,
    string Message,
    NotificationType Type,
    DateTime CreatedDate,
    bool IsRead,
    Priority Priority,
    string RedirectUrl
);