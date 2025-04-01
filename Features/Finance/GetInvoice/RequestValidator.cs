using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Finance.GetInvoice;

public class RequestValidator : Validator<Models.GenerateInvoiceRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.FinancialRecordID)
            .NotEmpty()
            .WithMessage("FinancialRecordID is required to generate an invoice.");
    }
}