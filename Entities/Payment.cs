using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class Payment
{
    [Key] public Guid PaymentID { get; set; }

    [ForeignKey(nameof(FinancialRecord))] public Guid FinancialRecordID { get; set; }

    public FinancialRecord FinancialRecord { get; set; }

    public decimal Amount { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset PaymentDate { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public string ReferenceNumber { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    public string? Notes { get; set; }
}