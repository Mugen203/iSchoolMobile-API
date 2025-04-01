using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using static iSchool_Solution.Features.Finance.GetFinancialSummary.Models;
using static iSchool_Solution.Features.Finance.GetPaymentHistory.Models;
using static iSchool_Solution.Features.Finance.GetPaymentSummary.Models;


namespace iSchool_Solution.Services;

//TODO: Refactor

public class FinanceService
{
    private readonly FinanceRepository _financeRepository;
    private readonly StudentRepository _studentRepository; // Needed for RecordPayment validation
    private readonly ApplicationDbContext _context; // For transactions
    private readonly EmailService _emailService;
    private readonly ILogger<FinanceService> _logger;

    public FinanceService(
        FinanceRepository financeRepository,
        StudentRepository studentRepository,
        ApplicationDbContext context,
        ILogger<FinanceService> logger,
        EmailService emailService)
    {
        _financeRepository = financeRepository;
        _studentRepository = studentRepository;
        _context = context;
        _logger = logger;
        _emailService = emailService;
    }

    public async Task<FinancialSummaryResponse> GetStudentFinancialSummaryAsync(string studentId)
    {
        _logger.LogInformation("Fetching financial summary for StudentID: {StudentID}", studentId);
        var records = await _financeRepository.GetFinancialRecordsByStudentAsync(studentId);

        if (records.Count == 0)
            // Return an empty summary if no records exist
            return new FinancialSummaryResponse
            {
                OverallOutstandingBalance = 0m,
                NextDueDate = null,
                SemesterSummaries = new List<SemesterFinanceDetails>()
            };

        // Calculate overall outstanding balance and next due date from all records
        var overallOutstanding = 0m;
        List<FeeItem> allUnpaidItems = [];

        foreach (var record in records)
        {
            // Ensure individual record balance is correct (could also be a method on the entity)
            record.OutstandingBalance = record.TotalFees - record.AmountPaid; // Simple recalculation example
            var unpaidItemsInRecord = record.FeeItems.Where(fi => fi.PaymentStatus != PaymentStatus.Completed).ToList();
            overallOutstanding += unpaidItemsInRecord.Sum(fi => fi.Amount); // Sum unpaid items
            allUnpaidItems.AddRange(unpaidItemsInRecord);
        }

        var nextDueDate = allUnpaidItems
            .Where(fi => fi.DueDate.HasValue && fi.DueDate.Value > DateTimeOffset.UtcNow)
            .OrderBy(fi => fi.DueDate.Value)
            .Select(fi => fi.DueDate) // Select the Nullable<DateTimeOffset>
            .FirstOrDefault(); // Get the first (earliest) or null

        var summaryResponse = new FinancialSummaryResponse
        {
            OverallOutstandingBalance = overallOutstanding,
            NextDueDate = nextDueDate,
            SemesterSummaries = records.Select(rec => new SemesterFinanceDetails
            {
                FinancialRecordID = rec.FinancialRecordID,
                Semester = rec.Semester.ToString(),
                AcademicYear = rec.AcademicYear,
                TotalFeesForSemester = rec.TotalFees,
                AmountPaidForSemester = rec.AmountPaid,
                OutstandingBalanceForSemester = rec.OutstandingBalance, // Use recalculated balance
                LastUpdated = rec.LastUpdated,
                FeeItems = rec.FeeItems.Select(fi => new FeeItemSummary
                {
                    Id = fi.Id,
                    Description = fi.Description,
                    Amount = fi.Amount,
                    Category = fi.FeeItemCategory,
                    PaymentStatus = fi.PaymentStatus,
                    DueDate = fi.DueDate,
                    IsRequired = fi.isRequired
                }).ToList(),
                Payments = rec.Payments.Select(p => new Features.Finance.GetFinancialSummary.Models.PaymentSummary
                {
                    PaymentID = p.PaymentID,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod,
                    ReferenceNumber = p.ReferenceNumber,
                    Status = p.PaymentStatus
                }).OrderByDescending(p => p.PaymentDate).ToList() // Show recent payments first
            }).ToList()
        };

        _logger.LogInformation("Successfully fetched financial summary for StudentID: {StudentID}", studentId);
        return summaryResponse;
    }

    public async Task<PaymentHistoryResponse> GetStudentPaymentHistoryAsync(string studentId)
    {
        _logger.LogInformation("Fetching payment history for StudentID: {StudentID}", studentId);
        var payments = await _financeRepository.GetPaymentsByStudentAsync(studentId);

        var response = new PaymentHistoryResponse
        {
            Payments = payments.Select(p => new Features.Finance.GetFinancialSummary.Models.PaymentSummary
            {
                PaymentID = p.PaymentID,
                Amount = p.Amount,
                PaymentDate = p.PaymentDate,
                PaymentMethod = p.PaymentMethod,
                ReferenceNumber = p.ReferenceNumber,
                Status = p.PaymentStatus
            }).ToList()
        };
        _logger.LogInformation("Successfully fetched {PaymentCount} payment records for StudentID: {StudentID}",
            response.Payments.Count, studentId);
        return response;
    }

