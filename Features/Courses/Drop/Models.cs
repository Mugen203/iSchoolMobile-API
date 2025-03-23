namespace iSchool_Solution.Features.Courses.Drop;

public class Models
{
    public class DropCourseRequest
    {
        public string CourseCode { get; set; } = string.Empty;
    }
    
    public class DropCourseResponse
    {
        public bool Success { get; set; }
        public string CourseID { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime? DroppedAt { get; set; }
    }
}