using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedFeeItems
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<FeeItem>().HasData(
            // Fee Items for September 2023 Financial Record
            new FeeItem
            {
                Id = 1,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2023FinancialRecordId,
                Description = "Tuition Fee - September 2023",
                Amount = 4500,
                FeeItemCategory = FeeItemCategory.Tuition,
                isRequired = true
            },
            new FeeItem
            {
                Id = 2,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2023FinancialRecordId,
                Description = "Dues - September 2023",
                Amount = 300,
                FeeItemCategory = FeeItemCategory.Dues,
                isRequired = true
            },

            // Fee Items for January 2024 Financial Record
            new FeeItem
            {
                Id = 3,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Jan2024FinancialRecordId,
                Description = "Tuition Fee - January 2024",
                Amount = 5000,
                FeeItemCategory = FeeItemCategory.Tuition, isRequired = true
            },
            new FeeItem
            {
                Id = 4,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Jan2024FinancialRecordId,
                Description = "Library Fee - January 2024",
                Amount = 200,
                FeeItemCategory = FeeItemCategory.Library,
                isRequired = false // Example of non-required fee
            },

            // Fee Items for September 2024 Financial Record
            new FeeItem
            {
                Id = 5,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2024FinancialRecordId,
                Description = "Tuition Fee - September 2024",
                Amount = 5200,
                FeeItemCategory = FeeItemCategory.Tuition,
                isRequired = true
            },
            new FeeItem
            {
                Id = 6,
                FinancialRecordID = SeedFinancialRecords.Student222CS01000694_Sept2024FinancialRecordId,
                Description = "Dues - September 2024",
                Amount = 300,
                FeeItemCategory = FeeItemCategory.Dues,
                isRequired = true
            }
        );
    }
}