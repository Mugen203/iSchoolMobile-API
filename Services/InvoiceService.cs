using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Repository;
using Microsoft.EntityFrameworkCore; 
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace iSchool_Solution.Services;

public class InvoiceService
{
    private readonly FinanceRepository _financeRepository;
    private readonly ApplicationDbContext _context; // For transaction control
    private readonly ILogger<InvoiceService> _logger;

    // Inject dependencies
    public InvoiceService(FinanceRepository financeRepository, ApplicationDbContext context, ILogger<InvoiceService> logger)
    {
        _financeRepository = financeRepository;
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Generates a unique invoice number.
    /// </summary>
    /// <returns>A formatted invoice number string.</returns>
    public async Task<string> GenerateInvoiceNumberAsync()
    {
        // Strategy: Fetch the highest existing number for the current year and increment.
        var currentYear = DateTime.UtcNow.Year;
        var prefix = $"INV-{currentYear}-";

        // This requires a method in FinanceRepository to get the latest invoice number for the year
        // Alternatively, query directly here if repo doesn't have it.
        var lastInvoice = await _context.Invoices
                                .Where(i => i.InvoiceNumber.StartsWith(prefix))
                                .OrderByDescending(i => i.InvoiceNumber)
                                .Select(i => i.InvoiceNumber)
                                .FirstOrDefaultAsync();

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastInvoice))
        {
            // Extract the number part and increment
            if (int.TryParse(lastInvoice.Substring(prefix.Length), out var lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
            // Handle potential parsing errors if needed
        }

        // Format with leading zeros (e.g., INV-2025-00001)
        return $"{prefix}{nextNumber:D5}";
    }

    /// <summary>
    /// Creates an Invoice entity based on a FinancialRecord.
    /// </summary>
    /// <param name="financialRecordId">The ID of the FinancialRecord to invoice.</param>
    /// <returns>The created Invoice entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the FinancialRecord is not found.</exception>
    public async Task<Invoice> CreateInvoiceFromFinancialRecordAsync(Guid financialRecordId)
    {
        _logger.LogInformation("Creating invoice from FinancialRecordID: {FinancialRecordID}", financialRecordId);

        var record = await _financeRepository.GetFinancialRecordByIdAsync(financialRecordId);
        if (record == null)
        {
            _logger.LogWarning("FinancialRecord not found: {FinancialRecordID}", financialRecordId);
            throw new KeyNotFoundException($"FinancialRecord with ID {financialRecordId} not found.");
        }
        // Ensure student data is loaded if needed for the invoice details (depends on repo implementation)
        if (record.Student == null)
        {
             record.Student = await _context.Students.FindAsync(record.StudentID);
             if (record.Student == null) throw new StudentNotFoundException(record.StudentID);
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var invoiceNumber = await GenerateInvoiceNumberAsync();
            var now = DateTimeOffset.UtcNow;
            // Define due date based on business rules (e.g., 30 days from creation)
            var dueDate = now.AddDays(30);

            var invoice = new Invoice
            {
                InvoiceID = Guid.NewGuid(),
                InvoiceNumber = invoiceNumber,
                StudentID = record.StudentID,
                Student = record.Student, // Assign loaded student
                FinancialRecordID = record.FinancialRecordID,
                CreatedDate = now,
                DueDate = dueDate,
                // Status = InvoiceStatus.Draft, // Set initial status if using enum
                Notes = $"Invoice for {record.Semester} {record.AcademicYear}",
                Subtotal = 0m, // Will be calculated from line items
                DiscountAmount = 0m, // Add logic if discounts apply
                TotalAmount = 0m // Will be calculated
            };

            // Create line items from fee items in the financial record
            foreach (var feeItem in record.FeeItems)
            {
                var lineItem = new InvoiceLineItem
                {
                    InvoiceID = invoice.InvoiceID,
                    FeeItemID = feeItem.Id, // Link to original FeeItem if needed
                    Description = feeItem.Description,
                    Quantity = 1,
                    UnitPrice = feeItem.Amount,
                    LineTotal = feeItem.Amount // Assuming quantity is always 1
                };
                invoice.LineItems.Add(lineItem);
                invoice.Subtotal += lineItem.LineTotal;
            }

            invoice.TotalAmount = invoice.Subtotal - invoice.DiscountAmount;

            // Use the repository to add the invoice (which should handle adding line items due to relationship)
            var createdInvoice = await _financeRepository.CreateInvoiceAsync(invoice); // Assumes CreateInvoiceAsync exists in repo

            await transaction.CommitAsync();
            _logger.LogInformation("Successfully created InvoiceID: {InvoiceID}, Number: {InvoiceNumber}", createdInvoice.InvoiceID, createdInvoice.InvoiceNumber);
            return createdInvoice;
        }
        catch(Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError(ex, "Failed to create invoice for FinancialRecordID: {FinancialRecordID}", financialRecordId);
            throw;
        }
    }

    /// <summary>
    /// Generates a PDF byte array for a given invoice ID.
    /// </summary>
    /// <param name="invoiceId">The ID of the invoice.</param>
    /// <returns>Byte array representing the PDF file.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the Invoice is not found.</exception>
    public async Task<byte[]> GenerateInvoicePdfAsync(Guid invoiceId)
    {
        _logger.LogInformation("Generating PDF for InvoiceID: {InvoiceID}", invoiceId);

        // Fetch the invoice with necessary related data (Student, LineItems)
        // Requires GetInvoiceByIdAsync(Guid invoiceId) in FinanceRepository
         var invoice = await _context.Invoices // Or use _financeRepository.GetInvoiceByIdAsync(invoiceId);
             .Include(i => i.Student)
             .Include(i => i.LineItems)
             .FirstOrDefaultAsync(i => i.InvoiceID == invoiceId);

        if (invoice == null)
        {
            _logger.LogWarning("Invoice not found for PDF generation: {InvoiceID}", invoiceId);
            throw new KeyNotFoundException($"Invoice with ID {invoiceId} not found.");
        }

        // --- Placeholder for PDF Generation Logic ---
        _logger.LogDebug("Populating PDF template for Invoice: {InvoiceNumber}", invoice.InvoiceNumber);
        // Example using QuestPDF 
        try
        {
            // Define your document structure using QuestPDF's fluent API
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.Header()
                        .Text($"Invoice #: {invoice.InvoiceNumber}")
                        .SemiBold().FontSize(16);

                    page.Content()
                        .Column(col =>
                        {
                            col.Spacing(10);
                            col.Item().Text($"Student: {invoice.Student.FirstName} {invoice.Student.LastName} ({invoice.StudentID})");
                            col.Item().Text($"Date Issued: {invoice.CreatedDate:yyyy-MM-dd}");
                            col.Item().Text($"Due Date: {invoice.DueDate:yyyy-MM-dd}");
                            col.Item().Text("Line Items:");
                            // Add table for line items...
                            foreach(var item in invoice.LineItems)
                            {
                                col.Item().Text($"- {item.Description}: {item.LineTotal:C}"); // Format as currency
                            }
                            col.Item().Text($"Total: {invoice.TotalAmount:C}").Bold();
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            // Generate the PDF bytes
            byte[] pdfBytes = document.GeneratePdf();
             _logger.LogInformation("PDF generated successfully for InvoiceID: {InvoiceID}", invoiceId);
            return pdfBytes;
        }
        catch(Exception ex)
        {
             _logger.LogError(ex, "Failed to generate PDF for InvoiceID: {InvoiceID}", invoiceId);
             throw new ApplicationException("Failed to generate invoice PDF.", ex);
        }

        // --- End Placeholder ---

        // Return dummy data until PDF library is implemented
        //await Task.Delay(50); // Simulate generation time
        //_logger.LogWarning("PDF generation for InvoiceID: {InvoiceID} is not implemented. Returning placeholder data.", invoiceId);
        //return System.Text.Encoding.UTF8.GetBytes($"Placeholder PDF for Invoice {invoice.InvoiceNumber}");
        
    }

    /// <summary>
    /// Generates a PDF receipt for a given completed payment ID.
    /// </summary>
    /// <param name="paymentId">The ID of the completed Payment.</param>
    /// <returns>Byte array representing the PDF file.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the Payment is not found.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the Payment is not completed.</exception>
    public async Task<byte[]> GenerateReceiptPdfAsync(Guid paymentId)
    {
        _logger.LogInformation("Generating receipt PDF for PaymentID: {PaymentID}", paymentId);

        // Fetch payment with related student data
        var payment =
            await _financeRepository
                .GetPaymentByIdAsync(paymentId); // Assumes this includes Student via FinancialRecord

        if (payment == null)
        {
            _logger.LogWarning("Payment not found for receipt generation: {PaymentID}", paymentId);
            throw new KeyNotFoundException($"Payment with ID {paymentId} not found.");
        }

        if (payment.PaymentStatus != PaymentStatus.Completed)
        {
            _logger.LogWarning("Receipt requested for non-completed payment: {PaymentID}, Status: {Status}", paymentId,
                payment.PaymentStatus);
            throw new InvalidOperationException("Receipts can only be generated for completed payments.");
        }

        var student = payment.FinancialRecord?.Student; // Access student via navigation property
        if (student == null)
        {
            // This case should ideally not happen if data integrity is maintained
            _logger.LogError("Student information missing for PaymentID: {PaymentID} during receipt generation.",
                paymentId);
            throw new InvalidOperationException("Cannot generate receipt without student information.");
        }


        // --- Placeholder for QuestPDF Receipt Generation Logic ---
        _logger.LogDebug("Populating PDF receipt template for Payment: {PaymentID}", paymentId);

        try
        {
            // Define your document structure using QuestPDF's fluent API
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A5); // Smaller size for receipt
                    page.Margin(1, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10)); // Default font size

                    page.Header()
                        .AlignCenter()
                        .Text("Payment Receipt")
                        .SemiBold().FontSize(16);

                    page.Content()
                        .Column(col =>
                        {
                            col.Spacing(5);
                            col.Item().Text($"Receipt #: {payment.PaymentID}"); // Use PaymentID or a dedicated Receipt#
                            col.Item().Text($"Date Paid: {payment.PaymentDate:yyyy-MM-dd HH:mm}");
                            col.Item().Text($"Student: {student.FirstName} {student.LastName} ({student.StudentID})");
                            col.Item().Text($"Payment Method: {payment.PaymentMethod}");
                            if (!string.IsNullOrWhiteSpace(payment.ReferenceNumber))
                            {
                                col.Item().Text($"Reference: {payment.ReferenceNumber}");
                            }

                            col.Item().LineHorizontal(1);
                            col.Item().AlignRight()
                                .Text($"Amount Paid: {payment.Amount:C2} GHS")
                                .Bold().FontSize(12); // Format as currency
                            col.Item().LineHorizontal(1);
                            col.Item().Text("Thank you for your payment.").FontSize(8).Italic();

                            // Optionally add details about which fees this payment covered (more complex)
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Issued: {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC")
                        .FontSize(8);
                });
            });

            // Generate the PDF bytes
            byte[] pdfBytes = document.GeneratePdf();
            _logger.LogInformation("Receipt PDF generated successfully for PaymentID: {PaymentID}", paymentId);
            return pdfBytes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate receipt PDF for PaymentID: {PaymentID}", paymentId);
            throw new ApplicationException("Failed to generate payment receipt PDF.", ex);
        }
    }
}