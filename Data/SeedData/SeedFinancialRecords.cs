using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedFinancialRecords
{
    // Declare public static readonly Guids for FinancialRecordIDs
    public static Guid Student222CS01000694_Sept2023FinancialRecordId;
    public static Guid Student222CS01000694_Jan2024FinancialRecordId;
    public static Guid Student222CS01000694_Sept2024FinancialRecordId;


    public static void Seed(ModelBuilder builder)
    {
        // Assign Guid.NewGuid() to FinancialRecordIds
        Student222CS01000694_Sept2023FinancialRecordId = Guid.NewGuid();
        Student222CS01000694_Jan2024FinancialRecordId = Guid.NewGuid();
        Student222CS01000694_Sept2024FinancialRecordId = Guid.NewGuid();


        builder.Entity<FinancialRecord>().HasData(
            // Financial Record for September 2023
            new FinancialRecord
            {
                FinancialRecordID = Student222CS01000694_Sept2023FinancialRecordId,
                StudentID = "222CS01000694",
                Semester = Semester.September,
                AcademicYear = "2023-2024",
                TotalFees = 4800,
                AmountPaid = 4800,
                OutstandingBalance = 0,
                LastUpdated = new DateTimeOffset(new DateTime(2023, 9, 15)) // Past date
            },
            // Financial Record for January 2024
            new FinancialRecord
            {
                FinancialRecordID = Student222CS01000694_Jan2024FinancialRecordId,
                StudentID = "222CS01000694",
                Semester = Semester.January,
                AcademicYear = "2023-2024",
                TotalFees = 5200,
                AmountPaid = 5000,
                OutstandingBalance = 200,
                LastUpdated = new DateTimeOffset(new DateTime(2024, 1, 20)) // Past date
            },
            // Financial Record for September 2024
            new FinancialRecord
            {
                FinancialRecordID = Student222CS01000694_Sept2024FinancialRecordId,
                StudentID = "222CS01000694",
                Semester = Semester.September,
                AcademicYear = "2024-2025",
                TotalFees = 5500,
                AmountPaid = 6000,
                OutstandingBalance = -500, // Overpaid example - credit balance
                LastUpdated = new DateTimeOffset(new DateTime(2024, 9, 1)) // Past date
            }
        );
    }
}