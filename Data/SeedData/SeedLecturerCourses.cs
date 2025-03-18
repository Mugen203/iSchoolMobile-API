using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedLecturerCourses
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<LecturerCourse>().HasData(
            // Lecturer Courses for COSC466 - Systems and Network Administration
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL001Id, // "L0001" instead of "L001"
                CourseID = SeedCourses.Cosc466CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL002Id, // "L0002" instead of "L002" 
                CourseID = SeedCourses.Cosc466CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },

            // Lecturer Courses for COSC440 - Computer Vision
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL002Id,
                CourseID = SeedCourses.Cosc440CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL001Id,
                CourseID = SeedCourses.Cosc440CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },

            // Lecturer Courses for COSC370 - Operations Research
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL001Id,
                CourseID = SeedCourses.Cosc370CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL002Id,
                CourseID = SeedCourses.Cosc370CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },

            // Lecturer Courses for COSC445 - Entrepreneurship and Human Development
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL002Id,
                CourseID = SeedCourses.Cosc445CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            },
            new LecturerCourse
            {
                LecturerID = SeedLecturers.LecturerL001Id,
                CourseID = SeedCourses.Cosc445CourseId,
                AcademicYear = "2024-2025",
                Semester = Enums.Semester.September
            }
        );
    }
}