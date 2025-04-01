using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Finance.ListInvoices;

public class RequestValidator : Validator<Models.ListInvoicesRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.Page)
            .GreaterThan(0);
        RuleFor(request => request.PageSize)
            .InclusiveBetween(1, 100);
        RuleFor(request => request.Status)
            .IsInEnum()
            .When(request => request.Status.HasValue);
    }
}