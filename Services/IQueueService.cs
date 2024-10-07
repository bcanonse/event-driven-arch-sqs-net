namespace EventOne.Services;

public interface IQueueService
{
    Task<bool> SendMessage(string message);
}