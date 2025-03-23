namespace iSchool_Solution.Exceptions;

public class CourseNotFoundException : KeyNotFoundException
{
    public string StudentId { get; }
    public string CourseId { get; }
        
    public CourseNotFoundException(string studentID, string courseID)
        : base($"Course with ID '{courseID}' was not found for student '{studentID}'")
    {
        StudentId = studentID;
        CourseId = courseID;
    }
        
    public CourseNotFoundException(string studentId, string courseId, string message)
        : base(message)
    {
        StudentId = studentId;
        CourseId = courseId;
    }

    public CourseNotFoundException(string courseID) : base($"Course with ID '{courseID}' was not found")
    {
    }
}