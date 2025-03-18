namespace iSchool_Solution.Features.Grade.GetCurrent;

public class Models
{
    public class CurrentGradesResponse
    {
        public List<CurrentCourseGradeInfo> CurrentCourses { get; set; } = new();
    }

    public class CurrentCourseGradeInfo
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public string CurrentGrade { get; set; } = string.Empty;
        public double GradeValue { get; set; }
    }
}