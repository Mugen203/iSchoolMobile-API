using iSchool_Solution.Data;
using iSchool_Solution.Entities;

namespace iSchool_Solution.Repository;

public class RegistrationRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // public async Task<RegistrationPeriod?> GetRegistrationPeriodAsync(string studentID)
    // { 
    // }
}