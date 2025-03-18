using System.ComponentModel.DataAnnotations;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities.DTO.FinanceManagement;

public record MakePaymentRequest
{
    [Required(ErrorMessage = "FinancialRecordID is required")]
    public Guid FinancialRecordID { get; init; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; init; }

    [Required(ErrorMessage = "Payment Method is required")]
    public PaymentMethod Method { get; init; }

    public string ReferenceNumber { get; init; } = string.Empty;
}