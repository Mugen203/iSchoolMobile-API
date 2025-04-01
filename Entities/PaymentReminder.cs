using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class PaymentReminder
{
    [Key]
    public Guid ReminderID { get; set; }

    [Required]
    [ForeignKey(nameof(Student))]
    public string StudentID { get; set; } = string.Empty;
    public virtual Student Student { get; set; } = null!;

    // Link to the specific record or fee item the reminder is for
    [ForeignKey(nameof(FinancialRecord))]
    public Guid? FinancialRecordID { get; set; }
    public virtual FinancialRecord? FinancialRecord { get; set; }

    [ForeignKey(nameof(FeeItem))]
    public int? FeeItemID { get; set; }
    public virtual FeeItem? FeeItem { get; set; }

    [Required]
    public DateTimeOffset DueDate { get; set; } // The original due date

    [Required]
    public DateTimeOffset ReminderDate { get; set; } // When the reminder should be sent

    [Required]
    public ReminderStatus Status { get; set; } = ReminderStatus.Pending;

    public ReminderType ReminderType { get; set; }

    public DateTimeOffset? SentDate { get; set; }

    public string? MessageContent { get; set; }
}