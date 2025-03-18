namespace iSchool_Solution.Exceptions;

public class CourseNotFoundException : KeyNotFoundException
{
    public string StudentId { get; }
    public string CourseId { get; }
        
    public CourseNotFoundException(string studentId, string courseId)
        : base($"Course with ID '{courseId}' was not found for student '{studentId}'")
    {
        StudentId = studentId;
        CourseId = courseId;
    }
        
    public CourseNotFoundException(string studentId, string courseId, string message)
        : base(message)
    {
        StudentId = studentId;
        CourseId = courseId;
    }
}