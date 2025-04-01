using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Finance.GetFinancialSummary.Models;

namespace iSchool_Solution.Features.Finance.GetFinancialSummary;

public class ResponseValidator : Validator<FinancialSummaryResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.OverallOutstandingBalance)
            .NotNull(); // Can be zero or positive/negative (credit)
        RuleFor(x => x.NextDueDate)
            .GreaterThan(DateTimeOffset.MinValue).When(x => x.NextDueDate.HasValue);

        RuleFor(x => x.SemesterSummaries)
            .NotNull().WithMessage("Semester summaries list cannot be null.")
            .ForEach(summary => summary.SetValidator(new SemesterFinanceDetailsValidator()));
    }
}

public class SemesterFinanceDetailsValidator : Validator<SemesterFinanceDetails>
{
    public SemesterFinanceDetailsValidator()
    {
        RuleFor(x => x.FinancialRecordID)
            .NotEmpty();
        RuleFor(x => x.Semester)
            .NotEmpty();
        RuleFor(request => request.AcademicYear)
            .NotEmpty().WithMessage("Academic year is required")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("Academic year must be in format YYYY-YYYY");
        RuleFor(x => x.TotalFeesForSemester)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.AmountPaidForSemester)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.OutstandingBalanceForSemester)
            .NotNull();
        RuleFor(x => x.LastUpdated)
            .NotEmpty();
        RuleFor(x => x.FeeItems)
            .NotNull().WithMessage("Fee items list cannot be null.")
            .ForEach(item => item.SetValidator(new FeeItemSummaryValidator()));
        RuleFor(x => x.Payments)
            .NotNull().WithMessage("Payments list cannot be null.")
            .ForEach(payment => payment.SetValidator(new PaymentSummaryValidator()));
    }
}

public class FeeItemSummaryValidator : Validator<FeeItemSummary>
{
    public FeeItemSummaryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(x => x.Amount)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.Category)
            .IsInEnum();
        RuleFor(x => x.PaymentStatus)
            .IsInEnum();
        RuleFor(x => x.DueDate)
            .GreaterThan(DateTimeOffset.MinValue)
            .When(x => x.DueDate.HasValue);
        RuleFor(x => x.IsRequired)
            .NotNull();
    }
}

public class PaymentSummaryValidator : Validator<PaymentSummary>
{
    public PaymentSummaryValidator()
    {
        RuleFor(x => x.PaymentID)
            .NotEmpty();
        RuleFor(x => x.Amount)
            .NotNull()
            .GreaterThan(0);
        RuleFor(x => x.PaymentDate)
            .NotEmpty();
        RuleFor(x => x.PaymentMethod)
            .IsInEnum();
        RuleFor(x => x.ReferenceNumber)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Status)
            .IsInEnum();
    }
}