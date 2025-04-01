using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Invoice
{
    [Key]
    public Guid InvoiceID { get; set; }

    [Required]
    public string InvoiceNumber { get; set; } = string.Empty; // e.g., INV-2025-0001

    [Required]
    [ForeignKey(nameof(Student))]
    public string StudentID { get; set; } = string.Empty;
    public virtual Student Student { get; set; } = null!;

    //Link back to the FinancialRecord if an invoice corresponds to one semester record
    [ForeignKey(nameof(FinancialRecord))]
    public Guid? FinancialRecordID { get; set; }
    public virtual FinancialRecord? FinancialRecord { get; set; }

    [Required]
    public DateTimeOffset CreatedDate { get; set; }

    [Required]
    public DateTimeOffset DueDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountAmount { get; set; } = 0m; // Optional discount

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public InvoiceStatus Status { get; set; }

    public string? Notes { get; set; }

    // Navigation property for line items
    public virtual ICollection<InvoiceLineItem> LineItems { get; set; } = new List<InvoiceLineItem>();
}