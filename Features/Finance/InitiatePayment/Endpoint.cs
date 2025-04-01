// Assuming a PaymentGatewayService exists
using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

[Authorize]
public class Endpoint : Endpoint<InitiatePaymentRequest, InitiatePaymentResponse>
{
    private readonly PaystackService _gatewayService; // Inject specific gateway service
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(PaystackService gatewayService, ILogger<Endpoint> logger)
    {
        _gatewayService = gatewayService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/finance/payment/initiate");
        Roles("Student");
        Summary(s =>
        {
            /* Add Swagger Summary */
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(InitiatePaymentRequest req, CancellationToken ct)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(studentId))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }

        _logger.LogInformation("Initiating payment for StudentID: {StudentID}, Amount: {Amount} {Currency}", studentId,
            req.Amount, req.Currency);

        try
        {
            // Call service to interact with payment gateway (e.g., Stripe, Paystack)
            var response = await _gatewayService.CreatePaymentIntentAsync(req, studentId);
            await SendOkAsync(response, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initiating payment for StudentID: {StudentID}", studentId);
            await SendErrorsAsync(500, ct);
        }
    }
}