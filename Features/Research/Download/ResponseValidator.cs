using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Download.Models;

namespace iSchool_Solution.Features.Research.Download;

public class ResponseValidator: Validator<DownloadResearchDocumentResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.DocumentID)
            .GreaterThan(0).WithMessage("Document ID must be greater than 0");
            
        RuleFor(response => response.DocumentTitle)
            .NotEmpty().WithMessage("Document title cannot be empty");
            
        RuleFor(response => response.FileName)
            .NotEmpty().WithMessage("File name cannot be empty");
            
        RuleFor(response => response.FileType)
            .NotEmpty().WithMessage("File type cannot be empty");
            
        RuleFor(response => response.FileUrl)
            .NotEmpty().WithMessage("File URL cannot be empty")
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Relative))
            .WithMessage("File URL must be a valid relative URI");
            
        RuleFor(response => response.FileSize)
            .GreaterThan(0).WithMessage("File size must be greater than 0");
            
        RuleFor(response => response.DownloadCount)
            .GreaterThanOrEqualTo(0).WithMessage("Download count cannot be negative");
    }
}