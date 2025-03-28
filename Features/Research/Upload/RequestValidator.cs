using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Upload.Models;

namespace iSchool_Solution.Features.Research.Upload;

public class RequestValidator: Validator<UploadResearchDocumentRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.ProjectId)
            .GreaterThan(0).WithMessage("Project ID must be greater than 0");
            
        RuleFor(request => request.DocumentTitle)
            .NotEmpty().WithMessage("Document title cannot be empty")
            .MaximumLength(100).WithMessage("Document title cannot exceed 100 characters");
            
        RuleFor(request => request.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
            
        RuleFor(request => request.File)
            .NotNull().WithMessage("File cannot be null")
            .Must(file => file != null && file.Length > 0).WithMessage("File cannot be empty")
            .Must(file => file == null || file.Length <= 20971520) // 20MB max
            .WithMessage("File size cannot exceed 20MB");
    }
}