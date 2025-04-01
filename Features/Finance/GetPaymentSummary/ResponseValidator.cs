using FastEndpoints;
using FluentValidation;
using iSchool_Solution.Features.Finance.GetFinancialSummary;
using static iSchool_Solution.Features.Finance.GetPaymentSummary.Models;

namespace iSchool_Solution.Features.Finance.GetPaymentSummary;

public class ResponseValidator: Validator<PaymentHistoryResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.Payments)
            .NotNull().WithMessage("Payments list cannot be null.")
            .ForEach(payment => 
                payment.SetValidator(new PaymentSummaryValidator()));
    }
}
