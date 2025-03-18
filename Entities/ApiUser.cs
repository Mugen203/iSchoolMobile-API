using Microsoft.AspNetCore.Identity;

namespace iSchool_Solution.Entities;

public class ApiUser : IdentityUser
{
    public ApiUser()
    {
        Notifications = new HashSet<Notification>();
    }

    public string StudentID { get; init; }

    public string StudentFirstName { get; init; }

    public string StudentLastName { get; init; }
    
    public DateTimeOffset RefreshTokenExpiry { get; set; }
    
    // Navigation Collection Properties
    public virtual ICollection<Notification> Notifications { get; set; }
}