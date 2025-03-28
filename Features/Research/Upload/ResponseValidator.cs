using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Upload.Models;

namespace iSchool_Solution.Features.Research.Upload;

public class ResponseValidator: Validator<UploadResearchDocumentResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.DocumentId)
            .GreaterThan(0).WithMessage("Document ID must be greater than 0");
            
        RuleFor(response => response.DocumentTitle)
            .NotEmpty().WithMessage("Document title cannot be empty")
            .MaximumLength(100).WithMessage("Document title cannot exceed 100 characters");
            
        RuleFor(response => response.FileName)
            .NotEmpty().WithMessage("File name cannot be empty");
            
        RuleFor(response => response.FileSize)
            .GreaterThan(0).WithMessage("File size must be greater than 0");
            
        RuleFor(response => response.FileType)
            .NotEmpty().WithMessage("File type cannot be empty");
            
        RuleFor(response => response.UploadDate)
            .NotEmpty().WithMessage("Upload date cannot be empty");
            
        RuleFor(response => response.UploadedBy)
            .NotEmpty().WithMessage("Uploaded by cannot be empty");
    }
}