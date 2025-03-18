using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Announcement
{
    [Key] public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
    
    /*[ForeignKey(nameof(CreatedBy))]
    public string CreatedById { get; set; }
    public ApiUser CreatedBy { get; set; }*/

    public DateTime PublishDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public AnnouncementCategory Category { get; set; }

    public bool IsFeatured { get; set; }

    public string AttachmentUrl { get; set; }
}