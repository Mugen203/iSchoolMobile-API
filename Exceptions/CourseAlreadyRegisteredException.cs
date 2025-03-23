namespace iSchool_Solution.Exceptions;

public class CourseAlreadyRegisteredException : InvalidOperationException
{
    public string StudentId { get; }
    public string CourseId { get; }
    
    public CourseAlreadyRegisteredException(string studentId, string courseId)
        : base($"Student '{studentId}' is already registered for course '{courseId}'")
    {
        StudentId = studentId;
        CourseId = courseId;
    }
}