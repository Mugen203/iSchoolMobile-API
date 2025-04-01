using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Finance.GetInvoice;

public class ResponseValidator : Validator<Models.GenerateInvoiceResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.InvoiceID)
            .NotEmpty();
        RuleFor(x => x.InvoiceNumber)
            .NotEmpty();
        RuleFor(x => x.Message)
            .NotEmpty();
    }
}