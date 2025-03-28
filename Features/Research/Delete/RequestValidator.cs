using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Delete.Models;

namespace iSchool_Solution.Features.Research.Delete;

public class DeleteDocumentRequestValidator : Validator<DeleteResearchDocumentRequest>
{
    public DeleteDocumentRequestValidator()
    {
        RuleFor(request => request.DocumentID)
            .GreaterThan(0).WithMessage("Document ID must be greater than 0");
    }
}

public class DeleteProjectRequestValidator : Validator<DeleteResearchProjectRequest>
{
    public DeleteProjectRequestValidator()
    {
        RuleFor(request => request.ProjectID)
            .GreaterThan(0).WithMessage("Project ID must be greater than 0");
    }
}