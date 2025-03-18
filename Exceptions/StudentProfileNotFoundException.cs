namespace iSchool_Solution.Exceptions;

public class StudentProfileNotFoundException : KeyNotFoundException
{
    public string StudentId { get; }
        
    public StudentProfileNotFoundException() 
        : base("Student profile was not found")
    {
    }
        
    public StudentProfileNotFoundException(string message) 
        : base(message)
    {
    }
        
    public StudentProfileNotFoundException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
        
    public StudentProfileNotFoundException(string studentId, string message = null) 
        : base(message ?? $"Student profile with ID '{studentId}' was not found")
    {
        StudentId = studentId;
    }
}