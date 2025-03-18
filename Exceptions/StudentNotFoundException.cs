namespace iSchool_Solution.Exceptions;

public class StudentNotFoundException : KeyNotFoundException
{
    public StudentNotFoundException(string studentID) : base($"Student with ID {studentID} not found.")
    {
    }
}