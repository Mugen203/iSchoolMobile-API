namespace iSchool_Solution.Exceptions;

public class TranscriptNotFoundException : KeyNotFoundException
{
    public TranscriptNotFoundException(string studentID) : base($"Transcript not found for student with ID {studentID}.")
    {
    }
}