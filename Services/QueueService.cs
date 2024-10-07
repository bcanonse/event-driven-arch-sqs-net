using System.Net;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace EventOne.Services;

internal class QueueService(IAmazonSQS sqsClient, IConfiguration configuration) : IQueueService
{
    private readonly string QueueUrl = configuration.GetValue<string>("AWS:QueueUrl") ?? string.Empty;
    public async Task<bool> SendMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException("No message to send");
        }

        var messageRequest = new SendMessageRequest()
        {
            QueueUrl = QueueUrl,
            MessageBody = message
        };

        var response = await sqsClient.SendMessageAsync(messageRequest);

        return response.HttpStatusCode != HttpStatusCode.OK;
    }
}