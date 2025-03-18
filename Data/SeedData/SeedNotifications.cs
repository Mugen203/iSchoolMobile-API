using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedNotifications
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<Notification>().HasData(
            new Notification
            {
                Id = 1,
                StudentID = "222CS01000694",
                Title = "Welcome",
                Message = "Welcome to the new semester!",
                NotificationType = NotificationType.General,
                CreatedDate = new DateTime(2024, 8, 1),
                IsRead = false,
                RedirectUrl = "",
                Priority = Priority.Medium
            }
        );
    }
}