namespace iSchool_Solution.Features.Courses.GetCourses;

public class Models
{
    public class CourseListResponse
    {
        public List<CourseItem> Courses { get; set; } = [];
        public int TotalCourses { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
    }
    
    public class CourseListRequest
    {
        public string? DepartmentId { get; set; }
        public string? Semester { get; set; }
        public int? AcademicYear { get; set; }
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }
    
    public class CourseItem
    {
        public Guid CourseID { get; set; } 
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string Department { get; set; } = string.Empty;
        public int EnrollmentCount { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsAvailable { get; set; }
        public List<string> Schedule { get; set; } = [];
    }
}
