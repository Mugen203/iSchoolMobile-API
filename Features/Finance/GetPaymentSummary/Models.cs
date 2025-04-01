using static iSchool_Solution.Features.Finance.GetFinancialSummary.Models;

namespace iSchool_Solution.Features.Finance.GetPaymentSummary;

public class Models
{
    public sealed class PaymentHistoryRequest
    {
        // Currently no parameters needed for fetching all history for the authenticated user.
        // Could add pagination/date range later.
    }

    public sealed class PaymentHistoryResponse
    {
        public List<PaymentSummary> Payments { get; set; } = [];
    }
}