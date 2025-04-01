using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class InvoiceLineItem
{
    [Key]
    public int InvoiceLineItemID { get; set; }

    [Required]
    [ForeignKey(nameof(Invoice))]
    public Guid InvoiceID { get; set; }
    public virtual Invoice Invoice { get; set; } = null!;

    //Link directly to the FeeItem 
    [ForeignKey(nameof(FeeItem))]
    public int? FeeItemID { get; set; }
    public virtual FeeItem? FeeItem { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty; // e.g., "Tuition Fee - Sept 2024", "Library Fine"

    [Required]
    public int Quantity { get; set; } = 1;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; } // Amount for one unit

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal LineTotal { get; set; } // Quantity * UnitPrice
}