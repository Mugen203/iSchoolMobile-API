using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Notification;

public record MarkNotificationReadRequest
{
    [Required(ErrorMessage = "NotificationId is required")]
    public int NotificationId { get; init; }
}