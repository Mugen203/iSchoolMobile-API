using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Repository;

public class RegistrationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegistrationRepository> _logger;

    public RegistrationRepository(ApplicationDbContext context, ILogger<RegistrationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<RegistrationPeriod?> GetActiveRegistrationPeriodAsync()
    {
        var registrationPeriod = await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.IsActive);

        if (registrationPeriod == null)
        {
            _logger.LogWarning("No active registration period found");
        }

        return registrationPeriod;
    }

    public async Task<RegistrationPeriod?> GetRegistrationPeriodByIdAsync(Guid registrationPeriodId)
    {
        return await _context.RegistrationPeriods
            .FirstOrDefaultAsync(rp => rp.RegistrationPeriodID == registrationPeriodId);
    }

    public async Task<List<RegistrationPeriod>> GetRegistrationPeriodsForAcademicYearAsync(string academicYear)
    {
        return await _context.RegistrationPeriods
            .Where(rp => rp.AcademicYear == academicYear)
            .OrderBy(rp => rp.StartDate)
            .ToListAsync();
    }

    public async Task<List<RegistrationPeriod>> GetUpcomingRegistrationPeriodsAsync()
    {
        return await _context.RegistrationPeriods
            .Where(rp => rp.StartDate > DateTime.UtcNow)
            .OrderBy(rp => rp.StartDate)
            .ToListAsync();
    }
}