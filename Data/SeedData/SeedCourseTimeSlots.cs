using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedCourseTimeSlots
{
    public static void Seed(ModelBuilder builder) // Removed courseID parameter
    {
        builder.Entity<CourseTimeSlot>().HasData(
            // Time slots for COSC466 - Systems and Network Administration (Elective 3)
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc466CourseId, // Link to COSC466
                DayOfWeek = DayOfWeek.Monday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(16, 30, 0), // 4:30 PM (Example: 2 hour slot)
                Location = ClassLocation.AmericanHigh,
                LecturerID = SeedLecturers.LecturerL001Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc466CourseId, // Link to COSC466
                DayOfWeek = DayOfWeek.Wednesday,
                StartTime = new TimeSpan(10, 0, 0), // 10:00 AM
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },

            // Time slots for COSC440 - Computer Vision (Elective 2)
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc440CourseId, // Link to COSC440
                DayOfWeek = DayOfWeek.Friday,
                StartTime = new TimeSpan(7, 0, 0), // 7:00 AM
                EndTime = new TimeSpan(9, 30, 0), // 9:30 AM (Example: 2 hour slot)
                Location = ClassLocation.Cs3,
                LecturerID = SeedLecturers.LecturerL002Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc440CourseId, // Link to COSC440
                DayOfWeek = DayOfWeek.Friday,
                StartTime = new TimeSpan(10, 0, 0), // 10:00 AM (Second slot on Friday)
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.MainLab,
                LecturerID = SeedLecturers.LecturerL002Id
            },

            // Time slots for COSC370 - Operations Research
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc370CourseId, // Link to COSC370
                DayOfWeek = DayOfWeek.Tuesday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(16, 30, 0), // 4:30 PM (Example: 2 hour slot)
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc370CourseId, // Link to COSC370
                DayOfWeek = DayOfWeek.Thursday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(15, 50, 0), // 3:50 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },

            // Time slots for COSC445 - Entrepreneurship and Human Development
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc445CourseId, // Link to COSC445
                DayOfWeek = DayOfWeek.Wednesday,
                StartTime = new TimeSpan(10, 0, 0), // 10:00 AM (Second slot on Friday)
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL002Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = Guid.NewGuid(),
                CourseID = SeedCourses.Cosc445CourseId, // Link to COSC445
                DayOfWeek = DayOfWeek.Friday,
                StartTime = new TimeSpan(07, 0, 0), // 7:00 AM
                EndTime = new TimeSpan(09, 30, 0), // 9:30 AM
                Location = ClassLocation.MainLab,
                LecturerID = SeedLecturers.LecturerL001Id
            }
        );
    }
}