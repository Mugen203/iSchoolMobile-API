using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedFaculties
{
    // Declare public static readonly Guids for all Faculty IDs
    public static Guid FacultyOfScienceId;
    public static Guid FacultyOfArtsAndSocialSciencesId;
    public static Guid SchoolOfNursingAndMidwiferyId;
    public static Guid SchoolOfEducationId;
    public static Guid SchoolOfBusinessId;
    public static Guid SchoolOfGraduateStudiesId;

    public static void Seed(ModelBuilder builder)
    {
        // Assign Guid.NewGuid() to each Faculty ID
        FacultyOfScienceId = Guid.NewGuid();
        FacultyOfArtsAndSocialSciencesId = Guid.NewGuid();
        SchoolOfNursingAndMidwiferyId = Guid.NewGuid();
        SchoolOfEducationId = Guid.NewGuid();
        SchoolOfBusinessId = Guid.NewGuid();
        SchoolOfGraduateStudiesId = Guid.NewGuid();

        builder.Entity<Faculty>().HasData(
            new Faculty
            {
                FacultyID = FacultyOfScienceId, // Use the static readonly Guid
                FacultyName = "Faculty of Science",
                FacultyDescription = "Science Faculty",
                BirthYear = new DateTimeOffset(new DateTime(1990, 1, 1))
            },
            new Faculty
            {
                FacultyID = FacultyOfArtsAndSocialSciencesId, // Use the static readonly Guid
                FacultyName = "Faculty of Arts and Social Sciences",
                FacultyDescription = "Arts and Social Sciences Faculty",
                BirthYear = new DateTimeOffset(new DateTime(1995, 1, 1))
            },
            new Faculty
            {
                FacultyID = SchoolOfNursingAndMidwiferyId, // Use the static readonly Guid
                FacultyName = "School of Nursing and Midwifery", // School as Faculty
                FacultyDescription = "School of Nursing and Midwifery",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1))
            },
            new Faculty
            {
                FacultyID = SchoolOfEducationId, // Use the static readonly Guid
                FacultyName = "School of Education", // School as Faculty
                FacultyDescription = "School of Education",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1))
            },
            new Faculty
            {
                FacultyID = SchoolOfBusinessId, // Use the static readonly Guid
                FacultyName = "School of Business", // School as Faculty
                FacultyDescription = "School of Business",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1))
            },
            new Faculty // School of Graduate Studies
            {
                FacultyID = SchoolOfGraduateStudiesId, // Use the static readonly Guid
                FacultyName = "School of Graduate Studies", // School as Faculty
                FacultyDescription = "School of Graduate Studies",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1))
            }
        );
    }
}