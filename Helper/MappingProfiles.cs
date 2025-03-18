using AutoMapper;
using iSchool_Solution.DTO.Authentication;
using iSchool_Solution.DTO.Dashboard;
using iSchool_Solution.DTO.Student;
using iSchool_Solution.Entities;
using iSchool_Solution.Entities.DTO.Course;
using iSchool_Solution.Entities.DTO.Dashboard;
using iSchool_Solution.Entities.DTO.Department;
using iSchool_Solution.Entities.DTO.Faculty;
using iSchool_Solution.Entities.DTO.FinanceManagement;
using iSchool_Solution.Entities.DTO.Grade;
using iSchool_Solution.Entities.DTO.Lecturer;
using iSchool_Solution.Entities.DTO.LecturerEvaluation;
using iSchool_Solution.Entities.DTO.Library;
using iSchool_Solution.Entities.DTO.Notification;
using iSchool_Solution.Entities.DTO.RegistrationPeriod;
using iSchool_Solution.Entities.DTO.Research;
using iSchool_Solution.Entities.DTO.Transcript;
using Lecturer = iSchool_Solution.Entities.Lecturer;

namespace iSchool_Solution.Helper;

// TODO: Review
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApiUser, AuthResponse>().ReverseMap();
        CreateMap<Student, StudentSummary>().ReverseMap();
        CreateMap<Student, StudentProfileResponse>().ReverseMap();
        CreateMap<ApiUser, StudentSummary>().ReverseMap();
        CreateMap<ApiUser, StudentProfileResponse>().ReverseMap();
        CreateMap<UpdateProfileRequest, ApiUser>().ReverseMap();
        CreateMap<UpdateProfileRequest, Student>().ReverseMap();
        CreateMap<ApiUser, DashboardSummary>().ReverseMap();
        CreateMap<Student, DashboardSummary>().ReverseMap();
        
        CreateMap<Course, CourseListItem>().ReverseMap();
        CreateMap<Course, CourseDetails>().ReverseMap();
        CreateMap<ScheduleItem, DailySchedule>().ReverseMap();
        
        CreateMap<Lecturer, LecturerDetails>().ReverseMap();
        
        CreateMap<Department, DepartmentSummary>().ReverseMap();
        CreateMap<Department, DepartmentDetails>().ReverseMap();
        
        CreateMap<Faculty, FacultySummary>().ReverseMap();
        CreateMap<Faculty, FacultyDetails>().ReverseMap();
        
        CreateMap<Transcript, TranscriptDetails>().ReverseMap();
        CreateMap<SemesterRecord, SemesterSummary>().ReverseMap();
        CreateMap<Grade, CourseGrade>().ReverseMap();
        CreateMap<SemesterRecord, SemesterProgress>().ReverseMap();
        CreateMap<SemesterRecord, SemesterTranscriptDetails>().ReverseMap();
        CreateMap<Course, TranscriptCourseDetails>().ReverseMap()
            ;
        CreateMap<EvaluationPeriod, EvaluationPeriodSummary>().ReverseMap();
        CreateMap<EvaluationQuestion, EvaluationQuestionDetails>().ReverseMap();
        CreateMap<EvaluationResponse, QuestionResponse>().ReverseMap();
        CreateMap<SubmitEvaluation, LecturerEvaluationDetails>().ReverseMap();
        CreateMap<RegistrationPeriod, RegistrationPeriodSummary>().ReverseMap();
        CreateMap<RegistrationPeriod, RegistrationPeriodDetails>().ReverseMap();
        CreateMap<CourseRegistrationRequest, CourseStudent>().ReverseMap();
        
        CreateMap<ResearchProject, ResearchProjectListItem>().ReverseMap();
        CreateMap<ResearchContributor, ContributorSummary>().ReverseMap();
        CreateMap<CreateResearchProject, ResearchProject>().ReverseMap();
        CreateMap<ResearchProject, ResearchProjectDetails>().ReverseMap();
        CreateMap<ResearchContributor, ResearchProjectContributorDetails>().ReverseMap();
        CreateMap<ResearchDocument, ResearchProjectDocumentDetails>().ReverseMap();
        CreateMap<UploadResearchDocumentRequest, ResearchDocument>().ReverseMap();
        
        CreateMap<FeeItem, FeeItemSummary>().ReverseMap();
        CreateMap<FinancialRecord, FinancialSummary>().ReverseMap();
        CreateMap<Payment, PaymentSummary>().ReverseMap();
        CreateMap<MakePaymentRequest, Payment>().ReverseMap();
        
        CreateMap<LibraryResource, LibraryResourceSummary>().ReverseMap();
        CreateMap<ResourceBorrowing, BorrowingHistory>().ReverseMap();
        CreateMap<ResourceBorrowRequest, ResourceBorrowing>().ReverseMap();
        
        CreateMap<Notification, NotificationSummary>().ReverseMap();
        CreateMap<MarkNotificationReadRequest, Notification>().ReverseMap();
        
        CreateMap<Grade, GradeDetails>().ReverseMap();
    }
}