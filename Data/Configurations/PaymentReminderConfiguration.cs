using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSchool_Solution.Data.Configurations;

public class PaymentReminderConfiguration : IEntityTypeConfiguration<PaymentReminder>
{
    public void Configure(EntityTypeBuilder<PaymentReminder> builder)
    {
        // Configure Relationship with Student
        builder.HasOne(pr => pr.Student)
            .WithMany() // Student doesn't have ICollection<PaymentReminder>
            .HasForeignKey(pr => pr.StudentID)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure Optional Relationship with FinancialRecord
        builder.HasOne(pr => pr.FinancialRecord)
            .WithMany() // Assuming FinancialRecord doesn't have ICollection<PaymentReminder>
            .HasForeignKey(pr => pr.FinancialRecordID)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict); // Keep reminder even if record deleted? Or Cascade? Depends on reqs. SetNull is safer.

        // Configure Optional Relationship with FeeItem
        builder.HasOne(pr => pr.FeeItem)
            .WithMany() // FeeItem doesn't have ICollection<PaymentReminder>
            .HasForeignKey(pr => pr.FeeItemID)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull); // Keep reminder even if fee item deleted? Or Cascade? SetNull is safer.

        // Indexing for querying reminders by status and date
        builder.HasIndex(pr => new { pr.Status, pr.ReminderDate });
    }
}