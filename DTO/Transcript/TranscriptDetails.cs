namespace iSchool_Solution.Entities.DTO.Transcript;

public record TranscriptDetails(
    Guid TranscriptID,
    double CumulativeGPA,
    int TotalCreditsEarned,
    int CreditsAttempted,
    string AcademicStanding,
    string ExpectedGraduationTerm,
    int RemainingRequiredCredits,  
    double LastSemesterGPA,       
    double CurrentSemesterProjectedGPA, 
    bool CanRequestOfficialTranscript, 
    bool HasHolds,
    string HoldReason,                
    List<SemesterSummary> Semesters
);