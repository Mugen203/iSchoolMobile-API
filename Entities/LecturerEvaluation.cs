using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSchool_Solution.Entities;

public class LecturerEvaluation
{
    public LecturerEvaluation()
    {
        Responses = new List<EvaluationResponse>();
    }

    [Key] public int Id { get; set; }

    [ForeignKey(nameof(EvaluationPeriod))] public int EvaluationPeriodID { get; set; }

    public EvaluationPeriod EvaluationPeriod { get; set; }

    [ForeignKey(nameof(Course))] public Guid? CourseID { get; set; }

    public Course Course { get; set; }

    [ForeignKey(nameof(Lecturer))] public string LecturerID { get; set; }

    public Lecturer Lecturer { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset SubmissionDate { get; set; }

    public string Comments { get; set; }

    // Navigation Property
    public virtual IList<EvaluationResponse> Responses { get; set; }
}