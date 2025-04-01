using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Finance.InitiatePayment.Models;

namespace iSchool_Solution.Features.Finance.InitiatePayment;

public class ResponseValidator: Validator<PaymentStatusResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.PaymentID).NotEmpty();
        RuleFor(x => x.Status).IsInEnum();
        RuleFor(x => x.LastChecked).NotEmpty();
    }
}