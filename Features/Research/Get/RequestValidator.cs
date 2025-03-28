using FastEndpoints;
using FluentValidation;

namespace iSchool_Solution.Features.Research.Get;

public class RequestValidator : Validator<Models.GetResearchProjectRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.ProjectID)
            .GreaterThan(0).WithMessage("Project ID must be greater than 0");
    }
}