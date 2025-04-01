using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Finance.Common;

public class Models
{
    public class PaymentsByMethodReport
    {
        public PaymentMethod PaymentMethod { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OutstandingBalanceReport
    {
        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty; // Added Department Name
        public decimal OutstandingBalance { get; set; }
        public DateTimeOffset? LastPaymentDate { get; set; } // Made nullable
    }
}