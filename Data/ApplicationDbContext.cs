using iSchool_Solution.Data.Configurations;
using iSchool_Solution.Data.SeedData;
using iSchool_Solution.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data;

public class ApplicationDbContext : IdentityDbContext<ApiUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Entity Sets
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EvaluationPeriod> EvaluationPeriods { get; set; }
    public DbSet<EvaluationQuestion> EvaluationQuestions { get; set; }
    public DbSet<EvaluationResponse> EvaluationResponses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<FeeItem> FeeItems { get; set; }
    public DbSet<FinancialRecord> FinancialRecords { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<LecturerEvaluation> LecturerEvaluations { get; set; }
    public DbSet<LibraryResource> LibraryResources { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<RegistrationPeriod> RegistrationPeriods { get; set; }
    public DbSet<ResearchContributor> ResearchContributors { get; set; }
    public DbSet<ResearchProject> ResearchProjects { get; set; }
    public DbSet<ResourceBorrowing> ResourceBorrowings { get; set; }
    public DbSet<SemesterRecord> SemesterRecords { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }
    
    // --- DbSets for New Finance Entities ---
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<PaymentGatewayTransaction> PaymentGatewayTransactions { get; set; }
    public DbSet<PaymentReminder> PaymentReminders { get; set; }
    // --- End New DbSets ---

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply all configurations
        ApplyConfigurations(builder);

        // Seed all data
        SeedAllData(builder);
    }

    private void ApplyConfigurations(ModelBuilder builder)
    {
        // Identity configurations
        builder.ApplyConfiguration(new RoleConfiguration());

        // Entity configurations
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new CourseStudentConfiguration());
        builder.ApplyConfiguration(new DepartmentConfiguration());
        builder.ApplyConfiguration(new EvaluationResponseConfiguration());
        builder.ApplyConfiguration(new FeeItemConfiguration());
        builder.ApplyConfiguration(new FinancialRecordConfiguration());
        builder.ApplyConfiguration(new GradeConfiguration());
        builder.ApplyConfiguration(new LecturerCourseConfiguration());
        builder.ApplyConfiguration(new LecturerEvaluationConfiguration());
        builder.ApplyConfiguration(new NotificationConfiguration());
        builder.ApplyConfiguration(new PaymentConfiguration());
        builder.ApplyConfiguration(new RegistrationPeriodConfiguration());
        builder.ApplyConfiguration(new ResearchContributorConfiguration());
        builder.ApplyConfiguration(new ResearchProjectConfiguration());
        builder.ApplyConfiguration(new ResourceBorrowingConfiguration());
        builder.ApplyConfiguration(new SemesterRecordConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new TranscriptConfiguration());
        
        // --- Configurations for New Entities ---
        builder.ApplyConfiguration(new InvoiceConfiguration());
        builder.ApplyConfiguration(new InvoiceLineItemConfiguration());
        builder.ApplyConfiguration(new PaymentGatewayTransactionConfiguration());
        builder.ApplyConfiguration(new PaymentReminderConfiguration());
        // --- End New Configurations --
    }

    private void SeedAllData(ModelBuilder builder)
    {
        //TODO: Recheck migrations
        
        // First tier - no foreign key dependencies
        SeedFaculties.Seed(builder);
        SeedUsers.Seed(builder);

        // Second tier - depend on first tier
        SeedDepartments.Seed(builder);
        SeedStudents.Seed(builder, SeedDepartments.DepartmentOfComputerScienceId);

        // Third tier - depend on second tier
        SeedCourses.Seed(
            builder,
            SeedDepartments.DepartmentOfComputerScienceId,
            SeedDepartments.DepartmentOfTheologicalStudiesId,
            SeedDepartments.DepartmentOfBbaAccountingId,
            SeedDepartments.DepartmentOfGeneralEducationId
        );
        SeedTranscripts.Seed(builder);
        SeedRegistrationPeriods.Seed(builder);
        SeedLecturers.Seed(builder);

        // Fourth tier - depends on third tier
        SeedSemesterRecords.Seed(builder); // Must come BEFORE Grades
        SeedCourseTimeSlots.Seed(builder);
        SeedLecturerCourses.Seed(builder);
        SeedCourseStudents.Seed(builder);

        // Fifth tier - Seed Grades IMMEDIATELY after SemesterRecords and Courses
        SeedGrades.Seed(builder); 

        // Sixth tier - financial data (no impact on Grades)
        SeedFinancialRecords.Seed(builder);
        SeedFeeItems.Seed(builder);
        SeedPayments.Seed(builder);

        // Rest of the seeds
        SeedEvaluationPeriods.Seed(builder);
        SeedLecturerEvaluations.Seed(builder, SeedCourses.Cs101CourseId);
        SeedEvaluationQuestions.Seed(builder);
        SeedEvaluationResponses.Seed(builder);
        SeedLibraryResources.Seed(builder);
        SeedResourceBorrowings.Seed(builder);
        SeedResearchProjects.Seed(builder);
        SeedResearchContributors.Seed(builder);
        SeedNotifications.Seed(builder);
    }
}