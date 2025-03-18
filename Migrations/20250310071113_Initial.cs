using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace iSchool_Solution.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiry = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    PossibleAnswers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                });

            migrationBuilder.CreateTable(
                name: "LibraryResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearPublished = table.Column<int>(type: "int", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceType = table.Column<int>(type: "int", nullable: false),
                    IsDigital = table.Column<bool>(type: "bit", nullable: false),
                    DigitalAccessLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationPeriods",
                columns: table => new
                {
                    RegistrationPeriodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowCourseAdd = table.Column<bool>(type: "bit", nullable: false),
                    AllowCourseDrop = table.Column<bool>(type: "bit", nullable: false),
                    LateRegistrationStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateRegistrationEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LateRegistrationFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationPeriods", x => x.RegistrationPeriodID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainAuthorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSubmitted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchProjects_AspNetUsers_MainAuthorID",
                        column: x => x.MainAuthorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FacultyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredCredits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceBorrowings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryResourceID = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceBorrowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceBorrowings_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceBorrowings_LibraryResources_LibraryResourceID",
                        column: x => x.LibraryResourceID,
                        principalTable: "LibraryResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchContributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchProjectID = table.Column<int>(type: "int", nullable: false),
                    ResearchContributorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContributionDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchContributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchContributors_AspNetUsers_ResearchContributorID",
                        column: x => x.ResearchContributorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResearchContributors_ResearchProjects_ResearchProjectID",
                        column: x => x.ResearchProjectID,
                        principalTable: "ResearchProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchProjectID = table.Column<int>(type: "int", nullable: false),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    UploadDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchDocument_ResearchProjects_ResearchProjectID",
                        column: x => x.ResearchProjectID,
                        principalTable: "ResearchProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCredits = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcademicAdvisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecturerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecturerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Credentials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LecturerID);
                    table.ForeignKey(
                        name: "FK_Lecturers_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    RegistrationPeriodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudents_RegistrationPeriods_RegistrationPeriodID",
                        column: x => x.RegistrationPeriodID,
                        principalTable: "RegistrationPeriods",
                        principalColumn: "RegistrationPeriodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialRecords",
                columns: table => new
                {
                    FinancialRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OutstandingBalance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialRecords", x => x.FinancialRecordID);
                    table.ForeignKey(
                        name: "FK_FinancialRecords_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    TranscriptID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    GeneratedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CummulativeGPA = table.Column<double>(type: "float", nullable: false),
                    CreditsAttempted = table.Column<int>(type: "int", nullable: false),
                    CreditsEarned = table.Column<int>(type: "int", nullable: false),
                    isOfficial = table.Column<bool>(type: "bit", nullable: false),
                    AcademicStanding = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.TranscriptID);
                    table.ForeignKey(
                        name: "FK_Transcripts_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTimeSlot",
                columns: table => new
                {
                    CourseTimeSlotID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Location = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTimeSlot", x => x.CourseTimeSlotID);
                    table.ForeignKey(
                        name: "FK_CourseTimeSlot_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTimeSlot_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerCourse",
                columns: table => new
                {
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerCourse", x => new { x.LecturerID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_LecturerCourse_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerCourse_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationPeriodID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubmissionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerEvaluations_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerEvaluations_EvaluationPeriods_EvaluationPeriodID",
                        column: x => x.EvaluationPeriodID,
                        principalTable: "EvaluationPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerEvaluations_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancialRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FeeItemCategory = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    isRequired = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeItems_FinancialRecords_FinancialRecordID",
                        column: x => x.FinancialRecordID,
                        principalTable: "FinancialRecords",
                        principalColumn: "FinancialRecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_FinancialRecords_FinancialRecordID",
                        column: x => x.FinancialRecordID,
                        principalTable: "FinancialRecords",
                        principalColumn: "FinancialRecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterRecords",
                columns: table => new
                {
                    SemesterRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranscriptID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SemesterGPA = table.Column<double>(type: "float", nullable: false),
                    CreditsAttempted = table.Column<int>(type: "int", nullable: false),
                    CreditsEarned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterRecords", x => x.SemesterRecordID);
                    table.ForeignKey(
                        name: "FK_SemesterRecords_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SemesterRecords_Transcripts_TranscriptID",
                        column: x => x.TranscriptID,
                        principalTable: "Transcripts",
                        principalColumn: "TranscriptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerEvaluationID = table.Column<int>(type: "int", nullable: false),
                    EvaluationQuestionID = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<int>(type: "int", nullable: true),
                    TextResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedOption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationResponses_EvaluationQuestions_EvaluationQuestionID",
                        column: x => x.EvaluationQuestionID,
                        principalTable: "EvaluationQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationResponses_LecturerEvaluations_LecturerEvaluationID",
                        column: x => x.LecturerEvaluationID,
                        principalTable: "LecturerEvaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    DateAwarded = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GradeLetter = table.Column<int>(type: "int", nullable: false),
                    GradePoints = table.Column<double>(type: "float", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeID);
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_SemesterRecords_SemesterRecordID",
                        column: x => x.SemesterRecordID,
                        principalTable: "SemesterRecords",
                        principalColumn: "SemesterRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "User", "USER" },
                    { "2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshTokenExpiry", "SecurityStamp", "StudentFirstName", "StudentID", "StudentLastName", "TwoFactorEnabled", "UserName" },
                values: new object[] { "222CS01000694", 0, "13a1e190-825f-4a7f-a631-bb86b40e4cf8", "kwakuaffram@gmail.com", true, false, null, "KWAKUAFFRAM@GMAIL.COM", "222CS01000694", "AQAAAAIAAYagAAAAEFMe7jB9Q72Ru+1pr0M1POrhDPfIzTWOIgH4LMoEAWeoeYLor5HZpgnac0GT8yNpbw==", "0553138727", true, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cbbb5787-58d1-409d-88f2-ce22771e076c", "Kwaku", "222CS01000694", "Affram", true, "222CS01000694" });

            migrationBuilder.InsertData(
                table: "EvaluationPeriods",
                columns: new[] { "Id", "AcademicYear", "Description", "EndDate", "IsActive", "Semester", "StartDate" },
                values: new object[,]
                {
                    { 1, "2024-2025", "September 2024 Evaluation", new DateTimeOffset(new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 0, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, "2024-2025", "January 2025 Evaluation", new DateTimeOffset(new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, 1, new DateTimeOffset(new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "EvaluationQuestions",
                columns: new[] { "Id", "Category", "DisplayOrder", "IsActive", "PossibleAnswers", "QuestionText", "QuestionType" },
                values: new object[,]
                {
                    { 1, 0, 1, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "How would you rate the teaching methods used in this course?", 1 },
                    { 2, 1, 2, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "Were the course materials (handouts, slides, online resources) helpful for your learning?", 1 },
                    { 3, 2, 3, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "How effective was the lecturer in explaining difficult concepts?", 1 },
                    { 4, 3, 4, true, "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]", "The lecturer encouraged student participation and questions.", 1 },
                    { 5, 4, 5, true, "[\"Poorly\", \"Fairly\", \"Moderately\", \"Well\", \"Very Well\"]", "How well did the lecturer manage the class time?", 1 },
                    { 6, 5, 6, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "How knowledgeable was the lecturer in the subject matter?", 1 },
                    { 7, 5, 7, true, "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]", "The lecturer demonstrated a clear understanding of the course content.", 1 },
                    { 8, 6, 8, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "How well was the course content organized?", 1 },
                    { 9, 7, 9, true, "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]", "The learning objectives of the course were clearly communicated.", 1 },
                    { 10, 8, 10, true, "[\"1\", \"2\", \"3\", \"4\", \"5\"]", "How fair and relevant were the assessment methods used in this course?", 1 },
                    { 11, 9, 11, true, "[\"Strongly Disagree\", \"Disagree\", \"Neutral\", \"Agree\", \"Strongly Agree\"]", "The feedback provided on assignments was helpful for my learning.", 1 },
                    { 12, 10, 12, true, "[]", "What are the strengths of this lecturer/course?", 2 },
                    { 13, 10, 13, true, "[]", "What are some areas for improvement for this lecturer/course?", 2 },
                    { 14, 11, 14, true, "[\"Very Dissatisfied\", \"Dissatisfied\", \"Neutral\", \"Satisfied\", \"Very Satisfied\"]", "Overall, how satisfied were you with this course and lecturer?", 1 }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyID", "BirthYear", "FacultyDescription", "FacultyName" },
                values: new object[,]
                {
                    { new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Graduate Studies", "School of Graduate Studies" },
                    { new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Science Faculty", "Faculty of Science" },
                    { new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), new DateTimeOffset(new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Arts and Social Sciences Faculty", "Faculty of Arts and Social Sciences" },
                    { new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Education", "School of Education" },
                    { new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Nursing and Midwifery", "School of Nursing and Midwifery" },
                    { new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "School of Business", "School of Business" }
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "LecturerID", "CourseID", "Credentials", "DepartmentID", "Gender", "LecturerEmail", "LecturerFirstName", "LecturerLastName", "Office" },
                values: new object[,]
                {
                    { "L0001", null, "Masters", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), 0, "masare@example.com", "Michael", "Asare", "Room 101" },
                    { "L0002", null, "PhD", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), 0, "papa@example.com", "Papa", "Prince", "Room 102" }
                });

            migrationBuilder.InsertData(
                table: "LibraryResources",
                columns: new[] { "Id", "Author", "AvailableCopies", "Category", "Description", "DigitalAccessLink", "Edition", "ISBN", "IsDigital", "Location", "Publisher", "ResourceType", "Title", "TotalCopies", "YearPublished" },
                values: new object[] { 1, "Thomas H. Cormen", 8, "Computer Science", "Comprehensive guide to algorithms", "", "3rd", "9780262033848", false, "Library Section A", "MIT Press", 0, "Introduction to Algorithms", 10, 2009 });

            migrationBuilder.InsertData(
                table: "RegistrationPeriods",
                columns: new[] { "RegistrationPeriodID", "AcademicYear", "AllowCourseAdd", "AllowCourseDrop", "Description", "EndDate", "IsActive", "LateRegistrationEnd", "LateRegistrationFee", "LateRegistrationStart", "Semester", "StartDate" },
                values: new object[] { new Guid("fe0137a4-129b-4202-8992-43888f906cd0"), "2024-2025", true, true, "January 2025 Registration", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "January", new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "222CS01000694" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "BirthYear", "DepartmentDescription", "DepartmentName", "FacultyID", "RequiredCredits" },
                values: new object[,]
                {
                    { new Guid("0062ca09-cb14-4848-89ba-bf67d3f47558"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Computer Science", "PhD Computer Science", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 45 },
                    { new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "University Wide General Education Courses", "General Education", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 30 },
                    { new Guid("204c5a07-76d1-4cd9-b8d0-a9f03f71f0dc"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Music", "BEd Music", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("2c3cf3e7-8d5a-4d96-a43b-7129f8609ebc"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Information Technology", "BEd Information Technology", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("36748cb9-3334-4842-adeb-1dad00176201"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Educational Administration & Leadership", "MEd/MPhil Educational Administration & Leadership", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("39f92acc-5a6b-4ec9-b42a-6aa63ade34ac"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Social Studies", "BEd Social Studies", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("39fb16d9-4838-4ede-b54c-f0e54b7c03e9"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Human Resource Management", "BBA Human Resource Management", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("4c146b27-19aa-494c-b73c-4bb2e6b72181"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Business Information Systems", "Business Information Systems", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("6c845634-cb6d-45e2-b659-1b6e0d3764e7"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agribusiness", "Agribusiness", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("75b2887a-e4cc-4ec4-8d6a-f79accc5a942"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Development Studies", "Development Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 120 },
                    { new Guid("77b49912-6570-4173-a846-3240e8b6e688"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Accounting", "BEd Accounting", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("7e78d48a-9c30-4f2b-aea5-2fe1f419629c"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Strategic Management", "MBA Strategic Management", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("8f368706-5f28-4ae8-9311-df79be89cd87"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MSc/MPhil Program in Computer Science", "MSc/MPhil Computer Science", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Accounting", "BBA Accounting", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("920d6408-dc36-4da4-82dd-b8d89879c4e5"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MEd/MPhil Program in Curriculum & Instruction", "MEd/MPhil Curriculum & Instruction", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("971b2827-460d-4eab-bf7d-5ceec95e12e9"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd English Language", "BEd English Language", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("9b503f55-0d9d-4a72-b36d-00007d653e19"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Banking and Finance", "BBA Banking and Finance", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("9e11fb93-430a-4b00-9484-9fa5d244d7f6"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mental Health Nursing", "Mental Health Nursing", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("a0153b89-8d4d-4e7b-8590-0ea0c065e680"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Postgraduate Diploma in Education Program", "Postgraduate Diploma in Education", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 30 },
                    { new Guid("a75b1f50-327c-43b6-81f3-60f6a11b2a39"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Management", "BBA Management", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("a8fbc857-3859-4290-b237-a3c34ede9a12"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Agriculture", "Agriculture", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Computer Science", "Computer Science", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("b51eecd8-ba6b-48f8-a0c3-9db931701e30"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Accounting", "MBA Accounting", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("c1c8f6b4-aa8a-4290-85b6-d37cf1cbd6de"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BBA Marketing", "BBA Marketing", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 120 },
                    { new Guid("ca8b289b-3e16-4cec-96f4-e42bc265d541"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "MBA Program in Banking & Finance", "MBA Banking & Finance", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 40 },
                    { new Guid("cbebda38-3ec2-48aa-b0ad-062272d89f1b"), new DateTimeOffset(new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Midwifery", "Midwifery", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("d10082ac-f3e9-4d09-b6db-cd80f309289c"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Business Administration Program", "Diploma in Business Administration", new Guid("9dc2587e-cefb-48a2-b00f-a5dcea80750e"), 60 },
                    { new Guid("d2de626b-f5eb-4b56-90a3-c6ebf0a3ff9b"), new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Communication Studies", "Communication Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 120 },
                    { new Guid("da251655-a9b0-4ffc-ae14-58e05447fa21"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of BEd Management", "BEd Management", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 120 },
                    { new Guid("dae9a67c-7463-4202-a21c-8f0768a2d004"), new DateTimeOffset(new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Biomedical Engineering", "Biomedical Engineering", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("dbd2656c-078b-4dac-8855-118ef5fd3f13"), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Mathematics with Statistics", "Mathematics with Statistics", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 },
                    { new Guid("e805a0ae-aa24-4664-b92e-20e9237f7087"), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "PhD Program in Business Administration", "PhD Business Administration", new Guid("050d1c12-4bc2-4ad9-b11e-cd6b63c14ba7"), 45 },
                    { new Guid("ef16e32c-5600-45a4-9a0e-2f61b63081e9"), new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Diploma in Music Program", "Diploma in Music", new Guid("8299515f-6d18-4436-a449-ec9a46f802f6"), 60 },
                    { new Guid("f51c3927-2d65-40a8-892f-986e68899f8c"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Nursing", "Nursing", new Guid("8d679424-ebfb-4a05-aa3d-c9b43b99ac8d"), 120 },
                    { new Guid("f6077631-118c-4c78-9bdb-7a7bda448145"), new DateTimeOffset(new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Theological Studies", "Theological Studies", new Guid("6eb6ce00-ddd4-4c45-be84-01f00286ddee"), 90 },
                    { new Guid("fc538f1e-42cf-438b-b715-b3760fe528c6"), new DateTimeOffset(new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Department of Information Technology", "Information Technology", new Guid("2d6e37df-0e61-439b-957b-904740b3883f"), 120 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedDate", "IsRead", "Message", "NotificationType", "Priority", "RedirectUrl", "StudentID", "Title" },
                values: new object[] { 1, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Welcome to the new semester!", 1, 1, "", "222CS01000694", "Welcome" });

            migrationBuilder.InsertData(
                table: "ResearchProjects",
                columns: new[] { "Id", "Abstract", "DateSubmitted", "Department", "Keywords", "MainAuthorID", "Status", "Title" },
                values: new object[] { 1, "Research on AI applications in healthcare", new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Computer Science", "AI, Healthcare", "222CS01000694", 1, "AI in Healthcare" });

            migrationBuilder.InsertData(
                table: "ResourceBorrowings",
                columns: new[] { "Id", "BorrowDate", "DueDate", "LateFee", "LibraryResourceID", "Notes", "ReturnDate", "Status", "StudentId" },
                values: new object[] { 1, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, 0, "222CS01000694" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseCode", "CourseCredits", "CourseDescription", "CourseName", "DepartmentID" },
                values: new object[,]
                {
                    { new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"), "COSC224", 3, "Focuses on object-oriented programming principles and paradigms.\nEmphasizes design patterns and software development.", "Object-Oriented Programming", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"), "COSC364", 3, "Introduces research methodologies and techniques.\nPrepares students for conducting research projects.", "Research Methods", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"), "ACCT210", 3, "Introduces basic accounting principles and practices.\nCovers financial accounting fundamentals.", "Introduction to Accounting", new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e") },
                    { new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"), "MGNT234", 3, "Introduces fundamental management principles and theories.\nCovers planning, organizing, leading, and controlling.", "Principles of Management", new Guid("8fece7d7-737e-4625-bc9a-d5392ae16a7e") },
                    { new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"), "ENGL111", 2, "Develops fundamental language and writing skills.\nFocuses on grammar, vocabulary, and basic composition.", "Language and Writing Skills I", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"), "ENGL112", 2, "Continues development of language and writing skills.\nBuilds upon skills from Language and Writing Skills I.", "Language and Writing Skills II", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"), "CMME115", 2, "Introduces fundamental communication theories and practices.\nDevelops effective communication abilities.", "Introduction to Communication Skills", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "COSC466", 3, "Elective course on systems and network administration.\nCovers server management, networking, and security.", "Systems and Network Administration (Elective 3)", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"), "FREN121", 2, "Introduces basic French language skills for communication.\nCovers fundamental grammar and vocabulary.", "French for General Communication 1", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"), "PEAC100", 0, "Promotes physical fitness and well-being through activity.\nEncourages a healthy lifestyle.", "Physical Activity", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"), "COSC272", 3, "Second part of data communication and networking course.\nBuilds upon concepts from Network I.", "Data Communication & Computer Network II", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"), "STAT282", 3, "This course introduces fundamental concepts in statistics.", "Introduction to Statistics", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"), "COSC230", 3, "Introduces database concepts and design principles.\nCovers relational database models and SQL.", "Database Systems Design", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), "GNED125", 1, "Develops effective learning and study strategies.\nEnhances academic performance and efficiency.", "Study Skills", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"), "COSC325", 3, "Introduces principles and practices of computer security.\nCovers threats, vulnerabilities, and security mechanisms.", "Computer Security", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"), "PHYS103", 3, "Introduces fundamental principles of physics.\nCovers mechanics, heat, light, and sound.", "Physics", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"), "SOC1105/PSYC105", 3, "Introduces basic concepts of Sociology OR Psychology.\nStudents choose one of these introductory social science courses.", "General Sociology OR Intro to Psychology", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"), "COSC255", 3, "Explores the principles and design of operating systems.\nCovers process management, memory management, and file systems.", "Operating Systems", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "COSC445", 3, "Covers entrepreneurship principles and human development in technology.\nFocuses on innovation and business skills.", "Entrepreneurship and Human Development", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"), "COSC113", 3, "Introduces fundamental programming concepts and techniques.\nFocuses on problem-solving and algorithm design.", "Elements of Programming", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("30677d50-b76e-4826-b24a-b7251602ee22"), "GNED230", 1, "Guides students in exploring career options and planning their future.\nDevelops career readiness skills.", "Career Exploration and Planning", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"), "HLTH200", 3, "Explores key health principles and practices.\nPromotes healthy living and disease prevention.", "Health Principles", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("3d27b128-0ce6-4990-9c5a-a21de5a414b5"), "COSC455", 3, "Introduces fundamental concepts and techniques of artificial intelligence.\nCovers AI algorithms and applications.", "Introduction to Artificial Intelligence", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("3d5c9296-405d-4648-addf-2b0706b77169"), "COSC491", 3, "First part of the final year project in computer science.\nStudents begin research and project development.", "Final Year Project 1", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"), "COSC250", 3, "Explores ethical issues in computing and information technology.\nDiscusses social and professional responsibilities.", "Computer Ethics", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"), "COSC271", 3, "First part of data communication and networking course.\nCovers network fundamentals and protocols.", "Data Communication & Computer Network I", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("4e99258c-12cd-46b4-bf5b-136de3664bdb"), "COSC480", 3, "Covers the principles and techniques of compiler design.\nExplores lexical analysis, parsing, and code generation.", "Compiler Design", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("520f8d39-11bd-4e16-9add-79661a45985e"), "CSCD210", 3, "Studies computational approaches to solving mathematical problems. Focuses on numerical algorithms and their implementation.", "NUMERICAL METHODS", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"), "COSC115", 3, "First part of introductory computer science course.\nExplores basic concepts and problem-solving.", "Introduction to Computer Science 1", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"), "AFST205", 1, "African Studies Course - Placeholder. Replace with actual course details for Group A.", "African Studies - Chieftancy and Development", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("58bbeec1-d95e-41f9-af74-a517457235c6"), "COSC436", 3, "Elective course focusing on computer and cyber forensics.\nCovers digital investigation techniques and cybercrime analysis.", "Computer & Cyber Forensics (Elective 1)", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"), "AFST243", 1, "African Studies Course - Placeholder. Replace with actual course details for Group B.", "African Studies - Group B", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"), "MATH171", 3, "Introduces mathematical concepts fundamental to computer science. Covers algebraic structures, logic, and basic calculus.", "INTRODUCTORY MATHS FOR COMPUTER SCIENCE", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("62330761-ad34-4969-96c7-47eb3c70f552"), "MATH172", 3, "Explores both discrete mathematical structures and continuous mathematical concepts relevant to computing.", "DISCRETE AND CONTINUOUS MATHEMATICS", new Guid("1496ee9d-0b12-4e78-869e-a2dcb8234db2") },
                    { new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"), "COSC280", 3, "Introduces concepts of information systems and their role in organizations.\nCovers system development and management.", "Information Systems", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("7ff93b84-31e2-4e02-81d1-68785909ccb9"), "COSC210", 3, "Covers numerical methods for solving mathematical problems.\nFocuses on algorithms and computational techniques.", "Numerical Methods", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"), "COSC116", 3, "Second part of introductory computer science course.\nBuilds on concepts from Introduction to Computer Science I.", "Introduction to Computer Science II", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("86293383-c8de-4941-b83a-4b7c88a53ae1"), "COSC447", 3, "Covers advanced software engineering methodologies and practices.\nEmphasizes team-based software development.", "Software Engineering", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"), "RELB163", 3, "Explores the life, ministry, and teachings of Jesus Christ.\nProvides a theological perspective.", "Life and Teachings of Jesus", new Guid("f6077631-118c-4c78-9bdb-7a7bda448145") },
                    { new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"), "COSC357", 3, "Covers principles and techniques of project planning and management.\nFocuses on software project management.", "Project Planning and Management", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("8fd7171a-8a59-4208-aabb-1c0699259052"), "CS101", 3, "Provides a foundational overview of the field of computer science.\nCovers basic concepts and principles.", "Introduction to Computer Science", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "COSC370", 3, "Covers operations research techniques for optimization and decision-making.\nApplies mathematical modeling to solve real-world problems.", "Operations Research", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("a793836a-dd04-40e6-a610-04c45c411837"), "COSC361", 3, "First part of data structures and algorithms course.\nCovers fundamental data structures and algorithm analysis.", "Data Structures & Algorithm I", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"), "COSC257", 3, "Covers computer architecture and microprocessor systems.\nExplores hardware design and organization.", "Computer Architecture & Microprocessor Systems", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"), "COSC260", 3, "Covers methodologies for analyzing, designing, and developing systems.\nEmphasizes software engineering principles.", "Systems Analysis and Design", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "COSC440", 3, "Elective course on computer vision principles and applications.\nCovers image processing and analysis techniques.", "Computer Vision (Elective 2)", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"), "COSC130", 3, "Introduces principles of digital electronics and logic circuits.\nCovers digital components and systems.", "Digital Electronics", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"), "COSC240", 3, "Focuses on low-level programming and system-level interactions.\nCovers OS APIs and system calls.", "Systems Programming", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"), "COSC331", 3, "Introduces principles and techniques of computer graphics.\nCovers 2D and 3D graphics rendering and animation.", "Computer Graphics", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("e1f195d3-4c19-4b33-a3ae-f2ac1f4e243e"), "COSC429", 3, "Covers principles and technologies of cloud computing.\nExplores cloud platforms and service models.", "Cloud Computing Systems", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("e528b274-541c-4ba6-b4a8-5480a190f7be"), "COSC492", 3, "Second part of the final year project in computer science.\nStudents complete their research and project development.", "Final Year Project II", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("e806b9b1-e27f-48df-9534-abe0ec02a5ab"), "COSC330", 3, "Covers techniques for computer simulation and systems modeling.\nApplies computational methods to model real-world systems.", "Computer Simulation & Systems Modeling", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"), "COSC214", 3, "Covers the organization and architecture of computer systems.\nExplores hardware components and their interactions.", "Computer Organization", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"), "COSC124", 3, "Focuses on procedural programming paradigms and techniques.\nEmphasizes structured programming and modular design.", "Procedural Programming", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"), "COSC425", 3, "Focuses on developing applications for mobile platforms.\nCovers mobile OS, UI design, and development tools.", "Mobile Application Development", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"), "RELT385", 3, "Introduces biblical foundations and ethical principles.\nExplores theological and ethical frameworks.", "Introduction to Biblical Foundation & Ethics", new Guid("f6077631-118c-4c78-9bdb-7a7bda448145") },
                    { new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"), "COSC360", 3, "Focuses on developing web-based applications and services.\nCovers front-end and back-end technologies.", "Web Application Development", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad") },
                    { new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"), "RELB251", 3, "Explores fundamental principles of Christian faith and theology.\nProvides a comprehensive overview.", "Principles of Christian Faith", new Guid("f6077631-118c-4c78-9bdb-7a7bda448145") },
                    { new Guid("fd9a3b1a-af4d-4232-8663-bb0af5c428a0"), "RELG451", 3, "Explores biblical perspectives on family dynamics and relationships.\nProvides theological insights into family life.", "Bible and Family Dynamics", new Guid("f6077631-118c-4c78-9bdb-7a7bda448145") }
                });

            migrationBuilder.InsertData(
                table: "ResearchContributors",
                columns: new[] { "Id", "ContributionDetails", "ResearchContributorID", "ResearchProjectID", "Role" },
                values: new object[] { 1, "Assisted with data analysis", "222CS01000694", 1, "Co-author" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AcademicAdvisor", "Address", "DateOfBirth", "Degree", "DepartmentID", "DepartmentName", "EmergencyContactName", "EmergencyContactPhone", "FirstName", "Gender", "LastName", "StudentEmail", "StudentPhone", "StudentPhotoUrl" },
                values: new object[,]
                {
                    { "222CS01000694", "Mr. Michael Asare", "Kings and Queens Residence", new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BSc Computer Science", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), "Computer Science", "Kojo Ansah Affram", "0501122334", "Kwaku", 0, "Affram", "kwakuaffram@gmail.com", "0553138727", "https://unsplash.com/photos/a-man-in-a-yellow-shirt-smiling-at-the-camera-ZjDbRtR_BcE" },
                    { "222CS01000695", "Papa Prince", "Kings and Queens Residence", new DateTimeOffset(new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "BSc Computer Science", new Guid("b3c682c8-efb6-4748-aac7-4ffb72eecaad"), "Computer Science", "Kwaku Ampem Affram", "0506590716", "Patricia", 1, "Affram", "adubea@example.com", "0553138727", "https://unsplash.com/photos/man-in-yellow-blazer-and-blue-denim-jeans-smiling-PK_t0Lrh7MM" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseID", "StudentID", "RegistrationPeriodID" },
                values: new object[,]
                {
                    { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "222CS01000694", new Guid("fe0137a4-129b-4202-8992-43888f906cd0") },
                    { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "222CS01000694", new Guid("fe0137a4-129b-4202-8992-43888f906cd0") },
                    { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "222CS01000694", new Guid("fe0137a4-129b-4202-8992-43888f906cd0") },
                    { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "222CS01000694", new Guid("fe0137a4-129b-4202-8992-43888f906cd0") }
                });

            migrationBuilder.InsertData(
                table: "CourseTimeSlot",
                columns: new[] { "CourseTimeSlotID", "CourseID", "DayOfWeek", "EndTime", "LecturerID", "Location", "StartTime" },
                values: new object[,]
                {
                    { new Guid("12ec5707-80a9-41f3-9fcd-eae84a472373"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 2, new TimeSpan(0, 16, 30, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("39e631cd-1bef-412c-8e1f-139d8e681dc8"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), 4, new TimeSpan(0, 15, 50, 0, 0), "L0001", 4, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("552dbe8f-11c0-4bbe-9670-01a37277fdba"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 5, new TimeSpan(0, 9, 30, 0, 0), "L0001", 5, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("658c5984-1c80-4a9e-9aab-29c2e6843280"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 9, 30, 0, 0), "L0002", 3, new TimeSpan(0, 7, 0, 0, 0) },
                    { new Guid("8953341e-d071-4ba1-92ff-12f126250adc"), new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), 5, new TimeSpan(0, 12, 30, 0, 0), "L0002", 5, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("9febe164-e2d9-46d2-8e72-ffe3edc1153b"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 1, new TimeSpan(0, 16, 30, 0, 0), "L0001", 0, new TimeSpan(0, 14, 0, 0, 0) },
                    { new Guid("cafd8292-75c1-49f2-a804-72c75576454d"), new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), 3, new TimeSpan(0, 12, 30, 0, 0), "L0001", 4, new TimeSpan(0, 10, 0, 0, 0) },
                    { new Guid("de56a00d-3226-41a4-8853-5f2f56a1d491"), new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), 3, new TimeSpan(0, 12, 30, 0, 0), "L0002", 4, new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "FinancialRecords",
                columns: new[] { "FinancialRecordID", "AcademicYear", "AmountPaid", "LastUpdated", "OutstandingBalance", "Semester", "StudentID", "TotalFees" },
                values: new object[,]
                {
                    { new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), "2023-2024", 5000m, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 200m, 1, "222CS01000694", 5200m },
                    { new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), "2024-2025", 6000m, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), -500m, 0, "222CS01000694", 5500m },
                    { new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), "2023-2024", 4800m, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0m, 0, "222CS01000694", 4800m }
                });

            migrationBuilder.InsertData(
                table: "LecturerCourse",
                columns: new[] { "CourseID", "LecturerID", "AcademicYear", "Semester" },
                values: new object[,]
                {
                    { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "L0001", "2024-2025", 0 },
                    { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "L0001", "2024-2025", 0 },
                    { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "L0001", "2024-2025", 0 },
                    { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "L0001", "2024-2025", 0 },
                    { new Guid("156ae504-b1fb-4981-af79-8a70f8b19bfa"), "L0002", "2024-2025", 0 },
                    { new Guid("2722aef8-8ead-4d5f-8841-e905e4f8dc63"), "L0002", "2024-2025", 0 },
                    { new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), "L0002", "2024-2025", 0 },
                    { new Guid("baa9502b-bf06-451c-a53b-357973a88fd1"), "L0002", "2024-2025", 0 }
                });

            migrationBuilder.InsertData(
                table: "LecturerEvaluations",
                columns: new[] { "Id", "Comments", "CourseID", "EvaluationPeriodID", "LecturerID", "SubmissionDate" },
                values: new object[] { 1, "Great course!", new Guid("8fd7171a-8a59-4208-aabb-1c0699259052"), 1, "L0001", new DateTimeOffset(new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "TranscriptID", "AcademicStanding", "CreditsAttempted", "CreditsEarned", "CummulativeGPA", "GeneratedDate", "StudentID", "isOfficial" },
                values: new object[] { new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c"), 2, 0, 0, 0.0, new DateTimeOffset(new DateTime(2024, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", false });

            migrationBuilder.InsertData(
                table: "EvaluationResponses",
                columns: new[] { "Id", "EvaluationQuestionID", "LecturerEvaluationID", "RatingValue", "SelectedOption", "TextResponse" },
                values: new object[,]
                {
                    { 1, 1, 1, 4, "4", null },
                    { 2, 2, 1, 5, "5", null },
                    { 3, 3, 1, 5, "5", null },
                    { 4, 4, 1, 4, "Agree", null },
                    { 5, 5, 1, 4, "Well", null },
                    { 6, 6, 1, 5, "5", null },
                    { 7, 7, 1, 5, "Strongly Agree", null },
                    { 8, 8, 1, 4, "4", null },
                    { 9, 9, 1, 4, "Agree", null },
                    { 10, 10, 1, 4, "4", null },
                    { 11, 11, 1, 3, "Neutral", null },
                    { 12, 12, 1, null, null, "The lecturer is very enthusiastic and knowledgeable. The course content was relevant and up-to-date." },
                    { 13, 13, 1, null, null, "More practical examples and real-world case studies could be incorporated." },
                    { 14, 14, 1, 4, "Satisfied", null }
                });

            migrationBuilder.InsertData(
                table: "FeeItems",
                columns: new[] { "Id", "Amount", "Description", "DueDate", "FeeItemCategory", "FinancialRecordID", "Notes", "PaymentStatus", "isRequired" },
                values: new object[,]
                {
                    { 1, 4500m, "Tuition Fee - September 2023", null, 0, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, 0, true },
                    { 2, 300m, "Dues - September 2023", null, 4, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, 0, true },
                    { 3, 5000m, "Tuition Fee - January 2024", null, 0, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, 0, true },
                    { 4, 200m, "Library Fee - January 2024", null, 1, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, 0, false },
                    { 5, 5200m, "Tuition Fee - September 2024", null, 0, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, 0, true },
                    { 6, 300m, "Dues - September 2024", null, 4, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, 0, true }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "Amount", "FinancialRecordID", "Notes", "PaymentDate", "PaymentMethod", "PaymentStatus", "ReferenceNumber" },
                values: new object[,]
                {
                    { new Guid("1373fabc-d569-4702-b49d-b5843615403f"), 2800m, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, new DateTimeOffset(new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 2, "716f1e77" },
                    { new Guid("19ac50f6-c91d-482f-a317-f31aa1d1b5a7"), 2000m, new Guid("cf3c0cac-6f2d-44eb-b039-e8d8b6fede3e"), null, new DateTimeOffset(new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "4958224c" },
                    { new Guid("40582ce5-c69c-4971-89ac-db91378d785b"), 100m, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2, "5823dc69" },
                    { new Guid("46fdd54d-25b9-41d4-a8a1-1ad7f4501d55"), 3000m, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, new DateTimeOffset(new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "cc1f49f1" },
                    { new Guid("68fdcb46-491e-4d2f-b520-912a603f9e0a"), 2000m, new Guid("1fece624-e382-4baf-9ed3-00bccb1abe25"), null, new DateTimeOffset(new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "7327bd94" },
                    { new Guid("b0fcc293-5634-4254-bbd3-34b63aa36774"), 6000m, new Guid("8e81839a-c1f2-4b04-98e0-632df23117f2"), null, new DateTimeOffset(new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "e941ebb2" }
                });

            migrationBuilder.InsertData(
                table: "SemesterRecords",
                columns: new[] { "SemesterRecordID", "AcademicYear", "CreditsAttempted", "CreditsEarned", "EndDate", "Semester", "SemesterGPA", "StartDate", "StudentID", "TranscriptID" },
                values: new object[,]
                {
                    { new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "2022/2023", 0, 0, new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "2022/2023", 0, 0, new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "2023/2024", 0, 0, new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "2023/2024", 0, 0, new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "2021/2022", 0, 0, new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 0.0, new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") },
                    { new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "2021/2022", 0, 0, new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 0.0, new DateTimeOffset(new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "222CS01000694", new Guid("59a18e8a-eb81-41e5-b4f1-6b312ae1617c") }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeID", "CourseID", "DateAwarded", "GradeLetter", "GradePoints", "Remarks", "Semester", "SemesterRecordID", "StudentID", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("0879919f-0859-4bcf-af04-14866fb2c632"), new Guid("96d16898-bce0-4f23-9ab1-9507e904b293"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("142e51ae-a1e0-4af2-9ccd-bf72ddcc23f8"), new Guid("87097a1a-aca0-42f0-8ce3-65995891a0ea"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("224856e4-2dab-461e-9a6d-5af7e251bd6a"), new Guid("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("2d4665dc-73ed-414d-84f9-04997affe73a"), new Guid("1b006764-b19a-402b-a17a-f9a12d5f4b76"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("3030cdb2-31d2-412c-b76f-f9f559d06e41"), new Guid("0922f512-59fd-43c4-9d36-cdd18fccfb13"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("30ef83f3-d15e-469f-8bb9-dbfbb859d638"), new Guid("fae9d171-eecf-4b51-87c6-08e9b8bb3b21"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("367dbb5b-8eb2-48c2-98fb-f6a6b23bb958"), new Guid("babc17e9-4b27-4ee1-8c79-5c39179eeb68"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("460d5cbb-99b4-4a08-b25c-c1ebaf682573"), new Guid("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("4760e506-6ea9-466c-b040-a24e8d6b51aa"), new Guid("fc6943fa-c904-4b85-9232-eba8c33c485e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("51d63611-e336-4d8b-a203-512179e33000"), new Guid("7e542e0d-713f-437f-8a1d-0133a004b722"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("5223758b-53f0-42a6-b6da-162a013a8522"), new Guid("1b84cd21-2550-41d3-b3d4-7a985e71d1ea"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("528cdfc0-0bbb-4d7c-baa1-1c84c4c39cde"), new Guid("a793836a-dd04-40e6-a610-04c45c411837"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("5359df1b-c663-42d0-98c8-b3761e8d09cf"), new Guid("012bdf77-0b02-4d88-8da0-105ba9f1f829"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("5490f4c8-b071-47db-8421-9261b3de4f83"), new Guid("0badf6bd-77ef-4c6d-a568-912b57daf884"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("67501f6f-2e0d-40d1-be02-15f3a8571467"), new Guid("2274f76c-d939-47c9-89c2-8284728f2c7a"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("6ccc3b12-b813-4ecc-9969-8302f2cc212a"), new Guid("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("7fec2139-1bd6-4da2-b482-922e33c1fe1d"), new Guid("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("8139cdd9-c82b-4b5e-b6d0-31bb05d2a942"), new Guid("1f1f83d3-6271-4ac5-964f-2805ae049fa1"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("84f12965-202f-47da-acaf-3a66ede57d28"), new Guid("8041883e-8a68-42e0-8213-3f8c2669c73e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("8c1075fc-ff0b-4b26-a77a-334371a0c3ca"), new Guid("13a87b42-12ce-4cbc-8011-fc2c792f29e5"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 10, 1.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("8e689d3b-5d91-48f6-aaaf-8dd93d6add3f"), new Guid("52d2190e-c7a3-4f7b-ab3b-731e82216d02"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("906d3943-6221-4cc7-8b4c-9bcb82eac86d"), new Guid("064f2d40-55de-4ff5-a56c-c57c1dd562f4"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("9dbe4a75-946b-4183-a321-1fa6ab63bd70"), new Guid("fb4cf15a-f794-4b59-bc78-3be63b7b8310"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("a41ec771-7d4d-411a-9c3e-b8705c3a2e00"), new Guid("564d341f-7ccf-4eb4-b250-f32d6cb1c633"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("a6cbe756-ea6e-4ce6-b22d-181cb1f993dc"), new Guid("23665740-f571-4a6e-b3b4-8cdcb719d2fc"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("a7120d6d-8ebd-46a7-a7ac-d30e88210c67"), new Guid("20acdf30-8b86-4b77-921d-02b0bc9ee0d5"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("ab8f7b77-87d1-4991-8d94-a248dafb5f21"), new Guid("f29033fa-ffd0-4c70-8726-a4eefa5f72ef"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("ac347fef-cc16-434a-85ba-605712c9459c"), new Guid("13c34157-f376-4a31-9391-7fdd4d7fbdb7"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, 2.3300000000000001, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("b422316a-4814-40fe-a20a-858e076e01a0"), new Guid("1a46ac1d-c607-4225-9002-e14a4c1e3363"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 12, 0.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("b521b4cd-2150-42c9-970f-460607af3f6a"), new Guid("8f5abb46-f621-4b96-9e1b-e6e84aba4b41"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("b86738e3-2aa6-4c01-96e4-f061900e1237"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("bc91ca56-7c40-45d2-906e-ec14d97d6c9d"), new Guid("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("c1dd35f0-9613-42c6-bcc9-9cba05dccf76"), new Guid("095a4f84-f388-4a49-9994-43eb52ec18e0"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("c29000cb-56fb-4ca5-a615-4ec989e1976d"), new Guid("62330761-ad34-4969-96c7-47eb3c70f552"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, 2.6699999999999999, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("c635a327-55da-4ac8-b504-6c58474805ec"), new Guid("4459b5db-fac2-4188-96ac-cf2d4e562f14"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("c808894d-0539-4458-a354-aa2be3fcd02a"), new Guid("25a7e084-5ce1-48e8-bca7-9cada78ffa26"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("ccf5cae9-b411-40ca-bf43-b9d6fce9ff94"), new Guid("e023c552-f2a5-48a5-88d6-f13f55b6d5bb"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("cf5f6515-b2a5-4b78-80a3-fe3a09ada802"), new Guid("435500b2-b00d-4a63-8571-a77f5aadc28d"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, 3.6699999999999999, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("d2526021-0cbd-4237-afcc-06a286efe990"), new Guid("60efbe37-61c0-4dc0-93ef-5d20358e8a30"), new DateTimeOffset(new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 0, new Guid("b7e44d83-ca27-46c1-b23f-91a8ec4bee86"), "222CS01000694", true },
                    { new Guid("d99fbd5e-b2af-4ab0-ad1c-95b1460ce254"), new Guid("20a3f858-958e-42b0-b841-e907b592ce0e"), new DateTimeOffset(new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 1, new Guid("b83cbf13-8d7b-41b2-824a-2e11c796d394"), "222CS01000694", true },
                    { new Guid("eaded960-c960-4614-91a4-56e16e0d45b2"), new Guid("32ff3746-075f-4a74-bdaa-ed776cf854ff"), new DateTimeOffset(new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, 2.0, null, 1, new Guid("04f4f643-b035-4715-8955-2465e277bbf5"), "222CS01000694", true },
                    { new Guid("eb1f3037-00d6-4d7f-91d6-d3fc8e419a8b"), new Guid("520f8d39-11bd-4e16-9add-79661a45985e"), new DateTimeOffset(new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 11, 0.0, null, 0, new Guid("0ce8be3d-220d-453a-a4c8-20535a845cba"), "222CS01000694", true },
                    { new Guid("f1c00dd7-b802-4f05-bb23-01a48e6857e8"), new Guid("c0fff6d8-640b-44a4-ba64-9c550052ef80"), new DateTimeOffset(new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4.0, null, 1, new Guid("20b25d82-ee11-4f78-8ce0-a99d68dbd408"), "222CS01000694", true },
                    { new Guid("fbe58454-1d09-49b0-820c-0464b7b0ec86"), new Guid("ab899bae-a14b-4a18-8ff5-b70be8405acc"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 3.0, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true },
                    { new Guid("fcc6657b-23e1-49e4-a163-a2e5a997fdca"), new Guid("b8391957-9ad4-4134-8b65-86d891b57d07"), new DateTimeOffset(new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, 3.3300000000000001, null, 0, new Guid("a35b69b6-16ed-499a-a4b6-b279e436a47a"), "222CS01000694", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_RegistrationPeriodID",
                table: "CourseStudents",
                column: "RegistrationPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentID",
                table: "CourseStudents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlot_CourseID",
                table: "CourseTimeSlot",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeSlot_LecturerID",
                table: "CourseTimeSlot",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyID",
                table: "Departments",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationResponses_EvaluationQuestionID",
                table: "EvaluationResponses",
                column: "EvaluationQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationResponses_LecturerEvaluationID",
                table: "EvaluationResponses",
                column: "LecturerEvaluationID");

            migrationBuilder.CreateIndex(
                name: "IX_FeeItems_FinancialRecordID",
                table: "FeeItems",
                column: "FinancialRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRecords_StudentID",
                table: "FinancialRecords",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseID",
                table: "Grades",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SemesterRecordID",
                table: "Grades",
                column: "SemesterRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourse_CourseID",
                table: "LecturerCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerEvaluations_CourseID",
                table: "LecturerEvaluations",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerEvaluations_EvaluationPeriodID",
                table: "LecturerEvaluations",
                column: "EvaluationPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerEvaluations_LecturerID",
                table: "LecturerEvaluations",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_CourseID",
                table: "Lecturers",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StudentID",
                table: "Notifications",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FinancialRecordID",
                table: "Payments",
                column: "FinancialRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchContributors_ResearchContributorID",
                table: "ResearchContributors",
                column: "ResearchContributorID");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchContributors_ResearchProjectID",
                table: "ResearchContributors",
                column: "ResearchProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchDocument_ResearchProjectID",
                table: "ResearchDocument",
                column: "ResearchProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchProjects_MainAuthorID",
                table: "ResearchProjects",
                column: "MainAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceBorrowings_LibraryResourceID",
                table: "ResourceBorrowings",
                column: "LibraryResourceID");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceBorrowings_StudentId",
                table: "ResourceBorrowings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterRecords_StudentID",
                table: "SemesterRecords",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterRecords_TranscriptID",
                table: "SemesterRecords",
                column: "TranscriptID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentID",
                table: "Transcripts",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "CourseTimeSlot");

            migrationBuilder.DropTable(
                name: "EvaluationResponses");

            migrationBuilder.DropTable(
                name: "FeeItems");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "LecturerCourse");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ResearchContributors");

            migrationBuilder.DropTable(
                name: "ResearchDocument");

            migrationBuilder.DropTable(
                name: "ResourceBorrowings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RegistrationPeriods");

            migrationBuilder.DropTable(
                name: "EvaluationQuestions");

            migrationBuilder.DropTable(
                name: "LecturerEvaluations");

            migrationBuilder.DropTable(
                name: "SemesterRecords");

            migrationBuilder.DropTable(
                name: "FinancialRecords");

            migrationBuilder.DropTable(
                name: "ResearchProjects");

            migrationBuilder.DropTable(
                name: "LibraryResources");

            migrationBuilder.DropTable(
                name: "EvaluationPeriods");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
