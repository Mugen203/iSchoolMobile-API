using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Courses.Register;

public class Models
{
    public class CourseRegistrationRequest
    {
        public List<string> CourseIDs { get; set; } = [];
    }

    public class RegistrationReceiptResponse
    {
        public Guid ReceiptID { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string StudentID { get; set; } = string.Empty;
        public List<RegisteredCourseDetails> RegisteredCourses { get; set; } = new();
        public decimal TotalFees { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public class RegisteredCourseDetails
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public decimal CourseFee { get; set; }
    }
}