    public async Task<RecordPaymentResponse> RecordManualPaymentAsync(RecordPaymentRequest request)
    {
        _logger.LogInformation(
            "Attempting to record manual payment for StudentID: {StudentID}, Amount: {Amount}, RecordID: {RecordID}",
            request.StudentID, request.Amount, request.FinancialRecordID);

        // Validate student exists
        var student = await _studentRepository.GetStudentByStudentIDAsync(request.StudentID);
        if (student == null) throw new StudentNotFoundException(request.StudentID);

        // Use transaction
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            // Find the financial record
            var financialRecord = await _financeRepository.GetFinancialRecordByIdAsync(request.FinancialRecordID);
            if (financialRecord == null || financialRecord.StudentID != request.StudentID)
                // Consider creating a specific FinancialRecordNotFoundException
                throw new KeyNotFoundException(
                    $"Financial record with ID {request.FinancialRecordID} not found for student {request.StudentID}.");

            // Create Payment entity
            var payment = new Payment
            {
                PaymentID = Guid.NewGuid(),
                FinancialRecordID = request.FinancialRecordID,
                FinancialRecord = financialRecord, // Link the entity
                Amount = request.Amount,
                PaymentDate = request.PaymentDate,
                PaymentMethod = request.PaymentMethod,
                ReferenceNumber = request.ReferenceNumber,
                PaymentStatus = PaymentStatus.Completed, // Assuming manual recording means it's completed
                Notes = request.Notes
            };

            // Add payment to context
            await _financeRepository.AddPaymentAsync(payment);

            // Update FinancialRecord balance
            financialRecord.AmountPaid += request.Amount;
            financialRecord.OutstandingBalance = financialRecord.TotalFees - financialRecord.AmountPaid; // Recalculate
            financialRecord.LastUpdated = DateTimeOffset.UtcNow;
            await _financeRepository.UpdateFinancialRecordAsync(financialRecord);

            // Optionally: Update FeeItem statuses if payment covers specific items (more complex logic)

            // Save all changes within the transaction
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            _logger.LogInformation(
                "Successfully recorded manual payment PaymentID: {PaymentID} for StudentID: {StudentID}",
                payment.PaymentID, request.StudentID);

            return new RecordPaymentResponse
            {
                PaymentID = payment.PaymentID,
                FinancialRecordID = financialRecord.FinancialRecordID,
                UpdatedOutstandingBalance = financialRecord.OutstandingBalance,
                Message = "Payment recorded successfully."
            };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Failed to record manual payment for StudentID: {StudentID}", request.StudentID);
            throw; // Re-throw the exception to be handled by the endpoint
        }
    }

    /// <summary>
    /// Creates a placeholder Payment record when a gateway transaction is initiated.
    /// </summary>
    public async Task<Payment> CreatePendingPaymentAsync(string studentId, decimal amount, string currency,
        PaymentMethod method, string internalReference, string gatewayReference, Guid? financialRecordId)
    {
        // Find the most relevant FinancialRecord if not provided (e.g., latest with outstanding balance)
        if (!financialRecordId.HasValue)
        {
            financialRecordId = await _context.FinancialRecords
                .Where(fr => fr.StudentID == studentId && fr.OutstandingBalance > 0)
                .OrderByDescending(fr => fr.AcademicYear)
                .ThenByDescending(fr => fr.Semester)
                .Select(fr => fr.FinancialRecordID)
                .FirstOrDefaultAsync();

            if (financialRecordId == Guid.Empty) // Still couldn't find one
                financialRecordId = await _context.FinancialRecords
                    .Where(fr => fr.StudentID == studentId) // Find any record if none have balance
                    .OrderByDescending(fr => fr.AcademicYear)
                    .ThenByDescending(fr => fr.Semester)
                    .Select(fr => fr.FinancialRecordID)
                    .FirstOrDefaultAsync();
            if (financialRecordId == Guid.Empty)
                throw new InvalidOperationException(
                    $"Cannot create pending payment for student {studentId} as no suitable FinancialRecord was found.");
        }

        var payment = new Payment
        {
            PaymentID = Guid.NewGuid(),
            FinancialRecordID = financialRecordId.Value, // Must have a value here
            Amount = amount,
            PaymentDate = DateTimeOffset.UtcNow, // Initial timestamp
            PaymentMethod = method,
            ReferenceNumber = internalReference, // Use OUR internal reference here initially
            PaymentStatus = PaymentStatus.Pending,
            Notes = $"Initiated via {method}. Gateway Ref: {gatewayReference}"
        };

        await _financeRepository.AddPaymentAsync(payment);
        await _context.SaveChangesAsync(); // Save the pending payment immediately
        _logger.LogInformation("Created Pending Payment record PaymentID: {PaymentID}, InternalRef: {InternalRef}",
            payment.PaymentID, internalReference);
        return payment;
    }

    /// <summary>
    /// Updates a Payment record and associated FinancialRecord after successful gateway confirmation.
    /// </summary>
    public async Task MarkPaymentAsCompletedAsync(Guid paymentId, DateTimeOffset paidAt, string gatewayTransactionRef,
        string gatewayMessage)
    {
        _logger.LogInformation("Marking PaymentID: {PaymentID} as completed. GatewayRef: {GatewayRef}", paymentId,
            gatewayTransactionRef);
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var payment = await _financeRepository.GetPaymentByIdAsync(paymentId);
            if (payment == null)
            {
                _logger.LogError("Cannot complete payment: PaymentID {PaymentID} not found.", paymentId);
                throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");
            }

            if (payment.PaymentStatus == PaymentStatus.Completed)
            {
                _logger.LogWarning(
                    "PaymentID {PaymentID} is already marked as completed. Ignoring duplicate webhook/callback.",
                    paymentId);
                await transaction.RollbackAsync(); // No changes needed
                return;
            }

            payment.PaymentStatus = PaymentStatus.Completed;
            payment.PaymentDate = paidAt; // Update to actual payment time
            payment.ReferenceNumber = gatewayTransactionRef; // Update reference to gateway's final transaction ID
            payment.Notes = gatewayMessage;
            _context.Payments.Update(payment); // Mark payment as updated

            // Update associated FinancialRecord
            var financialRecord = payment.FinancialRecord; // Assumes included by GetPaymentByIdAsync
            if (financialRecord != null)
            {
                financialRecord.AmountPaid += payment.Amount;
                financialRecord.OutstandingBalance =
                    financialRecord.TotalFees - financialRecord.AmountPaid; // Recalculate
                financialRecord.LastUpdated = DateTimeOffset.UtcNow;
                _context.FinancialRecords.Update(financialRecord); // Mark record as updated
                _logger.LogInformation("Updated FinancialRecordID: {RecordID}, New Balance: {Balance}",
                    financialRecord.FinancialRecordID, financialRecord.OutstandingBalance);
            }
            else
            {
                _logger.LogWarning("FinancialRecord was null for PaymentID: {PaymentID}. Could not update balance.",
                    paymentId);
            }

            // Potentially update FeeItem statuses as well (more complex)

            await _context.SaveChangesAsync(); // Save changes within transaction
            await transaction.CommitAsync();
            _logger.LogInformation("Successfully marked PaymentID: {PaymentID} as completed.", paymentId);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Error marking payment PaymentID: {PaymentID} as completed.", paymentId);
            throw;
        }
    }

    // --- Reminder Logic Placeholder ---
    /// <summary>
    /// Finds pending reminders and sends them out. (Intended for a Background Job)
    /// </summary>
    public async Task SendPendingRemindersAsync()
    {
        _logger.LogInformation("Starting SendPendingReminders task.");
        var pendingReminders = await _financeRepository.GetDueRemindersAsync();

        if (!pendingReminders.Any())
        {
            _logger.LogInformation("No pending payment reminders found.");
            return;
        }

        _logger.LogInformation("Found {Count} pending reminders to process.", pendingReminders.Count);

        foreach (var reminder in pendingReminders)
            try
            {
                // Construct reminder message
                var messageContent =
                    $"Dear {reminder.Student.FirstName}, This is a reminder that a payment is due on {reminder.DueDate:yyyy-MM-dd}. Please make payment arrangements.";

                // Could customize based on reminder.FinancialRecordID or reminder.FeeItemID
                // Send reminder (e.g., via Email)
                var message = new Shared.Email.Message(new[] { reminder.Student.StudentEmail }, "Upcoming Payment Due",
                    messageContent);
                await _emailService.SendEmail(message);

                // Update reminder status
                reminder.Status = ReminderStatus.Sent;
                reminder.SentDate = DateTimeOffset.UtcNow;
                await _financeRepository.UpdatePaymentReminderStatusAsync(reminder); // Assumes method saves changes

                _logger.LogInformation("Sent reminder {ReminderID} to Student {StudentID} for DueDate {DueDate}",
                    reminder.ReminderID, reminder.StudentID, reminder.DueDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send reminder {ReminderID} for Student {StudentID}",
                    reminder.ReminderID, reminder.StudentID);
                reminder.Status = ReminderStatus.Error;
                await _financeRepository.UpdatePaymentReminderStatusAsync(reminder);
            }

        _logger.LogInformation("Finished SendPendingReminders task.");
    }
}