using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

public class Models
{
    public sealed class InitiatePaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "GHS"; // Default currency
        public string Description { get; set; } = string.Empty; // e.g., "Payment for Semester Fees"
        public Guid? FinancialRecordID { get; set; } // Optional: Link to specific record
        // Add other necessary info like callback URL if needed by gateway
    }

    public sealed class InitiatePaymentResponse
    {
        public string? PaymentGatewayUrl { get; set; } // For redirect-based gateways
        public string? ClientSecret { get; set; } // For JS-based gateways like Stripe Elements
        public string PaymentIntentID { get; set; } = string.Empty; // Your internal or gateway's intent ID
        public string GatewayName { get; set; } = string.Empty; // e.g., "Stripe", "Paystack"
    }
    
    public sealed class WebhookProcessingResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
    
    public sealed class PaymentStatusResponse
    {
        public Guid PaymentID { get; set; }
        public PaymentStatus Status { get; set; } // Internal status
        public string? GatewayStatus { get; set; } // Status from the gateway, if available
        public DateTimeOffset LastChecked { get; set; }
    }
}