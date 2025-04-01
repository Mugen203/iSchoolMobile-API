using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class PaymentGatewayTransaction
{
    [Key]
    public Guid GatewayTransactionID { get; set; }

    [Required]
    [ForeignKey(nameof(Payment))]
    public Guid PaymentID { get; set; } // Link to internal Payment record
    public virtual Payment Payment { get; set; } = null!;

    [Required]
    public string GatewayName { get; set; } = string.Empty; // e.g., "Stripe", "PayPal", "Paystack"

    [Required]
    public string GatewayTransactionReference { get; set; } = string.Empty; // ID from the payment gateway

    [Required]
    public string Status { get; set; } = string.Empty; // Status from the gateway (e.g., "succeeded", "pending", "failed")

    public string? FailureCode { get; set; } // e.g., card_declined

    public string? FailureMessage { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountProcessed { get; set; }

    public string Currency { get; set; } = string.Empty; // e.g., "GHS"

    public DateTimeOffset TransactionTimestamp { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? RawResponseData { get; set; } // Store the full response from gateway for auditing/debugging
}