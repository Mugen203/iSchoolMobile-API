using System.Security.Claims;
using FastEndpoints;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

[Authorize]
public class Endpoint : Endpoint<InitiatePaymentRequest, InitiatePaymentResponse>
{
    private readonly PaystackService _paystackService; // Inject specific gateway service
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(PaystackService paystackService, ILogger<Endpoint> logger)
    {
        _paystackService = paystackService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/finance/payment/initiate");
        Roles("Student");
        Summary(s =>
        {
            s.Summary = "Initiates a payment process with the payment gateway.";
            s.Description =
                "Creates a payment intent/transaction with Paystack and returns details needed for the frontend to proceed (e.g., authorization URL).";
            s.Responses[200] = "Payment initiation successful, returns gateway details.";
            s.Responses[400] = "Bad Request (e.g., invalid amount or currency).";
            s.Responses[401] = "Unauthorized.";
            s.Responses[500] = "An unexpected error occurred during payment initiation.";
        });
        Tags("Finance");
    }

    public override async Task HandleAsync(InitiatePaymentRequest req, CancellationToken ct)
    {
        var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var studentEmail = User.FindFirstValue(ClaimTypes.Email);

        if (string.IsNullOrEmpty(studentId))
        {
            _logger.LogWarning("Student ID claim (NameIdentifier) not found in token.");
            await SendUnauthorizedAsync(ct);
            return;
        }

        // Also validate email - it's required by Paystack
        if (string.IsNullOrEmpty(studentEmail))
        {
            _logger.LogWarning("Student Email claim not found in token for StudentID {StudentID}.", studentId);
            AddError("User email claim is missing, cannot initiate payment.");
            await SendErrorsAsync(400, ct); // Bad request as email is needed
            return;
        }


        _logger.LogInformation(
            "Initiating payment for StudentID: {StudentID}, Email: {StudentEmail}, Amount: {Amount} {Currency}",
            studentId, studentEmail, req.Amount, req.Currency);

        try
        {
            // Pass all required arguments: request DTO, studentId, studentEmail
            var response = await _paystackService.CreatePaymentIntentAsync(req, studentId, studentEmail);
            await SendOkAsync(response, ct);
        }
        catch (ArgumentNullException argNullEx) // Catch specific argument errors potentially thrown by service
        {
            _logger.LogWarning(argNullEx, "Invalid arguments during payment initiation for StudentID: {StudentID}",
                studentId);
            AddError(argNullEx.Message);
            await SendErrorsAsync(400, ct);
        }
        catch (ApplicationException appEx) // Catch exceptions specifically from Paystack interaction
        {
            _logger.LogError(appEx, "Paystack service error during payment initiation for StudentID: {StudentID}",
                studentId);
            AddError(appEx.Message); // Display the service error message
            await SendErrorsAsync(502, ct); // 502 Bad Gateway might be appropriate here
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error initiating payment for StudentID: {StudentID}", studentId);
            AddError("An unexpected error occurred while initiating the payment."); // Generic message for user
            await SendErrorsAsync(500, ct);
        }
    }
}