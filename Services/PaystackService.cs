using PayStack.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Repository;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Services
{
    public class PaystackService
    {
        private readonly IConfiguration _configuration;
        private readonly FinanceService _financeService;
        private readonly FinanceRepository _financeRepository;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PaystackService> _logger;
        private readonly string _paystackSecretKey;
        private readonly PayStackApi _paystackApi;

        public PaystackService(
            IConfiguration configuration,
            FinanceService financeService,
            FinanceRepository financeRepository,
            ApplicationDbContext context,
            ILogger<PaystackService> logger)
        {
            _configuration = configuration;
            _financeService = financeService;
            _financeRepository = financeRepository;
            _context = context; // Assign DbContext
            _logger = logger;
            _paystackSecretKey = _configuration["Paystack:SecretKey"] ??
                                 throw new InvalidOperationException("Paystack Secret Key not configured");
            
            _paystackApi = new PayStackApi(_paystackSecretKey);
            _logger.LogInformation("PaystackService initialized with PayStack.Net client.");
        }

        /// <summary>
        /// Initiates a payment transaction with Paystack using the PayStack.Net library.
        /// </summary>
        public async Task<InitiatePaymentResponse> CreatePaymentIntentAsync(InitiatePaymentRequest request,
            string studentId, string studentEmail)
        {
            // Generate a unique internal reference (same as before)
            var internalPaymentReference = $"ISCHOOL-{Guid.NewGuid().ToString().Substring(0, 8)}";

            // 1. Create the request object using library's model
            var paystackRequest = new TransactionInitializeRequest
            {
                Email = studentEmail,
                AmountInKobo = (int)(request.Amount * 100), // Ensure amount is in Kobo/Pesewas
                Currency = request.Currency,
                Reference = internalPaymentReference,
                // CallbackUrl = _configuration["Paystack:CallbackUrl"], // Get callback URL from config if needed
                Channels = new List<string> { "mobile_money", "card" }.ToArray() // Example channels
            };

            // 2. Add Metadata using library's mechanism
            paystackRequest.MetadataObject = new Dictionary<string, object>
            {
                { "student_id", studentId },
                { "description", request.Description },
                { "financial_record_id", request.FinancialRecordID?.ToString() ?? "" },
                // Add any other custom fields/metadata as needed
                // { "custom_fields", new List<CustomField> { CustomField.From("Display Name", "variable_name", "Value") } }
            };

            _logger.LogInformation(
                "Initializing Paystack transaction via library for Student: {StudentID}, Amount: {Amount}, Reference: {Reference}",
                studentId, request.Amount, internalPaymentReference);

            try
            {
                // 3. Call the library's Initialize method
                // The library's Initialize method seems synchronous based on the README.
                // We wrap it in Task.Run to avoid blocking the async thread if it's truly sync.
                // If the library offers an async version (e.g., InitializeAsync), prefer that.
                TransactionInitializeResponse response =
                    await Task.Run(() => _paystackApi.Transactions.Initialize(paystackRequest));
                // If truly sync: TransactionInitializeResponse response = _paystackApi.Transactions.Initialize(paystackRequest);


                // 4. Check library response status
                if (!response.Status || response.Data == null) // Check Data nullity as well
                {
                    _logger.LogError("Paystack initialization failed via library: {Message}",
                        response.Message ?? "Unknown error (response status false or data null)");
                    throw new ApplicationException(
                        $"Paystack payment initialization failed. {response.Message ?? "Unknown error"}");
                }

                _logger.LogInformation(
                    "Paystack transaction initialized successfully via library. Gateway Ref: {GatewayRef}, Internal Ref: {InternalRef}",
                    response.Data.Reference, // Paystack's reference might be in Data.Reference
                    internalPaymentReference); // Your reference

                // *** Create Pending Payment Record in your DB (Same logic as before) ***
                await _financeService.CreatePendingPaymentAsync(
                    studentId,
                    request.Amount,
                    request.Currency,
                    PaymentMethod.Paystack,
                    internalPaymentReference, // Your reference
                    response.Data.Reference, // Gateway's reference
                    request.FinancialRecordID
                );

                // 5. Return your API response using data from library response
                return new InitiatePaymentResponse
                {
                    PaymentGatewayUrl = response.Data.AuthorizationUrl, // Typed property access
                    ClientSecret = null, // Not typically used for redirect flow
                    PaymentIntentID = internalPaymentReference, // Return your internal reference
                    GatewayName = "Paystack"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error during Paystack transaction initialization via library for Reference: {Reference}",
                    internalPaymentReference);
                // Rethrow or handle appropriately
                throw new ApplicationException("Failed to initialize Paystack transaction.", ex);
            }
        }

        /// <summary>
        /// Validates the signature received from Paystack webhook.
        /// Keep existing manual implementation unless library provides a helper.
        /// </summary>
        public Task<bool> ValidateWebhookSignatureAsync(string gatewayName, string payload, string signature)
        {
            if (!gatewayName.Equals("Paystack", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(false);

            // ASSUMPTION: The paystack-dotnet library DOES NOT provide a signature validation helper based on provided info.
            // Therefore, keep the manual HMACSHA512 implementation.
            _logger.LogDebug("Validating Paystack webhook signature manually (HMACSHA512).");
            try
            {
                using var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(_paystackSecretKey)); // Use securely loaded key
                var computedHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                // Convert byte array to lower-case hex string
                var computedHashString = BitConverter.ToString(computedHashBytes).Replace("-", "").ToLowerInvariant();

                var isValid =
                    computedHashString.Equals(signature?.Trim(), StringComparison.OrdinalIgnoreCase); // Trim signature

                if (!isValid)
                    _logger.LogWarning(
                        "Paystack webhook signature mismatch. Computed: {ComputedHash}, Received: {ReceivedSignature}",
                        computedHashString, signature);
                else
                    _logger.LogInformation("Paystack webhook signature validated successfully.");

                return Task.FromResult(isValid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Paystack webhook signature validation.");
                return Task.FromResult(false); // Treat validation errors as invalid
            }
        }

        /// <summary>
        /// Processes the validated webhook event payload from Paystack.
        /// </summary>
        public async Task<WebhookProcessingResult> ProcessWebhookEventAsync(string gatewayName, string payload)
        {
            if (!gatewayName.Equals("Paystack", StringComparison.OrdinalIgnoreCase))
                // Corrected Instantiation
                return new WebhookProcessingResult(Success: false, Message: "Invalid gateway name.");

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
                        var gatewayReference = data.GetProperty("id").GetInt64().ToString();
                        var amountKobo = data.GetProperty("amount").GetInt64();
                        var currency = data.GetProperty("currency").GetString();
                        var status = data.GetProperty("status").GetString();
                        var paidAt = data.GetProperty("paid_at").GetDateTimeOffset();
                        var gatewayResponseMsg = data.GetProperty("gateway_response").GetString();

                        if (status != "success")
                        {
                            _logger.LogWarning(
                                "Received charge.success event but status is '{Status}'. Ref: {Reference}", status,
                                internalReference);
                            // Corrected Instantiation
                            return new WebhookProcessingResult(Success: true, Message: "Charge status not 'success'.");
                        }

                        var payment = await _financeRepository.GetPaymentByReferenceAsync(internalReference);
                        if (payment == null)
                        {
                            _logger.LogError(
                                "Cannot find internal PENDING payment record for successful Paystack charge. Reference: {Reference}",
                                internalReference);
                            // Corrected Instantiation
                            return new WebhookProcessingResult(Success: false,
                                Message: "Internal pending payment record not found.");
                        }

                        var amountDecimal = (decimal)amountKobo / 100;
                        if (payment.Amount != amountDecimal)
                        {
                            _logger.LogWarning(
                                "Paystack amount mismatch for Reference: {Reference}. Expected {ExpectedAmount}, Got {ActualAmount}. Proceeding anyway but logging.",
                                internalReference, payment.Amount, amountDecimal);
                        }

                        if (payment.PaymentStatus == PaymentStatus.Completed)
                        {
                            _logger.LogWarning(
                                "Payment already completed for Reference: {Reference}. Ignoring duplicate webhook.",
                                internalReference);
                            // Corrected Instantiation
                            return new WebhookProcessingResult(Success: true, Message: "Payment already completed.");
                        }

                        await _financeService.MarkPaymentAsCompletedAsync(payment.PaymentID, paidAt, gatewayReference,
                            gatewayResponseMsg ?? "Completed via Paystack");

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
                            RawResponseData = payload
                        };
                        await _financeRepository.SavePaymentGatewayTransactionAsync(gatewayTx);
                        await _context.SaveChangesAsync(); // Ensure gateway transaction is saved

                        _logger.LogInformation(
                            "Successfully processed Paystack charge.success for Internal Reference: {InternalReference}",
                            internalReference);
                        // Corrected Instantiation
                        return new WebhookProcessingResult(Success: true, Message: "Payment successful.");

                    case "transfer.success":
                    case "transfer.failed":
                    case "transfer.reversed":
                        _logger.LogInformation(
                            "Received Paystack transfer event: {EventType}. Ref: {Reference}. (Disbursement scenario - currently ignored in payment flow)",
                            eventType, data.TryGetProperty("reference", out var trRef) ? trRef.GetString() : "N/A");
                        // Corrected Instantiation
                        return new WebhookProcessingResult(Success: true, Message: "Transfer event received.");

                    default:
                        _logger.LogInformation("Unhandled Paystack event type: {EventType}", eventType);
                        // Corrected Instantiation
                        return new WebhookProcessingResult(Success: true, Message: "Event type not handled.");
                }
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Failed to parse Paystack webhook JSON payload.");
                // Corrected Instantiation
                return new WebhookProcessingResult(Success: false, Message: "Invalid JSON payload.");
            }
            catch (KeyNotFoundException knfEx)
            {
                _logger.LogError(knfEx,
                    "Error processing webhook: Required data not found (e.g., internal payment record).");
                // Corrected Instantiation
                return new WebhookProcessingResult(Success: false, Message: knfEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing Paystack webhook.");
                // Corrected Instantiation
                return new WebhookProcessingResult(Success: false, Message: "Internal server error.");
            }
        }
    }

    // Helper record for WebhookProcessingResult if not defined elsewhere
     public record WebhookProcessingResult(bool Success, string? Message = null);
}