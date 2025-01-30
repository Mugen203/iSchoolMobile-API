namespace Domain.Entities;

public class LecturerEvaluation
{
    public Guid CourseId { get; set; }
    public int TeachingScore { get; set; }        // 1-5 rating
    public int CommunicationScore { get; set; }   // 1-5 rating
    public int MaterialScore { get; set; }        // 1-5 rating
    public string Comments { get; set; }
    public string Semester { get; set; }
    
    // Navigation property
    public Course Course { get; set; }
}