using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class FinancialRecord
{
    public FinancialRecord()
    {
        FeeItems = new HashSet<FeeItem>();
        Payments = new HashSet<Payment>();
    }

    [Key] public Guid FinancialRecordID { get; set; }

    [ForeignKey(nameof(Student))] public string StudentID { get; set; }

    public Student Student { get; set; }

    public Semester Semester { get; set; }
    
    public string AcademicYear { get; set; }

    public decimal TotalFees { get; set; }

    public decimal AmountPaid { get; set; }

    public decimal OutstandingBalance { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    // Navigation Properties
    public virtual ICollection<FeeItem> FeeItems { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}