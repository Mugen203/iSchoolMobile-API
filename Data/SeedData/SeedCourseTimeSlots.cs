using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedCourseTimeSlots
{
    // Define fixed GUIDs for CourseTimeSlots
    public static readonly Guid TimeSlot1ID = Guid.Parse("c4511bca-0142-4b03-b8a2-00f4e8d1aa8c");
    public static readonly Guid TimeSlot2ID = Guid.Parse("cb1f8dad-4cb3-42c8-90e4-2cb66625f972");
    public static readonly Guid TimeSlot3ID = Guid.Parse("7378abfb-d932-428b-ab84-87a32d6de75e");
    public static readonly Guid TimeSlot4ID = Guid.Parse("f03d7e47-92dc-4b1b-a8fd-f68c526e802a");
    public static readonly Guid TimeSlot5ID = Guid.Parse("bab91284-ec26-439e-9852-dbd76bd594e4");
    public static readonly Guid TimeSlot6ID = Guid.Parse("d2d43c71-e423-4d42-b605-dcd177065b9a");
    public static readonly Guid TimeSlot7ID = Guid.Parse("61622c25-0434-4fc0-a776-ca57195a0a2e");
    public static readonly Guid TimeSlot8ID = Guid.Parse("12acd859-70a5-4a36-af06-afe44e9fe216");

    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<CourseTimeSlot>().HasData(
            // Time slots for COSC466 - Systems and Network Administration (Elective 3)
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot1ID,
                CourseID = SeedCourses.Cosc466CourseId,
                DayOfWeek = DayOfWeek.Monday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(16, 30, 0), // 4:30 PM
                Location = ClassLocation.AmericanHigh,
                LecturerID = SeedLecturers.LecturerL001Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot2ID,
                CourseID = SeedCourses.Cosc466CourseId,
                DayOfWeek = DayOfWeek.Wednesday,
                StartTime = new TimeSpan(14, 0, 0), // Changed to 2:00 PM to resolve conflict
                EndTime = new TimeSpan(16, 30, 0), // 4:30 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },

            // Time slots for COSC370 - Operations Research
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot3ID,
                CourseID = SeedCourses.Cosc370CourseId,
                DayOfWeek = DayOfWeek.Thursday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(15, 50, 0), // 3:50 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot4ID,
                CourseID = SeedCourses.Cosc370CourseId,
                DayOfWeek = DayOfWeek.Tuesday,
                StartTime = new TimeSpan(14, 0, 0), // 2:00 PM
                EndTime = new TimeSpan(16, 30, 0), // 4:30 PM
                Location = ClassLocation.GeneralLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },

            // Time slots for COSC445 - Entrepreneurship and Human Development
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot5ID,
                CourseID = SeedCourses.Cosc445CourseId,
                DayOfWeek = DayOfWeek.Wednesday,
                StartTime = new TimeSpan(10, 0, 0), // 10:00 AM
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.MainLab, // Changed location to avoid conflict with COSC466
                LecturerID = SeedLecturers.LecturerL002Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot6ID,
                CourseID = SeedCourses.Cosc445CourseId,
                DayOfWeek = DayOfWeek.Monday,  // Changed from Friday to Monday to resolve conflict
                StartTime = new TimeSpan(10, 0, 0), // Changed to 10:00 AM
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.MainLab,
                LecturerID = SeedLecturers.LecturerL001Id
            },

            // Time slots for COSC440 - Computer Vision (Elective 2)
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot7ID,
                CourseID = SeedCourses.Cosc440CourseId,
                DayOfWeek = DayOfWeek.Friday,
                StartTime = new TimeSpan(7, 0, 0), // 7:00 AM
                EndTime = new TimeSpan(9, 30, 0), // 9:30 AM
                Location = ClassLocation.Cs3,
                LecturerID = SeedLecturers.LecturerL002Id
            },
            new CourseTimeSlot
            {
                CourseTimeSlotID = TimeSlot8ID,
                CourseID = SeedCourses.Cosc440CourseId,
                DayOfWeek = DayOfWeek.Friday,
                StartTime = new TimeSpan(10, 0, 0), // 10:00 AM
                EndTime = new TimeSpan(12, 30, 0), // 12:30 PM
                Location = ClassLocation.MainLab,
                LecturerID = SeedLecturers.LecturerL002Id
            }
        );
    }
}