using Domain.Enums;

namespace Domain.Entities;

public class Announcement
{
    public string Title { get; set; }
    public string Content { get; set; }
    public AnnouncementType Type { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public bool IsUrgent { get; set; }
    
    // public string TargetPrograms { get; set; }  // Comma-separated program codes
    // public string TargetSemesters { get; set; } // Comma-separated semester numbers
    
    public string AttachmentUrl { get; set; }
}