using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedPayments
{
    // Declare public static readonly Guids for PaymentIDs
    public static Guid Payment1ForStudent222CS01000694_Sept2023RecordId;
    public static Guid Payment2ForStudent222CS01000694_Sept2023RecordId;
    public static Guid Payment1ForStudent222CS01000694_Jan2024RecordId;
    public static Guid Payment2ForStudent222CS01000694_Jan2024RecordId;
    public static Guid Payment1ForStudent222CS01000694_Sept2024RecordId;
    public static Guid Payment2ForStudent222CS01000694_Sept2024RecordId;


    public static void Seed(ModelBuilder builder)
    {
        // Assign Guid.NewGuid() to PaymentIDs
        Payment1ForStudent222CS01000694_Sept2023RecordId = Guid.NewGuid();
        Payment2ForStudent222CS01000694_Sept2023RecordId = Guid.NewGuid();
        Payment1ForStudent222CS01000694_Jan2024RecordId = Guid.NewGuid();
        Payment2ForStudent222CS01000694_Jan2024RecordId = Guid.NewGuid();
        Payment1ForStudent222CS01000694_Sept2024RecordId = Guid.NewGuid();
        Payment2ForStudent222CS01000694_Sept2024RecordId = Guid.NewGuid();


        builder.Entity<Payment>().HasData(
            // Payments for September 2023 Financial Record
            new Payment
            {
                PaymentID = Payment1ForStudent222CS01000694_Sept2023RecordId,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2023FinancialRecordId,
                Amount = 2000,
                PaymentDate = new DateTimeOffset(new DateTime(2023, 9, 5)), // Past Date
                PaymentMethod = PaymentMethod.MobileMoney,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8), // Shorter ref for example
                PaymentStatus = PaymentStatus.Completed
            },
            new Payment
            {
                PaymentID = Payment2ForStudent222CS01000694_Sept2023RecordId,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2023FinancialRecordId,
                Amount = 2800, // Remaining amount
                PaymentDate = new DateTimeOffset(new DateTime(2023, 9, 15)), // Past Date
                PaymentMethod = PaymentMethod.BankTransfer,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
                PaymentStatus = PaymentStatus.Completed
            },

            // Payments for January 2024 Financial Record
            new Payment
            {
                PaymentID = Payment1ForStudent222CS01000694_Jan2024RecordId,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Jan2024FinancialRecordId,
                Amount = 3000,
                PaymentDate = new DateTimeOffset(new DateTime(2024, 1, 10)), // Past Date
                PaymentMethod = PaymentMethod.MobileMoney,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
                PaymentStatus = PaymentStatus.Completed
            },
            new Payment
            {
                PaymentID = Payment2ForStudent222CS01000694_Jan2024RecordId,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Jan2024FinancialRecordId,
                Amount = 2000, // Paid slightly less than total fees
                PaymentDate = new DateTimeOffset(new DateTime(2024, 1, 20)), // Past Date
                PaymentMethod = PaymentMethod.MobileMoney,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
                PaymentStatus = PaymentStatus.Completed
            },

            // Payments for September 2024 Financial Record (Overpayment example)
            new Payment
            {
                PaymentID = Payment1ForStudent222CS01000694_Sept2024RecordId,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2024FinancialRecordId,
                Amount = 6000, // Overpaid
                PaymentDate = new DateTimeOffset(new DateTime(2024, 9, 1)), // Past Date
                PaymentMethod = PaymentMethod.MobileMoney,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
                PaymentStatus = PaymentStatus.Completed
            },
            new Payment
            {
                PaymentID =
                    Payment2ForStudent222CS01000694_Sept2024RecordId, // Example of a very late, and small payment
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2024FinancialRecordId,
                Amount = 100,
                PaymentDate = new DateTimeOffset(new DateTime(2024, 10, 25)), // Very Past Date - after semester starts
                PaymentMethod = PaymentMethod.Cash,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 8),
                PaymentStatus = PaymentStatus.Completed
            }
        );
    }
}