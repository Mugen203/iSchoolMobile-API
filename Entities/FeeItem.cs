using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class FeeItem
{
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(FinancialRecord))] public Guid FinancialRecordID { get; set; }

    public FinancialRecord FinancialRecord { get; set; }

    public string Description { get; set; }

    public decimal Amount { get; set; }

    public FeeItemCategory FeeItemCategory { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; }
    
    public DateTimeOffset? DueDate { get; set; }

    public bool isRequired { get; set; }

    public string? Notes { get; set; }
}