using FastEndpoints;
using FluentValidation;
using static iSchool_Solution.Features.Dashboard.Models;

namespace iSchool_Solution.Features.Dashboard;

public class ResponseValidator : Validator<DashboardSummaryResponse>
{
    public ResponseValidator()
    {
        RuleFor(x => x.Header)
            .NotNull().SetValidator(new HeaderInfoValidator());

        RuleFor(x => x.KeyMetrics)
            .NotNull().SetValidator(new KeyMetricsInfoValidator());

        RuleFor(x => x.Announcements)
            .NotNull()
            .ForEach(v => v.SetValidator(new AnnouncementCardInfoValidator()));
    }

    public class HeaderInfoValidator : Validator<HeaderInfo>
    {
        public HeaderInfoValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty();
            RuleFor(x => x.StudentID).NotEmpty();
            RuleFor(x => x.UnreadNotificationCount).GreaterThanOrEqualTo(0);
        }
    }

    public class NextClassInfoValidator : Validator<NextClassInfo> 
    {
        public NextClassInfoValidator()
        {
            RuleFor(x => x.CourseName).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
        }
    }

    public class KeyMetricsInfoValidator : Validator<KeyMetricsInfo>
    {
        public KeyMetricsInfoValidator()
        {
            RuleFor(x => x.GPAMetrics).NotNull().SetValidator(new GPAMetricValidator());
            RuleFor(x => x.BalanceMetrics).NotNull().SetValidator(new BalanceMetricValidator());
        }
    }

    public class GPAMetricValidator : Validator<GPAMetric>
    {
        public GPAMetricValidator()
        {
            RuleFor(x => x.CurrentGPA).InclusiveBetween(0, 4.0); 
            RuleFor(x => x.LastSemesterGPA).GreaterThanOrEqualTo(0)
                .When(x => x.LastSemesterGPA.HasValue); // Optional GPA, if present, >= 0
        }
    }

    public class BalanceMetricValidator : Validator<BalanceMetric>
    {
        public BalanceMetricValidator()
        {
            RuleFor(x => x.OutstandingBalance).GreaterThanOrEqualTo(0); // Balance can be 0 or positive
            RuleFor(x => x.NextDueDate)
                .GreaterThan(DateTime.MinValue)
                .When(x => x.NextDueDate.HasValue); // Optional Date, if present, should be valid date
        }
    }

    public class AnnouncementCardInfoValidator : Validator<AnnouncementCardInfo>
    {
        public AnnouncementCardInfoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}