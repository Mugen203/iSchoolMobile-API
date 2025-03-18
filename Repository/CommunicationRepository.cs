using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Repository;

public class CommunicationRepository
{
    private readonly ApplicationDbContext _context;

    public CommunicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // --- Common Methods for both Announcements and Notifications ---

    // Get latest communications (can return a mixed list)
    public async Task<List<object>> GetLatestCommunicationsAsync(int count)
    {
        var announcements = await _context.Announcements
            .OrderByDescending(a => a.PublishDate)
            .Take(count)
            .ToListAsync<object>(); // Cast to object for combined list

        var notifications = await _context.Notifications
            .OrderByDescending(n => n.CreatedDate)
            .Take(count)
            .ToListAsync<object>(); // Cast to object for combined list

        var combined = announcements.Concat(notifications)
            .OrderByDescending(c =>
                c is Announcement ann ? ann.PublishDate :
                c is Notification notif ? notif.CreatedDate : DateTime.MinValue) // Sort mixed list
            .Take(count)
            .ToList();
        return combined;
    }

    // Search by title (might need to adjust based on exact search needs)
    public async Task<List<object>> SearchCommunicationsByTitleAsync(string title, int maxResults = 10)
    {
        var announcements = await _context.Announcements
            .Where(a => a.Title.Contains(title))
            .Take(maxResults)
            .ToListAsync<object>();

        var notifications = await _context.Notifications
            .Where(n => n.Title.Contains(title))
            .Take(maxResults)
            .ToListAsync<object>();

        return announcements.Concat(notifications).ToList(); // Combine results
    }


    // --- Notification-Specific Methods (Keep Notification specific logic here) ---
    public async Task<List<Notification>> GetNotificationsForStudentAsync(string studentID)
    {
        return await _context.Notifications
            .Where(n => n.StudentID == studentID)
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync();
    }

    public async Task<Notification?> GetNotificationByIdAsync(int id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task UpdateNotificationAsync(Notification notification)
    {
        _context.Entry(notification).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }


    // --- Announcement-Specific Methods ---
    public async Task<List<Announcement>> GetAllAnnouncementsAsync()
    {
        return await _context.Announcements
            .OrderByDescending(a => a.PublishDate)
            .ToListAsync();
    }

    public async Task<Announcement?> GetAnnouncementByIdAsync(int id)
    {
        return await _context.Announcements.FindAsync(id);
    }
}