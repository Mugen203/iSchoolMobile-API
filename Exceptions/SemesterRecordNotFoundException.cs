using iSchool_Solution.Enums;

namespace iSchool_Solution.Exceptions;

public class SemesterRecordNotFoundException : KeyNotFoundException
{
    public SemesterRecordNotFoundException(string studentID, Semester semester, int year) : base($"Semester record not found for student with ID {studentID}, semester {semester}, year {year}.")
    {
    }
}