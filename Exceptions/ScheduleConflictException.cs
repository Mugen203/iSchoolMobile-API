using static iSchool_Solution.Features.Courses.Conflicts.Models;

namespace iSchool_Solution.Exceptions;

/// <summary>
/// Custom exception for schedule conflicts
/// </summary>
public class ScheduleConflictException : InvalidOperationException
{
    public List<ScheduleConflict> Conflicts { get; }

    public ScheduleConflictException(string message, List<ScheduleConflict> conflicts) 
        : base(message)
    {
        Conflicts = conflicts;
    }
}