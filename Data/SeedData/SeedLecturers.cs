using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedLecturers
{
    // Declare public static readonly Guids for LecturerIDs
    public static string LecturerL001Id = "L0001";
    public static string LecturerL002Id = "L0002";


    public static void Seed(ModelBuilder builder) // Removed departmentOfComputerScienceId parameter
    {
        builder.Entity<Lecturer>().HasData(
            new Lecturer
            {
                LecturerID = LecturerL001Id, // Use static LecturerID
                LecturerFirstName = "Michael",
                LecturerLastName = "Asare",
                LecturerEmail = "masare@example.com",
                Office = "Room 101",
                Gender = Gender.Male,
                DepartmentID = SeedDepartments.DepartmentOfComputerScienceId, // Use static DepartmentID
                Credentials = "Masters"
            },
            new Lecturer
            {
                LecturerID = LecturerL002Id, // Use static LecturerID
                LecturerFirstName = "Papa",
                LecturerLastName = "Prince",
                LecturerEmail = "papa@example.com",
                Office = "Room 102",
                Gender = Gender.Male,
                DepartmentID = SeedDepartments.DepartmentOfComputerScienceId, // Use static DepartmentID
                Credentials = "PhD"
            }
        );
    }
}