using FastEndpoints;
using iSchool_Solution.Services;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

// Webhooks typically don't use standard auth
public class WebhookEndpoint : Endpoint<EmptyRequest, WebhookProcessingResponse>
{
    private readonly PaystackService _paystackService;
    private readonly ILogger<WebhookEndpoint> _logger; 
    
    public WebhookEndpoint(PaystackService paystackService, ILogger<WebhookEndpoint> logger)
    {
        _paystackService = paystackService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/finance/payment/webhook/{gatewayName}");
        AllowAnonymous();
        Summary(s => { 
            s.Summary = "Handles incoming webhooks from payment gateways like Paystack.";
            s.Description = "Validates the webhook signature and processes the event payload (e.g., charge success). Do not call this directly.";
            s.Responses[200] = "Webhook processed successfully.";
            s.Responses[400] = "Bad Request (e.g., invalid signature, invalid payload).";
            s.Responses[500] = "Internal server error during processing.";
        });
        Tags("Finance", "Webhook");
    }

    public override async Task HandleAsync(EmptyRequest _, CancellationToken ct)
    {
        var gatewayName = Route<string>("gatewayName");
        if (string.IsNullOrEmpty(gatewayName))
        {
            await SendErrorsAsync(400, ct); // Gateway name is required in the route
            return;
        }
        _logger.LogInformation("Received webhook event for gateway: {GatewayName}", gatewayName);

        string jsonPayload = string.Empty; // Initialize to handle potential errors

        try
        {
            // 1. Read raw request body
            // Access Request via HttpContext
            HttpContext.Request.EnableBuffering();
            using (var reader = new StreamReader(HttpContext.Request.Body, leaveOpen: true))
            {
                 jsonPayload = await reader.ReadToEndAsync(ct);
                 HttpContext.Request.Body.Position = 0;
            }


            // 2. Get signature from header
            // Access Headers via HttpContext.Request.Headers
            // Use TryGetValue for safety
             if (!HttpContext.Request.Headers.TryGetValue("x-paystack-signature", out var signatureValues)) // Common Paystack header name
             {
                  _logger.LogWarning("Paystack webhook signature header 'x-paystack-signature' not found for gateway: {GatewayName}", gatewayName);
                  await SendErrorsAsync(400, ct); // Bad request - missing signature
                  return;
             }
             var signature = signatureValues.FirstOrDefault() ?? string.Empty;


            // 3. Validate signature (CRITICAL security step)
            var isValid = await _paystackService.ValidateWebhookSignatureAsync(gatewayName, jsonPayload, signature);

            if (!isValid)
            {
                 _logger.LogWarning("Invalid webhook signature received for gateway: {GatewayName}", gatewayName);
                 await SendErrorsAsync(400, ct); // Bad request - invalid signature
                 return;
            }

            _logger.LogInformation("Webhook signature validated successfully for {GatewayName}.", gatewayName);

            // 4. Process the event payload
            var result = await _paystackService.ProcessWebhookEventAsync(gatewayName, jsonPayload);

            // 5. Send appropriate response to gateway
            if (result.Success)
            {
                await SendOkAsync(new WebhookProcessingResponse { Success = true, Message = "Webhook processed." }, ct);
            }
            else
            {
                _logger.LogError("Webhook processing failed for {GatewayName}. Reason: {Reason}", gatewayName, result.Message);
                await SendStringAsync(result.Message ?? "Webhook processing failed.", 500, cancellation: ct);
            }
        }
        catch (InvalidDataException ex) // Catch specific error if reader fails
        {
            _logger.LogError(ex, "Error reading webhook request body for gateway: {GatewayName}", gatewayName);
            await SendErrorsAsync(400, ct); // Bad Request
        }
        catch (Exception ex)
        {
             _logger.LogError(ex, "Unexpected error processing webhook for gateway: {GatewayName}. Payload: {Payload}", gatewayName, jsonPayload); // Log payload on error
             // Don't expose internal details in production
             await SendStringAsync("An internal error occurred processing the webhook.", 500, cancellation: ct);
        }
    }
}