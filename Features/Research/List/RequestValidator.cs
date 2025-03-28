using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.List.Models;

namespace iSchool_Solution.Features.Research.List;

public class RequestValidator: Validator<ListResearchProjectsRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.Page)
            .GreaterThanOrEqualTo(1).WithMessage("Page must be greater than or equal to 1");
            
        RuleFor(request => request.PageSize)
            .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100");
    }
}