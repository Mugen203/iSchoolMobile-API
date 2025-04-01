using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

public class RequestValidator: Validator<InitiatePaymentRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Payment amount must be positive.");
        RuleFor(x => x.Currency)
            .NotEmpty().Length(3).WithMessage("Currency code must be 3 letters (e.g., GHS).");
        RuleFor(x => x.Description)
            .NotEmpty().MaximumLength(150);
        // FinancialRecordID is optional
    }
}