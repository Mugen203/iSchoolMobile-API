using iSchool_Solution.Entities;
using iSchool_Solution.Enums;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedGrades
{
    // Declare public static Guids for GradeIDs - Descriptive names for each grade entry
    public static Guid Grade_COSC113_FirstSem2021_2022_Id;
    public static Guid Grade_COSC115_FirstSem2021_2022_Id;
    public static Guid Grade_ENGL111_FirstSem2021_2022_Id;
    public static Guid Grade_FREN121_FirstSem2021_2022_Id;
    public static Guid Grade_GNED125_FirstSem2021_2022_Id;
    public static Guid Grade_MATH171_FirstSem2021_2022_Id;
    public static Guid Grade_PEAC100_FirstSem2021_2022_Id;
    public static Guid Grade_PHYS103_FirstSem2021_2022_Id;
    public static Guid Grade_RELB163_FirstSem2021_2022_Id;

    public static Guid Grade_CMME115_SecondSem2021_2022_Id;
    public static Guid Grade_COSC116_SecondSem2021_2022_Id;
    public static Guid Grade_COSC124_SecondSem2021_2022_Id;
    public static Guid Grade_COSC130_SecondSem2021_2022_Id;
    public static Guid Grade_ENGL112_SecondSem2021_2022_Id;
    public static Guid Grade_GNED125_SecondSem2021_2022_Id;
    public static Guid Grade_MATH172_SecondSem2021_2022_Id;
    public static Guid Grade_PSYC105_SecondSem2021_2022_Id;

    public static Guid Grade_ACCT210_FirstSem2022_2023_Id;
    public static Guid Grade_AFST205_FirstSem2022_2023_Id;
    public static Guid Grade_COSC230_FirstSem2022_2023_Id;
    public static Guid Grade_COSC271_FirstSem2022_2023_Id;
    public static Guid Grade_COSC280_FirstSem2022_2023_Id;
    public static Guid Grade_CSCD210_FirstSem2022_2023_Id;
    public static Guid Grade_RELB250_FirstSem2022_2023_Id;

    public static Guid Grade_AFST243_SecondSem2022_2023_Id;
    public static Guid Grade_COSC214_SecondSem2022_2023_Id;
    public static Guid Grade_COSC224_SecondSem2022_2023_Id;
    public static Guid Grade_COSC272_SecondSem2022_2023_Id;
    public static Guid Grade_HLTH200_SecondSem2022_2023_Id;
    public static Guid Grade_MGNT255_SecondSem2022_2023_Id;
    public static Guid Grade_STAT282_SecondSem2022_2023_Id;

    public static Guid Grade_COSC255_FirstSem2023_2024_Id;
    public static Guid Grade_COSC257_FirstSem2023_2024_Id;
    public static Guid Grade_COSC260_FirstSem2023_2024_Id;
    public static Guid Grade_COSC331_FirstSem2023_2024_Id;
    public static Guid Grade_COSC360_FirstSem2023_2024_Id;
    public static Guid Grade_COSC361_FirstSem2023_2024_Id;
    public static Guid Grade_RELT385_FirstSem2023_2024_Id;

    public static Guid Grade_COSC240_SecondSem2023_2024_Id;
    public static Guid Grade_COSC250_SecondSem2023_2024_Id;
    public static Guid Grade_COSC325_SecondSem2023_2024_Id;
    public static Guid Grade_COSC357_SecondSem2023_2024_Id;
    public static Guid Grade_COSC364_SecondSem2023_2024_Id;
    public static Guid Grade_COSC370_SecondSem2023_2024_Id;
    public static Guid Grade_COSC425_SecondSem2023_2024_Id;


    public static void Seed(ModelBuilder builder)
    {
        // Assign Guid.NewGuid() to GradeIDs
        Grade_COSC113_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_COSC115_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_ENGL111_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_FREN121_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_GNED125_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_MATH171_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_PEAC100_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_PHYS103_FirstSem2021_2022_Id = Guid.NewGuid();
        Grade_RELB163_FirstSem2021_2022_Id = Guid.NewGuid();

        Grade_CMME115_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_COSC116_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_COSC124_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_COSC130_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_ENGL112_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_GNED125_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_MATH172_SecondSem2021_2022_Id = Guid.NewGuid();
        Grade_PSYC105_SecondSem2021_2022_Id = Guid.NewGuid();

        Grade_ACCT210_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_AFST205_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC230_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC271_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC280_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_CSCD210_FirstSem2022_2023_Id = Guid.NewGuid();
        Grade_RELB250_FirstSem2022_2023_Id = Guid.NewGuid();

        Grade_AFST243_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC214_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC224_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_COSC272_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_HLTH200_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_MGNT255_SecondSem2022_2023_Id = Guid.NewGuid();
        Grade_STAT282_SecondSem2022_2023_Id = Guid.NewGuid();

        Grade_COSC255_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC257_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC260_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC331_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC360_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC361_FirstSem2023_2024_Id = Guid.NewGuid();
        Grade_RELT385_FirstSem2023_2024_Id = Guid.NewGuid();

        Grade_COSC240_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC250_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC325_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC357_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC364_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC370_SecondSem2023_2024_Id = Guid.NewGuid();
        Grade_COSC425_SecondSem2023_2024_Id = Guid.NewGuid();


        builder.Entity<Grade>().HasData(
            // First Sem 2021/2022 Grades
            new Grade
            {
                GradeID = Grade_COSC113_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Cosc113CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC115_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Cosc115CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.B_Minus,
                GradePoints = 2.67,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_ENGL111_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Engl111CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.B_Minus,
                GradePoints = 2.67,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_FREN121_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Fren121CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.A,
                GradePoints = 4.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_GNED125_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Gned125CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_MATH171_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Math171CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.C,
                GradePoints = 2.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_PEAC100_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Peac100CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.P,
                GradePoints = 0.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_PHYS103_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Phys103CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.C_Plus,
                GradePoints = 2.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_RELB163_FirstSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2021_2022_Id,
                CourseID = SeedCourses.Relb163CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2021, 12, 15)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },

            // Second Sem 2021/2022 Grades
            new Grade
            {
                GradeID = Grade_CMME115_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Cmme115CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.C_Plus,
                GradePoints = 2.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC116_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Cosc116CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.B_Minus,
                GradePoints = 2.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC124_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Cosc124CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.C,
                GradePoints = 2.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC130_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Cosc130CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_ENGL112_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Engl112CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.D,
                GradePoints = 1.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_GNED125_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Gned125CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.F,
                GradePoints = 0.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_MATH172_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Math172CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.B_Minus,
                GradePoints = 2.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_PSYC105_SecondSem2021_2022_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2021_2022_Id,
                CourseID = SeedCourses.Psyc105CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 5, 30)),
                GradeLetter = GradeLetter.B,
                GradePoints = 3.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },

            // First Sem 2022/2023 Grades
            new Grade
            {
                GradeID = Grade_ACCT210_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Acct210CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.B,
                GradePoints = 3.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_AFST205_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Afst205CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.C,
                GradePoints = 2.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC230_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Cosc230CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.B,
                GradePoints = 3.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC271_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Cosc271CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC280_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Cosc280CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_CSCD210_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Cscd210CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.F,
                GradePoints = 0.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_RELB250_FirstSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2022_2023_Id,
                CourseID = SeedCourses.Relb250CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2022, 12, 15)),
                GradeLetter = GradeLetter.B,
                GradePoints = 3.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },

            // Second Sem 2022/2023 Grades
            new Grade
            {
                GradeID = Grade_AFST243_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Afst243CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC214_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Cosc214CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.B_Minus,
                GradePoints = 2.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC224_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Cosc224CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.A,
                GradePoints = 4.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC272_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Cosc272CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_HLTH200_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Hlth200CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.C,
                GradePoints = 2.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_MGNT255_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Mgnt255CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.A,
                GradePoints = 4.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_STAT282_SecondSem2022_2023_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2022_2023_Id,
                CourseID = SeedCourses.Stat282CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 5, 30)),
                GradeLetter = GradeLetter.C_Plus,
                GradePoints = 2.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },

            // First Sem 2023/2024 Grades
            new Grade
            {
                GradeID = Grade_COSC255_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc255CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.A,
                GradePoints = 4.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC257_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc257CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.B,
                GradePoints = 3.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC260_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc260CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC331_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc331CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.C,
                GradePoints = 2.00,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC360_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc360CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC361_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Cosc361CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.C_Plus,
                GradePoints = 2.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_RELT385_FirstSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_FirstSem2023_2024_Id,
                CourseID = SeedCourses.Relt385CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2023, 12, 15)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.September,
                Remarks = null
            },

            // Second Sem 2023/2024 Grades
            new Grade
            {
                GradeID = Grade_COSC240_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc240CourseId,

                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.A,
                GradePoints = 4.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC250_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc250CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            }, // Using Enum - Semester.Second becomes January
            new Grade
            {
                GradeID = Grade_COSC325_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc325CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.A_Minus,
                GradePoints = 3.67,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC357_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc357CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC364_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc364CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC370_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc370CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.D,
                GradePoints = 1.00,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            },
            new Grade
            {
                GradeID = Grade_COSC425_SecondSem2023_2024_Id,
                SemesterRecordID = SeedSemesterRecords.SemesterRecord_SecondSem2023_2024_Id,
                CourseID = SeedCourses.Cosc425CourseId,
                StudentID = "222CS01000694",
                DateAwarded = new DateTimeOffset(new DateTime(2024, 5, 30)),
                GradeLetter = GradeLetter.B_Plus,
                GradePoints = 3.33,
                isCompleted = true,
                Semester = Semester.January,
                Remarks = null
            }
        );
    }
}