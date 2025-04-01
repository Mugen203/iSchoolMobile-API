using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Finance.GetInvoiceDetails;

public class ResponseValidator : Validator<Models.InvoiceDetailsResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.InvoiceID)
            .NotEmpty();
        RuleFor(response => response.InvoiceNumber)
            .NotEmpty();
        RuleFor(response => response.StudentID)
            .NotEmpty();
        RuleFor(response => response.StudentName)
            .NotEmpty();
        // FinancialRecordID can be null
        RuleFor(response => response.CreatedDate)
            .NotEmpty();
        RuleFor(response => response.DueDate)
            .NotEmpty();
        RuleFor(response => response.Subtotal)
            .NotNull();
        RuleFor(response => response.DiscountAmount)
            .NotNull();
        RuleFor(response => response.TotalAmount)
            .NotNull();
        RuleFor(response => response.StatusDisplay)
            .NotEmpty();
        // Notes can be null
        RuleFor(response => response.LineItems)
            .NotNull();
        RuleForEach(response => response.LineItems)
            .SetValidator(new InvoiceLineItemDetailsValidator());
    }
}

public class InvoiceLineItemDetailsValidator : Validator<Models.InvoiceLineItemDetails>
{
    public InvoiceLineItemDetailsValidator()
    {
        RuleFor(x => x.InvoiceLineItemID)
            .GreaterThan(0);
        RuleFor(x => x.Description)
            .NotEmpty();
        RuleFor(x => x.Quantity)
            .GreaterThan(0);
        RuleFor(x => x.UnitPrice)
            .NotNull();
        RuleFor(x => x.LineTotal)
            .NotNull();
        // FeeItemID can be null
    }
}