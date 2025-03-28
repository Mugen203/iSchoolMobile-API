using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Download.Models;

namespace iSchool_Solution.Features.Research.Download;

public class RequestValidator: Validator<DownloadResearchDocumentRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.DocumentID)
            .GreaterThan(0).WithMessage("Document ID must be greater than 0");
    }
}