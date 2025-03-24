using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Transcript.Download.Models;

namespace iSchool_Solution.Features.Transcript.Download;

public class RequestValidator : Validator<DownloadTranscriptRequest>
{
    public RequestValidator()
    {
        RuleFor(request => request.StudentID)
            .NotEmpty().WithMessage("Student ID is required");
            
        RuleFor(request => request.Format)
            .NotEmpty().WithMessage("Format is required")
            .WithMessage("Format must be either 'pdf' or 'docx'");
            
        RuleFor(request => request.Purpose)
            .MaximumLength(500).When(r => !string.IsNullOrEmpty(r.Purpose))
            .WithMessage("Purpose cannot exceed 500 characters");
    }
}