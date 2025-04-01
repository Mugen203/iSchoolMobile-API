using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;


namespace iSchool_Solution.Features.Finance.InitiatePayment;

[AllowAnonymous] // Webhooks typically don't use standard auth
public class WebhookEndpoint : Endpoint<EmptyRequest, Models.WebhookProcessingResponse> // Request body read manually
{
    private readonly PaystackService _paystackService;
    private readonly FinanceService _financeService; // To update records
    private readonly ILogger<Endpoint> _logger;

    public WebhookEndpoint(PaystackService paystackService, FinanceService financeService, ILogger<Endpoint> logger)
    {
        _paystackService = paystackService;
        _financeService = financeService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/finance/payment/webhook/{gatewayName}"); // Route indicates gateway
         Summary(s => { /* Add Swagger Summary */ });
        Tags("Finance", "Webhook");
         AllowFileUploads(false);
    }

    public override async Task HandleAsync(EmptyRequest _, CancellationToken ct)
    {
        var gatewayName = Route<string>("gatewayName");
         _logger.LogInformation("Received webhook event for gateway: {GatewayName}", gatewayName);

        try
        {
            // 1. Read raw request body
            Request.EnableBuffering();
            string jsonPayload = await new StreamReader(Request.Body).ReadToEndAsync(ct);
            Request.Body.Position = 0; // Reset position if needed elsewhere

            // 2. Get signature from header (specific to gateway, e.g., "Stripe-Signature")
            var signature = Request.Headers["X-Gateway-Signature"].ToString(); // Example header

            // 3. Validate signature (CRITICAL security step)
            var isValid = await _gatewayService.ValidateWebhookSignatureAsync(gatewayName, jsonPayload, signature);

            if (!isValid)
            {
                 _logger.LogWarning("Invalid webhook signature received for gateway: {GatewayName}", gatewayName);
                await SendErrorsAsync(400, ct); // Bad request - invalid signature
                return;
            }

            _logger.LogInformation("Webhook signature validated successfully for {GatewayName}.", gatewayName);

            // 4. Process the event payload
            var result = await _gatewayService.ProcessWebhookEventAsync(gatewayName, jsonPayload);

            // 5. Send appropriate response to gateway
            if (result.Success)
            {
                await SendOkAsync(new Models.WebhookProcessingResponse { Success = true, Message = "Webhook processed." }, ct);
            }
            else
            {
                _logger.LogError("Webhook processing failed for {GatewayName}. Reason: {Reason}", gatewayName, result.Message);
                // Send 500 or potentially 400 depending on why processing failed
                await SendStringAsync(result.Message ?? "Webhook processing failed.", 500, cancellation: ct);
            }
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Error processing webhook for gateway: {GatewayName}", gatewayName);
             await SendErrorsAsync(500, ct); // Internal Server Error
        }
    }
}