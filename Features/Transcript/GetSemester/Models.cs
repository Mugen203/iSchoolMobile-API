using System.Text.Json.Serialization;
using iSchool_Solution.Enums;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Features.Transcript.GetSemester;

public class Models
{
    public class SemesterTranscriptRequest
    {
        public string StudentID { get; set; } = string.Empty;
    
        // Only for system use
        public Guid? SemesterID { get; set; }
        public string AcademicYear { get; set; } = string.Empty; 
        public Semester Semester { get; set; }
    }
    
    public class SemesterTranscriptResponse
    {
        public Guid SemesterRecordID { get; set; }
        public string SemesterName { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public double SemesterGPA { get; set; }
        public int SemesterCredits { get; set; }
        public AcademicStanding SemesterStanding { get; set; }
        public List<TranscriptCourseInfo> Courses { get; set; } = []; 
        public bool HasOfficialReport { get; set; }
        public Guid? SemesterReportId { get; set; }
    }
}