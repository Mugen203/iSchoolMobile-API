using iSchool_Solution.Features.Courses.Conflicts;

namespace iSchool_Solution.Exceptions;

/// <summary>
/// Custom exception for schedule conflicts
/// </summary>
public class ScheduleConflictException : InvalidOperationException
{
    public List<Models.ScheduleConflict> Conflicts { get; }

    public ScheduleConflictException(string message, List<Models.ScheduleConflict> conflicts) 
        : base(message)
    {
        Conflicts = conflicts;
    }
}