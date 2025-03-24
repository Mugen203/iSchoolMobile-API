using iSchool_Solution.Enums;

namespace iSchool_Solution.Exceptions;

public class SemesterRecordNotFoundException : KeyNotFoundException
{
    public string StudentId { get; }
    public Semester? Semester { get; }
    public string? AcademicYear { get; }
    public Guid? SemesterRecordId { get; }

    public SemesterRecordNotFoundException(string studentID, Semester semester, int year) 
        : base($"Semester record not found for student '{studentID}', semester {semester}, academic year {year}-{year + 1}.")
    {
        StudentId = studentID;
        Semester = semester;
        AcademicYear = $"{year}-{year + 1}";
    }
    
    public SemesterRecordNotFoundException(string studentID, Semester semester) 
        : base($"Semester record not found for student '{studentID}', semester {semester}.")
    {
        StudentId = studentID;
        Semester = semester;
    }
    
    public SemesterRecordNotFoundException(string studentID, string academicYear, Semester semester)
        : base($"Semester record not found for student '{studentID}', semester {semester}, academic year {academicYear}.")
    {
        StudentId = studentID;
        Semester = semester;
        AcademicYear = academicYear;
    }
    
    public SemesterRecordNotFoundException(string studentID, Guid semesterRecordID)
        : base($"Semester record with ID '{semesterRecordID}' not found for student '{studentID}'.")
    {
        StudentId = studentID;
        SemesterRecordId = semesterRecordID;
    }
    
    public SemesterRecordNotFoundException(string message) : base(message)
    {
    }
    
    public SemesterRecordNotFoundException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}