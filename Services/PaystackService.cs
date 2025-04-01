using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using iSchool_Solution.Entities; // For PaymentGatewayTransaction
using iSchool_Solution.Enums;
using iSchool_Solution.Repository; // For PaymentStatus
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;
using static iSchool_Solution.Features.Finance.Models; // For Request/Response models

namespace iSchool_Solution.Services;

public class PaystackService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly FinanceService _financeService; // To update records after payment
    private readonly FinanceRepository _financeRepository; // To save gateway transaction details
    private readonly ILogger<PaystackService> _logger;
    private readonly string _paystackSecretKey;
    private readonly string _paystackBaseUrl = "https://api.paystack.co";

    public PaystackService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration,
        FinanceService financeService,
        FinanceRepository financeRepository,
        ILogger<PaystackService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _financeService = financeService;
        _financeRepository = financeRepository;
        _logger = logger;
        _paystackSecretKey = _configuration["Paystack:SecretKey"] ??
                             throw new InvalidOperationException("Paystack Secret Key not configured");
    }

    /// <summary>
    /// Initiates a payment transaction with Paystack.
    /// </summary>
    public async Task<InitiatePaymentResponse> CreatePaymentIntentAsync(InitiatePaymentRequest request,
        string studentId, string studentEmail)
    {
        var client = _httpClientFactory.CreateClient("PaystackClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _paystackSecretKey);

        // Generate a unique internal reference for this payment attempt
        var internalPaymentReference = $"ISCHOOL-{Guid.NewGuid().ToString().Substring(0, 8)}";

        var payload = new
        {
            email = studentEmail,
            amount = request.Amount * 100, // Amount in Pesewas
            currency = request.Currency,
            reference = internalPaymentReference,
            // callback_url = "YOUR_APP_CALLBACK_URL", // URL Paystack redirects to after payment
            metadata = new
            {
                student_id = studentId,
                description = request.Description,
                financial_record_id = request.FinancialRecordID?.ToString() ?? ""
            },
            channels = new[] { "mobile_money", "card" } // Specify allowed channels
        };

        var jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        _logger.LogInformation(
            "Initializing Paystack transaction for Student: {StudentID}, Amount: {Amount}, Reference: {Reference}",
            studentId, request.Amount, internalPaymentReference);

        var response = await client.PostAsync($"{_paystackBaseUrl}/transaction/initialize", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _logger.LogError("Paystack initialization failed: {StatusCode} - {ErrorContent}", response.StatusCode,
                errorContent);
            throw new ApplicationException($"Paystack payment initialization failed. {errorContent}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        using var jsonDoc = JsonDocument.Parse(responseBody);

        if (!jsonDoc.RootElement.TryGetProperty("status", out var statusElement) || !statusElement.GetBoolean())
        {
            _logger.LogError("Paystack initialization returned status false: {ResponseBody}", responseBody);
            throw new ApplicationException("Paystack returned an error during initialization.");
        }

        var dataElement = jsonDoc.RootElement.GetProperty("data");
        var authorizationUrl = dataElement.GetProperty("authorization_url").GetString();
        var accessCode = dataElement.GetProperty("access_code").GetString(); // Needed for some flows
        var gatewayReference = dataElement.GetProperty("reference").GetString(); // Paystack's reference

        _logger.LogInformation(
            "Paystack transaction initialized successfully. Gateway Ref: {GatewayRef}, Internal Ref: {InternalRef}",
            gatewayReference, internalPaymentReference);

        // *** Create Pending Payment Record in your DB ***
        // Use internalPaymentReference to potentially link later in webhook
        await _financeService.CreatePendingPaymentAsync(
            studentId,
            request.Amount,
            request.Currency,
            PaymentMethod.Paystack, 
            internalPaymentReference, // Your reference
            gatewayReference ?? internalPaymentReference, // Gateway's reference
            request.FinancialRecordID
        );

        return new InitiatePaymentResponse
        {
            PaymentGatewayUrl = authorizationUrl, // URL for user to visit
            ClientSecret = null, // Not typically used for redirect flow
            PaymentIntentID = internalPaymentReference, // Return your internal reference
            GatewayName = "Paystack"
        };
    }

    /// <summary>
    /// Validates the signature received from Paystack webhook.
    /// </summary>
    public Task<bool> ValidateWebhookSignatureAsync(string gatewayName, string payload, string signature)
    {
        if (!gatewayName.Equals("Paystack", StringComparison.OrdinalIgnoreCase))
            return Task.FromResult(false); // Not a Paystack webhook

        // Paystack uses HMAC-SHA512
        using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_paystackSecretKey));
        var computedHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
        var computedHashString = BitConverter.ToString(computedHashBytes).Replace("-", "").ToLowerInvariant();

        var isValid = computedHashString.Equals(signature, StringComparison.OrdinalIgnoreCase);

        if (!isValid)
            _logger.LogWarning(
                "Paystack webhook signature mismatch. Computed: {ComputedHash}, Received: {ReceivedSignature}",
                computedHashString, signature);

        return Task.FromResult(isValid);
    }

    /// <summary>
    /// Processes the validated webhook event payload from Paystack.
    /// </summary>
    public async Task<WebhookProcessingResult> ProcessWebhookEventAsync(string gatewayName, string payload)
    {
        if (!gatewayName.Equals("Paystack", StringComparison.OrdinalIgnoreCase))
            return new WebhookProcessingResult { Success = false, Message = "Invalid gateway name." };

        try
        {
            using var jsonDoc = JsonDocument.Parse(payload);
            var eventType = jsonDoc.RootElement.GetProperty("event").GetString();
            var data = jsonDoc.RootElement.GetProperty("data");

            _logger.LogInformation("Processing Paystack event: {EventType}", eventType);

            switch (eventType)
            {
                case "charge.success":
                    var internalReference = data.GetProperty("reference").GetString();
                    var gatewayReference = data.GetProperty("id").GetInt64().ToString(); // Paystack charge ID
                    var amountKobo = data.GetProperty("amount").GetInt64();
                    var currency = data.GetProperty("currency").GetString();
                    var status = data.GetProperty("status").GetString(); // Should be 'success'
                    var paidAt = data.GetProperty("paid_at").GetDateTimeOffset();
                    var gatewayResponseMsg = data.GetProperty("gateway_response").GetString();

                    if (status != "success")
                    {
                        _logger.LogWarning("Received charge.success event but status is '{Status}'. Ref: {Reference}",
                            status, internalReference);
                        // Potentially update payment to failed or investigate
                        return new WebhookProcessingResult
                        {
                            Success = true, Message = "Charge status not 'success'."
                        }; // Acknowledge webhook, but don't complete payment
                    }

                    // Find internal payment by internalReference
                    var payment =
                        await _financeRepository
                            .GetPaymentByReferenceAsync(internalReference); // Needs implementation in repo
                    if (payment == null)
                    {
                        _logger.LogError(
                            "Cannot find internal payment record for successful Paystack charge. Reference: {Reference}",
                            internalReference);
                        return new WebhookProcessingResult
                            { Success = false, Message = "Internal payment record not found." }; // Error state
                    }

                    // Verify amount (convert Paystack kobo/pesewas back)
                    var amountDecimal = (decimal)amountKobo / 100;
                    if (payment.Amount != amountDecimal || payment.PaymentStatus == PaymentStatus.Completed)
                    {
                        _logger.LogWarning(
                            "Paystack amount mismatch or payment already completed for Reference: {Reference}. Expected {ExpectedAmount}, Got {ActualAmount}, Current Status {Status}",
                            internalReference, payment.Amount, amountDecimal, payment.PaymentStatus);
                        // Decide how to handle - maybe log and investigate, maybe ignore?
                        return new WebhookProcessingResult
                        {
                            Success = true, Message = "Amount mismatch or already completed."
                        }; // Acknowledge webhook
                    }

                    // *** Update Payment and Financial Records ***
                    await _financeService.MarkPaymentAsCompletedAsync(
                        payment.PaymentID,
                        paidAt,
                        gatewayReference, // Store Paystack's ID
                        gatewayResponseMsg ?? "Completed via Paystack"
                    );

                    // Record gateway transaction details
                    var gatewayTx = new PaymentGatewayTransaction
                    {
                        GatewayTransactionID = Guid.NewGuid(),
                        PaymentID = payment.PaymentID,
                        GatewayName = "Paystack",
                        GatewayTransactionReference = gatewayReference,
                        Status = status,
                        AmountProcessed = amountDecimal,
                        Currency = currency ?? "GHS",
                        TransactionTimestamp = paidAt,
                        RawResponseData = payload // Store the event data
                    };
                    await _financeRepository.SavePaymentGatewayTransactionAsync(gatewayTx);
                    await _context.SaveChangesAsync(); // Save gateway tx


                    _logger.LogInformation("Successfully processed Paystack charge.success for Reference: {Reference}",
                        internalReference);
                    return new WebhookProcessingResult { Success = true, Message = "Payment successful." };

                case "transfer.success":
                case "transfer.failed":
                case "transfer.reversed":
                    _logger.LogInformation(
                        "Received Paystack transfer event: {EventType}. Ref: {Reference}. (Disbursement scenario - currently ignored in payment flow)",
                        eventType, data.TryGetProperty("reference", out var trRef) ? trRef.GetString() : "N/A");
                    // Handle disbursement updates if needed based on your loan app example logic
                    return new WebhookProcessingResult
                        { Success = true, Message = "Transfer event received." }; // Acknowledge

                // Add cases for other events like charge.failed if needed
                default:
                    _logger.LogInformation("Unhandled Paystack event type: {EventType}", eventType);
                    return new WebhookProcessingResult
                        { Success = true, Message = "Event type not handled." }; // Acknowledge
            }
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, "Failed to parse Paystack webhook JSON payload.");
            return new WebhookProcessingResult { Success = false, Message = "Invalid JSON payload." };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing Paystack webhook.");
            return new WebhookProcessingResult { Success = false, Message = "Internal server error." };
        }
    }
}

// Helper record for WebhookProcessingResult if not defined elsewhere
public record WebhookProcessingResult(bool Success, string? Message = null);