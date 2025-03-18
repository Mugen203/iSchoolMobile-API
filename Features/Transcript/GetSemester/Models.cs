using iSchool_Solution.Enums;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Features.Transcript.GetSemester;

public class Models
{
    public class SemesterTranscriptResponse
    {
        public Guid SemesterRecordID { get; set; }
        public string SemesterName { get; set; } = string.Empty;
        public string AcademicYear { get; set; } = string.Empty;
        public double SemesterGPA { get; set; }
        public int SemesterCredits { get; set; }
        public AcademicStanding SemesterStanding { get; set; }
        public List<TranscriptCourseInfo> Courses { get; set; } = new(); // Reusing TranscriptCourseInfo
        public bool HasOfficialReport { get; set; }
        public Guid? SemesterReportId { get; set; }
    }
}