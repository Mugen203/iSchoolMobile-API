namespace iSchool_Solution.Enums;

public enum GradeLetter
{
    A = 1,        // 4.00
    A_Minus = 2,  // 3.67
    B_Plus = 3,   // 3.33
    B = 4,        // 3.00
    B_Minus = 5,  // 2.67
    C_Plus = 6,   // 2.33
    C = 7,        // 2.00
    C_Minus = 8,  // 1.67
    D_Plus = 9,   // 1.33
    D = 10,       // 1.00
    F = 11,       // 0.00 (Fail)
    P = 12,       // Pass (no impact on GPA)
    NP = 13,      // No Pass (no impact on GPA)
    I = 14,       // Incomplete (no impact)
    W = 15,       // Withdrawn (no impact)
    NA = 16       // Not Available (default)
}

public static class GradeLetterExtensions
{
    public static double GetGradePoints(this GradeLetter grade)
    {
        return grade switch
        {
            GradeLetter.A => 4.00,
            GradeLetter.A_Minus => 3.67,
            GradeLetter.B_Plus => 3.33,
            GradeLetter.B => 3.00,
            GradeLetter.B_Minus => 2.67,
            GradeLetter.C_Plus => 2.33,
            GradeLetter.C => 2.00,
            GradeLetter.C_Minus => 1.67,
            GradeLetter.D_Plus => 1.33,
            GradeLetter.D => 1.00,
            GradeLetter.F => 0.00,
            _ => 0.00
        };
    }

    public static bool IsIncludedInGPA(this GradeLetter grade)
    {
        return grade switch
        {
            GradeLetter.A or GradeLetter.A_Minus or GradeLetter.B_Plus or 
                GradeLetter.B or GradeLetter.B_Minus or GradeLetter.C_Plus or 
                GradeLetter.C or GradeLetter.C_Minus or GradeLetter.D_Plus or 
                GradeLetter.D or GradeLetter.F => true,
            _ => false // P, NP, I, W, NA are not included
        };
    }
}