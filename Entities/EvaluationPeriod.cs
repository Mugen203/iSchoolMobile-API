﻿using System.ComponentModel.DataAnnotations;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class EvaluationPeriod
{
    public EvaluationPeriod()
    {
        Evaluations = new List<LecturerEvaluation>();
    }

    [Key] public int Id { get; set; }

    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Academic year must be in format YYYY-YYYY")]
    public string AcademicYear { get; set; }

    public Semester Semester { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset StartDate { get; set; }

    [DataType(DataType.Date)] public DateTimeOffset EndDate { get; set; }

    public bool IsActive { get; set; }

    public string Description { get; set; }

    // Navigation Property
    public virtual IList<LecturerEvaluation> Evaluations { get; set; }
}