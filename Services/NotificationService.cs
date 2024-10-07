using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace EventOne.Services;

internal sealed class NotificationService(
    IConfiguration configuration,
    IAmazonSimpleNotificationService simpleNotificationService
) : INotificationService
{

    private readonly string TopicArn = configuration.GetValue<string>("AWS:TopicARN") ?? string.Empty;

    public Task SendNotification(string message)
    {
        var request = new PublishRequest
        {
            Message = message,
            TopicArn = TopicArn
        };

        return simpleNotificationService.PublishAsync(request);
    }
}