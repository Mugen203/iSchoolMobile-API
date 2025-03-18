namespace iSchool_Solution.Entities.DTO.Transcript;

public record SemesterTranscriptDetails(
    Guid SemesterRecordID,
    string SemesterName,
    string AcademicYear,
    double SemesterGPA,
    int SemesterCredits,
    string SemesterStanding,
    List<TranscriptCourseDetails> Courses,
    bool HasOfficialReport,
    Guid? SemesterReportId
);
