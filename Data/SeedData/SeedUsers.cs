using iSchool_Solution.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedUsers
{
    public static void Seed(ModelBuilder builder)
    {
        const string studentId = "222CS01000694";
        const string studentEmail = "kwakuaffram@gmail.com";

        var hasher = new PasswordHasher<ApiUser>();

        // Create the user instance first
        var user = new ApiUser
        {
            Id = studentId,
            UserName = studentId,
            NormalizedUserName = studentId.ToUpper(),
            Email = studentEmail,
            NormalizedEmail = studentEmail.ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            PhoneNumber = "0553138727",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            StudentID = studentId,
            StudentFirstName = "Kwaku",
            StudentLastName = "Affram"
        };

        // Hash the password
        user.PasswordHash = hasher.HashPassword(user, "P@ssw0rd1");

        // Seed the user
        builder.Entity<ApiUser>().HasData(user);

        // Seed the user role
        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = studentId,
            RoleId = "2"
        });
    }
}