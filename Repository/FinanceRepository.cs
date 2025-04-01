using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;
using static iSchool_Solution.Features.Finance.Common.Models;

namespace iSchool_Solution.Repository;

public class FinanceRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FinanceRepository> _logger;

    public FinanceRepository(ApplicationDbContext context, ILogger<FinanceRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<FinancialRecord>> GetFinancialRecordsByStudentAsync(string studentId)
    {
        return await _context.FinancialRecords
            .Where(fr => fr.StudentID == studentId)
            .Include(fr => fr.FeeItems)
            .Include(fr => fr.Payments)
            .OrderByDescending(fr => fr.AcademicYear).ThenByDescending(fr => fr.Semester)
            .ToListAsync();
    }

    public async Task<List<Payment>> GetPaymentsByStudentAsync(string studentId)
    {
        return await _context.Payments
            .Include(p => p.FinancialRecord)
            .Where(p => p.FinancialRecord.StudentID == studentId)
            .OrderByDescending(p => p.PaymentDate)
            .ToListAsync();
    }

    public async Task<FinancialRecord?> GetFinancialRecordByIdAsync(Guid recordId)
    {
        return await _context.FinancialRecords
            .Include(fr => fr.FeeItems)
            .FirstOrDefaultAsync(fr => fr.FinancialRecordID == recordId);
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public async Task UpdateFinancialRecordAsync(FinancialRecord record)
    {
        _context.FinancialRecords.Update(record);
        await Task.CompletedTask; // SaveChanges is handled by the service transaction
    }

    public async Task UpdateFeeItemAsync(FeeItem item)
    {
        _context.FeeItems.Update(item);
        await Task.CompletedTask; // SaveChanges is handled by the service transaction
    }

    public async Task<Payment?> GetPaymentByIdAsync(Guid paymentId)
    {
        return await _context.Payments
            .Include(p => p.FinancialRecord)
            .FirstOrDefaultAsync(p => p.PaymentID == paymentId);
    }

    // --- Methods requiring new entities ---

    public async Task SavePaymentGatewayTransactionAsync(PaymentGatewayTransaction transaction)
    {
        await _context.PaymentGatewayTransactions.AddAsync(transaction);
        // SaveChanges should likely happen in the service after confirming payment status
    }

    public async Task<Invoice?> GetInvoiceByIdAsync(Guid invoiceId)
    {
        _logger.LogDebug("Fetching Invoice with ID: {InvoiceID} including Student and LineItems", invoiceId);
        return await _context.Invoices
            .Include(i => i.Student) // Include Student details
            .Include(i => i.LineItems) // Include Line Items details
            .FirstOrDefaultAsync(i => i.InvoiceID == invoiceId);
    }

    public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        return invoice;
    }

    public async Task<List<Invoice>> GetInvoicesByStudentIdAsync(string studentId)
    {
        return await _context.Invoices
            .Where(i => i.StudentID == studentId)
            .Include(i => i.LineItems) // Optionally include line items
            .OrderByDescending(i => i.CreatedDate)
            .ToListAsync();
    }

    public async Task<List<PaymentReminder>> GetDueRemindersAsync()
    {
        return await _context.PaymentReminders
            .Include(pr => pr.Student) // Include student for contact info
            .Where(pr => pr.ReminderDate <= DateTimeOffset.UtcNow && pr.Status == ReminderStatus.Pending)
            .ToListAsync();
    }

    public async Task CreatePaymentReminderAsync(PaymentReminder reminder)
    {
        await _context.PaymentReminders.AddAsync(reminder);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePaymentReminderStatusAsync(PaymentReminder reminder)
    {
        _context.PaymentReminders.Update(reminder);
        await _context.SaveChangesAsync();
    }

    // --- Reporting Methods ---

    public async Task<List<PaymentsByMethodReport>> GetPaymentsByMethodAsync(
        DateTimeOffset start, DateTimeOffset end)
    {
        return await _context.Payments
            .Where(p => p.PaymentDate >= start && p.PaymentDate <= end)
            .GroupBy(p => p.PaymentMethod)
            .Select(g => new PaymentsByMethodReport
            {
                PaymentMethod = g.Key,
                Count = g.Count(),
                TotalAmount = g.Sum(p => p.Amount)
            })
            .ToListAsync();
    }

    public async Task<List<OutstandingBalanceReport>> GetOutstandingBalancesAsync(
        decimal minimumAmount, string? departmentNameFilter = null)
    {
        var query = _context.FinancialRecords
            .Include(fr => fr.Student) // Need student for name
            .ThenInclude(s => s.Department) // Need department for filtering
            .Where(fr => fr.OutstandingBalance >= minimumAmount);

        if (!string.IsNullOrEmpty(departmentNameFilter))
            query = query.Where(fr => fr.Student.Department.DepartmentName == departmentNameFilter);

        return await query
            .Select(fr => new OutstandingBalanceReport
            {
                StudentID = fr.StudentID,
                StudentName = fr.Student.FirstName + " " + fr.Student.LastName,
                DepartmentName = fr.Student.Department.DepartmentName, // Added department name
                OutstandingBalance = fr.OutstandingBalance,
                LastPaymentDate = fr.Payments // Get the latest payment date
                    .OrderByDescending(p => p.PaymentDate)
                    .Select(p => (DateTimeOffset?)p.PaymentDate) // Select nullable for FirstOrDefault
                    .FirstOrDefault() // Use FirstOrDefault to handle cases with no payments
            })
            .OrderByDescending(r => r.OutstandingBalance)
            .ToListAsync();
    }

    // Needed by PaystackService to find payment after webhook using YOUR reference
    public async Task<Payment?> GetPaymentByReferenceAsync(string internalReference)
    {
        _logger.LogDebug("Fetching Payment by Internal Reference: {InternalReference}", internalReference);
        // Assuming the initial ReferenceNumber stored is your internal one
        return await _context.Payments
            .Include(p => p.FinancialRecord) // Include related record for balance updates
            .ThenInclude(fr => fr.Student) // May need student later
            .FirstOrDefaultAsync(
                p => p.ReferenceNumber == internalReference &&
                     p.PaymentStatus ==
                     PaymentStatus.Pending); // Look for pending payments matching the initial reference
    }

    // Potentially add GetFeeItemByIdAsync if needed for applying payments directly to items
    // public async Task<FeeItem?> GetFeeItemByIdAsync(int feeItemId) { ... }
}