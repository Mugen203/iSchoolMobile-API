using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Finance.ListInvoices;

public class ResponseValidator : Validator<Models.ListInvoicesResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.Invoices)
            .NotNull();
        RuleForEach(response => response.Invoices)
            .SetValidator(new InvoiceSummaryValidator());
        RuleFor(response => response.TotalCount)
            .GreaterThanOrEqualTo(0);
        RuleFor(response => response.CurrentPage)
            .GreaterThanOrEqualTo(0); // Page could be 0 if no results
        RuleFor(response => response.TotalPages)
            .GreaterThanOrEqualTo(0);
    }
}

public class InvoiceSummaryValidator : Validator<Models.InvoiceSummary>
{
    public InvoiceSummaryValidator()
    {
        RuleFor(response => response.InvoiceID)
            .NotEmpty();
        RuleFor(response => response.InvoiceNumber)
            .NotEmpty();
        RuleFor(response => response.CreatedDate)
            .NotEmpty();
        RuleFor(response => response.DueDate)
            .NotEmpty();
        RuleFor(response => response.TotalAmount)
            .NotNull();
        RuleFor(response => response.StatusDisplay)
            .NotEmpty();
    }
}