using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedDepartments
{
    // Declare public static readonly Guids for all Department IDs
    public static Guid DepartmentOfComputerScienceId;
    public static Guid DepartmentOfInformationTechnologyId;
    public static Guid DepartmentOfBusinessInformationSystemsId;
    public static Guid DepartmentOfBiomedicalEngineeringId;
    public static Guid DepartmentOfMathematicsWithStatisticsId;
    public static Guid DepartmentOfAgribusinessId;
    public static Guid DepartmentOfAgricultureId;
    public static Guid DepartmentOfTheologicalStudiesId;
    public static Guid DepartmentOfCommunicationStudiesId;
    public static Guid DepartmentOfDevelopmentStudiesId;
    public static Guid DepartmentOfNursingId;
    public static Guid DepartmentOfMidwiferyId;
    public static Guid DepartmentOfMentalHealthNursingId;
    public static Guid DepartmentOfBEdEnglishLanguageId;
    public static Guid DepartmentOfBEdInformationTechnologyId;
    public static Guid DepartmentOfBEdSocialStudiesId;
    public static Guid DepartmentOfBEdMusicId;
    public static Guid DepartmentOfBEdAccountingId;
    public static Guid DepartmentOfBEdManagementId;
    public static Guid DepartmentOfMusicDiplomaId;
    public static Guid DepartmentOfBbaAccountingId;
    public static Guid DepartmentOfBbaBankingAndFinanceId;
    public static Guid DepartmentOfBbaHumanResourceManagementId;
    public static Guid DepartmentOfBbaManagementId;
    public static Guid DepartmentOfBbaMarketingId;
    public static Guid DepartmentOfBusinessAdministrationDiplomaId;
    public static Guid DepartmentOfPhDBusinessAdministrationId;
    public static Guid DepartmentOfPhDComputerScienceId;
    public static Guid DepartmentOfMScMPhilComputerScienceId;
    public static Guid DepartmentOfMbaAccountingId;
    public static Guid DepartmentOfMbaStrategicManagementId;
    public static Guid DepartmentOfMbaBankingAndFinanceId;
    public static Guid DepartmentOfMedmPhilCurriculumAndInstructionId;
    public static Guid DepartmentOfMedmPhilEducationalAdministrationAndLeadershipId;
    public static Guid DepartmentOfPostgraduateDiplomaInEducationId;
    public static Guid DepartmentOfGeneralEducationId;


    public static void Seed(ModelBuilder builder) // Removed faculty/school IDs from parameters
    {
        // Assign Guid.NewGuid() to each Department ID
        DepartmentOfComputerScienceId = Guid.NewGuid();
        DepartmentOfInformationTechnologyId = Guid.NewGuid();
        DepartmentOfBusinessInformationSystemsId = Guid.NewGuid();
        DepartmentOfBiomedicalEngineeringId = Guid.NewGuid();
        DepartmentOfMathematicsWithStatisticsId = Guid.NewGuid();
        DepartmentOfAgribusinessId = Guid.NewGuid();
        DepartmentOfAgricultureId = Guid.NewGuid();
        DepartmentOfTheologicalStudiesId = Guid.NewGuid();
        DepartmentOfCommunicationStudiesId = Guid.NewGuid();
        DepartmentOfDevelopmentStudiesId = Guid.NewGuid();
        DepartmentOfNursingId = Guid.NewGuid();
        DepartmentOfMidwiferyId = Guid.NewGuid();
        DepartmentOfMentalHealthNursingId = Guid.NewGuid();
        DepartmentOfBEdEnglishLanguageId = Guid.NewGuid();
        DepartmentOfBEdInformationTechnologyId = Guid.NewGuid();
        DepartmentOfBEdSocialStudiesId = Guid.NewGuid();
        DepartmentOfBEdMusicId = Guid.NewGuid();
        DepartmentOfBEdAccountingId = Guid.NewGuid();
        DepartmentOfBEdManagementId = Guid.NewGuid();
        DepartmentOfMusicDiplomaId = Guid.NewGuid();
        DepartmentOfBbaAccountingId = Guid.NewGuid();
        DepartmentOfBbaBankingAndFinanceId = Guid.NewGuid();
        DepartmentOfBbaHumanResourceManagementId = Guid.NewGuid();
        DepartmentOfBbaManagementId = Guid.NewGuid();
        DepartmentOfBbaMarketingId = Guid.NewGuid();
        DepartmentOfBusinessAdministrationDiplomaId = Guid.NewGuid();
        DepartmentOfPhDBusinessAdministrationId = Guid.NewGuid();
        DepartmentOfPhDComputerScienceId = Guid.NewGuid();
        DepartmentOfMScMPhilComputerScienceId = Guid.NewGuid();
        DepartmentOfMbaAccountingId = Guid.NewGuid();
        DepartmentOfMbaStrategicManagementId = Guid.NewGuid();
        DepartmentOfMbaBankingAndFinanceId = Guid.NewGuid();
        DepartmentOfMedmPhilCurriculumAndInstructionId = Guid.NewGuid();
        DepartmentOfMedmPhilEducationalAdministrationAndLeadershipId = Guid.NewGuid();
        DepartmentOfPostgraduateDiplomaInEducationId = Guid.NewGuid();
        DepartmentOfGeneralEducationId = Guid.NewGuid();


        builder.Entity<Department>().HasData(
            // Faculty of Science Departments
            new Department
            {
                DepartmentID = DepartmentOfComputerScienceId,
                DepartmentName = "Computer Science",
                DepartmentDescription = "Department of Computer Science",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfInformationTechnologyId,
                DepartmentName = "Information Technology",
                DepartmentDescription = "Department of Information Technology",
                BirthYear = new DateTimeOffset(new DateTime(2005, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBusinessInformationSystemsId,
                DepartmentName = "Business Information Systems",
                DepartmentDescription = "Department of Business Information Systems",
                BirthYear = new DateTimeOffset(new DateTime(2010, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBiomedicalEngineeringId,
                DepartmentName = "Biomedical Engineering",
                DepartmentDescription = "Department of Biomedical Engineering",
                BirthYear = new DateTimeOffset(new DateTime(2015, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfMathematicsWithStatisticsId,
                DepartmentName = "Mathematics with Statistics",
                DepartmentDescription = "Department of Mathematics with Statistics",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfAgribusinessId,
                DepartmentName = "Agribusiness",
                DepartmentDescription = "Department of Agribusiness",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)), // Example BirthYear
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120 // Example Credits
            },
            new Department
            {
                DepartmentID = DepartmentOfAgricultureId,
                DepartmentName = "Agriculture",
                DepartmentDescription = "Department of Agriculture",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)), // Example BirthYear
                FacultyID = SeedFaculties.FacultyOfScienceId, // Access Faculty Guid directly
                RequiredCredits = 120 // Example Credits
            },

            // Faculty of Arts and Social Sciences Departments
            new Department
            {
                DepartmentID = DepartmentOfTheologicalStudiesId,
                DepartmentName = "Theological Studies",
                DepartmentDescription = "Department of Theological Studies",
                BirthYear = new DateTimeOffset(new DateTime(1980, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfArtsAndSocialSciencesId, // Access Faculty Guid directly
                RequiredCredits = 90
            },
            new Department
            {
                DepartmentID = DepartmentOfCommunicationStudiesId,
                DepartmentName = "Communication Studies",
                DepartmentDescription = "Department of Communication Studies",
                BirthYear = new DateTimeOffset(new DateTime(1990, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfArtsAndSocialSciencesId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfDevelopmentStudiesId,
                DepartmentName = "Development Studies",
                DepartmentDescription = "Department of Development Studies",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1)),
                FacultyID = SeedFaculties.FacultyOfArtsAndSocialSciencesId, // Access Faculty Guid directly
                RequiredCredits = 120
            },

            // School of Nursing and Midwifery Departments
            new Department
            {
                DepartmentID = DepartmentOfNursingId,
                DepartmentName = "Nursing",
                DepartmentDescription = "Department of Nursing",
                BirthYear = new DateTimeOffset(new DateTime(2005, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfNursingAndMidwiferyId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfMidwiferyId,
                DepartmentName = "Midwifery",
                DepartmentDescription = "Department of Midwifery",
                BirthYear = new DateTimeOffset(new DateTime(2010, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfNursingAndMidwiferyId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfMentalHealthNursingId,
                DepartmentName = "Mental Health Nursing",
                DepartmentDescription = "Department of Mental Health Nursing",
                BirthYear = new DateTimeOffset(new DateTime(2015, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfNursingAndMidwiferyId, // Access Faculty Guid directly
                RequiredCredits = 120
            },

            // School of Education Departments
            new Department
            {
                DepartmentID = DepartmentOfBEdEnglishLanguageId,
                DepartmentName = "BEd English Language",
                DepartmentDescription = "Department of BEd English Language",
                BirthYear = new DateTimeOffset(new DateTime(2010, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBEdInformationTechnologyId,
                DepartmentName = "BEd Information Technology",
                DepartmentDescription = "Department of BEd Information Technology",
                BirthYear = new DateTimeOffset(new DateTime(2015, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBEdSocialStudiesId,
                DepartmentName = "BEd Social Studies",
                DepartmentDescription = "Department of BEd Social Studies",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBEdMusicId,
                DepartmentName = "BEd Music",
                DepartmentDescription = "Department of BEd Music",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBEdAccountingId,
                DepartmentName = "BEd Accounting",
                DepartmentDescription = "Department of BEd Accounting",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBEdManagementId,
                DepartmentName = "BEd Management",
                DepartmentDescription = "Department of BEd Management",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department // Diploma in Music - Within School of Education
            {
                DepartmentID = DepartmentOfMusicDiplomaId, // Use the static readonly Guid
                DepartmentName = "Diploma in Music",
                DepartmentDescription = "Diploma in Music Program",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfEducationId, // Access Faculty Guid directly
                RequiredCredits = 60
            },

            // School of Business Departments
            new Department
            {
                DepartmentID = DepartmentOfBbaAccountingId,
                DepartmentName = "BBA Accounting",
                DepartmentDescription = "Department of BBA Accounting",
                BirthYear = new DateTimeOffset(new DateTime(2010, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBbaBankingAndFinanceId,
                DepartmentName = "BBA Banking and Finance",
                DepartmentDescription = "Department of BBA Banking and Finance",
                BirthYear = new DateTimeOffset(new DateTime(2015, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBbaHumanResourceManagementId,
                DepartmentName = "BBA Human Resource Management",
                DepartmentDescription = "Department of BBA Human Resource Management",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBbaManagementId,
                DepartmentName = "BBA Management",
                DepartmentDescription = "Department of BBA Management",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department
            {
                DepartmentID = DepartmentOfBbaMarketingId,
                DepartmentName = "BBA Marketing",
                DepartmentDescription = "Department of BBA Marketing",
                BirthYear = new DateTimeOffset(new DateTime(2020, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 120
            },
            new Department // Diploma in Business Administration - Within School of Business
            {
                DepartmentID = DepartmentOfBusinessAdministrationDiplomaId,
                DepartmentName = "Diploma in Business Administration",
                DepartmentDescription = "Diploma in Business Administration Program",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfBusinessId, // Access Faculty Guid directly
                RequiredCredits = 60
            },

            // School of Graduate Studies Departments
            new Department // PhD Business Administration
            {
                DepartmentID = DepartmentOfPhDBusinessAdministrationId,
                DepartmentName = "PhD Business Administration",
                DepartmentDescription = "PhD Program in Business Administration",
                BirthYear = new DateTimeOffset(new DateTime(2023, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 45
            },
            new Department // PhD Computer Science
            {
                DepartmentID = DepartmentOfPhDComputerScienceId,
                DepartmentName = "PhD Computer Science",
                DepartmentDescription = "PhD Program in Computer Science",
                BirthYear = new DateTimeOffset(new DateTime(2023, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 45
            },
            new Department // MSc/MPhil Computer Science
            {
                DepartmentID = DepartmentOfMScMPhilComputerScienceId,
                DepartmentName = "MSc/MPhil Computer Science",
                DepartmentDescription = "MSc/MPhil Program in Computer Science",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)), // Example BirthYear
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 30
            },
            new Department // MBA Accounting
            {
                DepartmentID = DepartmentOfMbaAccountingId,
                DepartmentName = "MBA Accounting",
                DepartmentDescription = "MBA Program in Accounting",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)), // Example BirthYear
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 40
            },
            new Department // MBA Strategic Management
            {
                DepartmentID = DepartmentOfMbaStrategicManagementId,
                DepartmentName = "MBA Strategic Management",
                DepartmentDescription = "MBA Program in Strategic Management",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)), // Example BirthYear
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 40
            },
            new Department // MBA Banking & Finance
            {
                DepartmentID = DepartmentOfMbaBankingAndFinanceId,
                DepartmentName = "MBA Banking & Finance",
                DepartmentDescription = "MBA Program in Banking & Finance",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 40
            },
            new Department // MEd/MPhil Curriculum & Instruction
            {
                DepartmentID = DepartmentOfMedmPhilCurriculumAndInstructionId,
                DepartmentName = "MEd/MPhil Curriculum & Instruction",
                DepartmentDescription = "MEd/MPhil Program in Curriculum & Instruction",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 30
            },
            new Department // MEd/MPhil Educational Administration & Leadership
            {
                DepartmentID = DepartmentOfMedmPhilEducationalAdministrationAndLeadershipId,
                DepartmentName = "MEd/MPhil Educational Administration & Leadership",
                DepartmentDescription = "MEd/MPhil Program in Educational Administration & Leadership",
                BirthYear = new DateTimeOffset(new DateTime(2022, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 30
            },
            new Department // Postgraduate Diploma in Education
            {
                DepartmentID = DepartmentOfPostgraduateDiplomaInEducationId,
                DepartmentName = "Postgraduate Diploma in Education",
                DepartmentDescription = "Postgraduate Diploma in Education Program",
                BirthYear = new DateTimeOffset(new DateTime(2023, 1, 1)),
                FacultyID = SeedFaculties.SchoolOfGraduateStudiesId, // Access Faculty Guid directly
                RequiredCredits = 30
            },

            // General Education Department - University Wide Courses (No Faculty Assigned Directly)
            new Department
            {
                DepartmentID = DepartmentOfGeneralEducationId,
                DepartmentName = "General Education",
                DepartmentDescription = "University Wide General Education Courses",
                BirthYear = new DateTimeOffset(new DateTime(2000, 1, 1)),
                FacultyID =
                    SeedFaculties
                        .FacultyOfScienceId, // Example Faculty - Could be a central admin faculty or Faculty of Arts for GE courses? // Access Faculty Guid directly
                RequiredCredits = 30
            }
        );
    }
}