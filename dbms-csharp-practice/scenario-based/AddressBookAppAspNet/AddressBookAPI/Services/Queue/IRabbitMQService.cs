namespace AddressBookAPI.Services.Queue
{
    public interface IRabbitMQService
    {
        void PublishMessage(string queueName, string message);
        void ConsumeMessage(string queueName, Action<string> callback);
    }
}
