namespace EventOne.Services;

public interface INotificationService
{
    Task SendNotification(string message);
}
