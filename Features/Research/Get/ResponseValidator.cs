using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.Get.Models;

namespace iSchool_Solution.Features.Research.Get;

public class ResponseValidator : Validator<GetResearchProjectResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.Project)
            .NotNull().WithMessage("Project cannot be null")
            .SetValidator(new ResearchProjectDetailsValidator());
    }
}

public class ResearchProjectDetailsValidator : Validator<ResearchProjectDetails>
{
    public ResearchProjectDetailsValidator()
    {
        RuleFor(project => project.ProjectID)
            .NotEmpty().WithMessage("Project ID cannot be empty");
            
        RuleFor(project => project.Title)
            .NotEmpty().WithMessage("Project title cannot be empty")
            .MaximumLength(200).WithMessage("Project title cannot exceed 200 characters");
            
        RuleFor(project => project.Abstract)
            .NotEmpty().WithMessage("Abstract cannot be empty");
            
        RuleFor(project => project.Keywords)
            .NotNull().WithMessage("Keywords cannot be null");
            
        RuleFor(project => project.MainAuthor)
            .NotNull().WithMessage("Main author cannot be null");
            
        RuleFor(project => project.Department)
            .NotEmpty().WithMessage("Department cannot be empty");
            
        RuleFor(project => project.Status)
            .IsInEnum().WithMessage("Status must be a valid research status");
            
        RuleFor(project => project.DateSubmitted)
            .NotEmpty().WithMessage("Date submitted cannot be empty");
            
        RuleFor(project => project.Contributors)
            .NotNull().WithMessage("Contributors list cannot be null");
            
        RuleFor(project => project.Documents)
            .NotNull().WithMessage("Documents list cannot be null");
    }
}
