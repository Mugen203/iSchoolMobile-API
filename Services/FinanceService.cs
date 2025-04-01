using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using static iSchool_Solution.Features.Finance.DownloadStatement.Models;
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

    /// <summary>
    /// Generates a Statement of Account PDF for a specific financial record.
    /// </summary>
    /// <param name="financialRecordId">The ID of the financial record (semester).</param>
    /// <returns>Tuple containing PDF bytes, content type, and filename.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the record or student not found.</exception>
    /// <exception cref="ApplicationException"></exception>
    public async Task<(byte[] FileContents, string ContentType, string FileName)> GenerateStatementPdfAsync(
        Guid financialRecordId)
    {
        _logger.LogInformation("Generating Statement of Account PDF for FinancialRecordID: {RecordID}",
            financialRecordId);

        // Fetch the record including Student, FeeItems, and Payments
        var record = await _context.FinancialRecords // Using _context directly for includes
            .Include(fr => fr.Student)
            .Include(fr => fr.FeeItems)
            .Include(fr => fr.Payments)
            .FirstOrDefaultAsync(fr => fr.FinancialRecordID == financialRecordId);

        if (record == null)
        {
            _logger.LogWarning("FinancialRecord not found for PDF generation: {RecordID}", financialRecordId);
            throw new KeyNotFoundException($"Financial Record with ID {financialRecordId} not found.");
        }

        if (record.Student == null)
        {
            _logger.LogError("Student data missing for FinancialRecordID: {RecordID}", financialRecordId);
            throw new ApplicationException("Cannot generate statement PDF without student data.");
        }

        // Prepare data for PDF
        var statementData = new StatementPdfData
        {
            FinancialRecordID = record.FinancialRecordID,
            StudentName = $"{record.Student.FirstName} {record.Student.LastName}",
            StudentID = record.StudentID,
            Semester = record.Semester.ToString(),
            AcademicYear = record.AcademicYear,
            TotalFeesForSemester = record.TotalFees,
            AmountPaidForSemester = record.AmountPaid,
            OutstandingBalanceForSemester = record.TotalFees - record.AmountPaid, // Recalculate for safety
            LastUpdated = record.LastUpdated,
            GeneratedDate = DateTime.UtcNow,
            FeeItems = record.FeeItems.Select(fi => new FeeItemSummary // Reuse existing DTO
            {
                Id = fi.Id, Description = fi.Description, Amount = fi.Amount,
                Category = fi.FeeItemCategory, PaymentStatus = fi.PaymentStatus,
                DueDate = fi.DueDate, IsRequired = fi.isRequired
            }).OrderBy(fi => fi.Description).ToList(),
            Payments = record.Payments.Select(p => new PaymentSummary // Reuse existing DTO
            {
                PaymentID = p.PaymentID, Amount = p.Amount, PaymentDate = p.PaymentDate,
                PaymentMethod = p.PaymentMethod, ReferenceNumber = p.ReferenceNumber, Status = p.PaymentStatus
            }).OrderBy(p => p.PaymentDate).ToList()
        };

        _logger.LogDebug("Data prepared for statement PDF. Student: {StudentID}, RecordID: {RecordID}",
            statementData.StudentID, statementData.FinancialRecordID);

        try
        {
            // Define QuestPDF Document
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Header
                    page.Header()
                        .AlignCenter()
                        .Column(col =>
                        {
                            col.Item().Text("Valley View University").Bold().FontSize(14);
                            col.Item().Text("Statement of Account").SemiBold().FontSize(12);
                            col.Spacing(5);
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(0.5f, Unit.Centimetre)
                        .Column(col =>
                        {
                            col.Spacing(10);
                            // Student Info
                            col.Item().Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text($"Student Name: {statementData.StudentName}").SemiBold();
                                    c.Item().Text($"Student ID: {statementData.StudentID}");
                                });
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text($"Period: {statementData.Semester} {statementData.AcademicYear}")
                                        .SemiBold();
                                    c.Item().Text($"Statement Date: {statementData.GeneratedDate:yyyy-MM-dd}");
                                });
                            });

                            col.Item().LineHorizontal(0.5f);

                            // Fees Section
                            col.Item().Text("Fees Charged").Bold();
                            col.Item().Table(feeTable =>
                            {
                                feeTable.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(); // Description
                                    columns.ConstantColumn(100); // Amount
                                });
                                feeTable.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Description");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).AlignRight()
                                        .Text("Amount (GHS)");
                                });
                                foreach (var item in statementData.FeeItems)
                                {
                                    feeTable.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .Text(item.Description);
                                    feeTable.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .AlignRight().Text($"{item.Amount:N2}");
                                }

                                feeTable.Cell().Padding(3).AlignRight().Text("Total Fees:").SemiBold();
                                feeTable.Cell().Padding(3).AlignRight().Text($"{statementData.TotalFeesForSemester:N2}")
                                    .SemiBold();
                            });

                            col.Item().PaddingTop(10); // Add space

                            // Payments Section
                            col.Item().Text("Payments Received").Bold();
                            col.Item().Table(paymentTable =>
                            {
                                paymentTable.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(80); // Date
                                    columns.RelativeColumn(); // Method/Reference
                                    columns.ConstantColumn(100); // Amount
                                });
                                paymentTable.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).Text("Date");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3)
                                        .Text("Method / Reference");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(3).AlignRight()
                                        .Text("Amount (GHS)");
                                });
                                foreach (var p in statementData.Payments)
                                {
                                    paymentTable.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .Text($"{p.PaymentDate:yyyy-MM-dd}");
                                    paymentTable.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .Text($"{p.PaymentMethod} / {p.ReferenceNumber}");
                                    paymentTable.Cell().BorderBottom(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(3)
                                        .AlignRight().Text($"{p.Amount:N2}");
                                }

                                paymentTable.Cell().ColumnSpan(2).Padding(3).AlignRight().Text("Total Payments:")
                                    .SemiBold();
                                paymentTable.Cell().Padding(3).AlignRight()
                                    .Text($"{statementData.AmountPaidForSemester:N2}").SemiBold();
                            });

                            col.Item().PaddingTop(10); // Add space

                            // Summary
                            col.Item().LineHorizontal(1f);
                            col.Item().PaddingVertical(2).AlignRight()
                                .Text($"Outstanding Balance: {statementData.OutstandingBalanceForSemester:N2} GHS")
                                .Bold().FontSize(12);
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                            x.Span(" of ");
                            x.TotalPages();
                        });
                });
            });

            // Generate PDF bytes
            byte[] pdfBytes = document.GeneratePdf();
            var fileName =
                $"Statement_{statementData.StudentID}_{statementData.AcademicYear}_{statementData.Semester}.pdf";
            var contentType = "application/pdf";

            _logger.LogInformation(
                "Statement PDF generated successfully for RecordID: {RecordID}. Size: {FileSize} bytes",
                financialRecordId, pdfBytes.Length);

            return (pdfBytes, contentType, fileName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate statement PDF for RecordID: {RecordID}", financialRecordId);
            throw new ApplicationException("Failed to generate statement PDF.", ex);
        }
    }
}