namespace iSchool_Solution.Exceptions;

public class NotificationNotFoundException : KeyNotFoundException
{
    public NotificationNotFoundException(string notificationID, string studentID) : base($"Notification with ID {notificationID} not found for student ID: {studentID}")
    {
    }
    public NotificationNotFoundException(string notificationID) : base($"Notification with ID {notificationID} not found.")
    {
    }
}