using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Research.List.Models;

namespace iSchool_Solution.Features.Research.List;

public class ResponseValidator : Validator<ListResearchProjectsResponse>
{
    public ResponseValidator()
    {
        RuleFor(response => response.Projects)
            .NotNull().WithMessage("Projects list cannot be null")
            .ForEach(project => project.SetValidator(new ResearchProjectItemValidator()));
            
        RuleFor(response => response.CurrentPage)
            .GreaterThanOrEqualTo(1).WithMessage("Current page must be greater than or equal to 1");
            
        RuleFor(response => response.TotalPages)
            .GreaterThanOrEqualTo(0).WithMessage("Total pages must be non-negative");
            
        RuleFor(response => response.TotalCount)
            .GreaterThanOrEqualTo(0).WithMessage("Total count must be non-negative");
    }
    
    
    public class ResearchProjectItemValidator : Validator<ResearchProjectListItem>
    {
        public ResearchProjectItemValidator()
        {
            RuleFor(project => project.ProjectID)
                .NotEmpty().WithMessage("Project ID cannot be empty");
            
            RuleFor(project => project.Title)
                .NotEmpty().WithMessage("Project title cannot be empty")
                .MaximumLength(200).WithMessage("Project title cannot exceed 200 characters");
            
            RuleFor(project => project.MainAuthorName)
                .NotEmpty().WithMessage("Main author name cannot be empty");
            
            RuleFor(project => project.Department)
                .NotEmpty().WithMessage("Department cannot be empty");
            
            RuleFor(project => project.Status)
                .IsInEnum().WithMessage("Status must be a valid research status");
            
            RuleFor(project => project.DateSubmitted)
                .NotEmpty().WithMessage("Date submitted cannot be empty");
        }
    }
}