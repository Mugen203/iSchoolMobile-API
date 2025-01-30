using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Payment : BaseEntity
{
    public Guid StudentId { get; set; }
    public string ReferenceNumber { get; set; }
    public decimal Amount { get; set; }
    public PaymentType Type { get; set; }
    public PaymentStatus Status { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public string TransactionId { get; set; }  // From payment gateway
    public PaymentMethod PaymentMethod { get; set; }  // e.g., "Credit Card", "Bank Transfer"
    
    // Navigation property
    public Student Student { get; set; }
}