using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Transcript.Download.Models;

namespace iSchool_Solution.Features.Transcript.Download;

public class ResponseValidator : Validator<DownloadTranscriptResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.TranscriptID)
            .NotNull().WithMessage("Transcript ID cannot be null");

        RuleFor(response => response.IsOfficial)
            .NotNull().WithMessage("IsOfficial cannot be null");

        RuleFor(response => response.GeneratedDate)
            .NotNull().WithMessage("Generated Date cannot be null");

        RuleFor(response => response.FileName)
            .NotNull().WithMessage("FileName cannot be null")
            .NotEmpty().WithMessage("FileName cannot be empty");

        RuleFor(response => response.FileUrl)
            .NotNull().WithMessage("FileUrl cannot be null")
            .NotEmpty().WithMessage("FileUrl cannot be empty");

        RuleFor(response => response.FileType)
            .NotNull().WithMessage("FileType cannot be null")
            .NotEmpty().WithMessage("FileType cannot be empty");

        RuleFor(response => response.FileSize)
            .NotNull().WithMessage("FileSize cannot be null")
            .NotEmpty().WithMessage("FileSize cannot be empty");

        RuleFor(response => response.ExpiryDays)
            .NotNull().WithMessage("Expiry days cannot be null")
            .GreaterThanOrEqualTo(0).WithMessage("Expiry days cannot be negative");

        RuleFor(response => response.IsPasswordProtected)
            .NotNull().WithMessage("IsPasswordProtected cannot be null");

        RuleFor(response => response.RequiresAuthentication)
            .NotNull().WithMessage("RequiresAuthentication cannot be null");
    }
}