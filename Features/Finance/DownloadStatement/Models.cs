using static iSchool_Solution.Features.Finance.GetFinancialSummary.Models;

namespace iSchool_Solution.Features.Finance.DownloadStatement;

public class Models
{
    public class DownloadStatementRequest
    {
        public Guid FinancialRecordID { get; set; }
    }

    // No specific response DTO needed, endpoint sends the file.

    // Helper class for data needed by PDF generator
    // We can reuse/adapt the SemesterFinanceDetails from GetFinancialSummary
    public class StatementPdfData : SemesterFinanceDetails
    {
        public string StudentName { get; set; } = string.Empty;
        public string StudentID { get; set; } = string.Empty;
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
    }
}