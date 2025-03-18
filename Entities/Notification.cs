using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Notification
{
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(ApiUser))] public string StudentID { get; set; }

    public ApiUser Student { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public NotificationType NotificationType { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRead { get; set; }

    public string RedirectUrl { get; set; } // Where to navigate when clicked

    public Priority Priority { get; set; }
}