using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedStudents
{
    public static void Seed(ModelBuilder builder, Guid departmentID)
    {
        builder.Entity<Student>().HasData(
            new Student
            {
                StudentID = "222CS01000694",
                FirstName = "Kwaku",
                LastName = "Affram",
                StudentEmail = "kwakuaffram@gmail.com",
                Address = "Kings and Queens Residence",
                AcademicAdvisor = "Mr. Michael Asare",
                StudentPhotoUrl =
                    "https://unsplash.com/photos/a-man-in-a-yellow-shirt-smiling-at-the-camera-ZjDbRtR_BcE",
                DateOfBirth = new DateTimeOffset(new DateTime(2000, 1, 1)),
                Gender = Gender.Male,
                StudentPhone = "0553138727",
                Degree = "BSc Computer Science",
                DepartmentID = departmentID,
                EmergencyContactName = "Kojo Ansah Affram",
                EmergencyContactPhone = "0501122334"
            },
            new Student
            {
                StudentID = "222CS01000695",
                FirstName = "Patricia",
                LastName = "Affram",
                StudentEmail = "adubea@example.com",
                Address = "Kings and Queens Residence",
                AcademicAdvisor = "Papa Prince",
                StudentPhotoUrl =
                    "https://unsplash.com/photos/man-in-yellow-blazer-and-blue-denim-jeans-smiling-PK_t0Lrh7MM",
                DateOfBirth = new DateTimeOffset(new DateTime(2001, 1, 1)),
                Gender = Gender.Female,
                StudentPhone = "0553138727",
                Degree = "BSc Computer Science",
                DepartmentID = departmentID,
                EmergencyContactName = "Kwaku Ampem Affram",
                EmergencyContactPhone = "0506590716"
            }
        );
    }
}