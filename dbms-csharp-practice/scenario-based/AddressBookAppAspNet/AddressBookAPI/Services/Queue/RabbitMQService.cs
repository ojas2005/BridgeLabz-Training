using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using AddressBookAPI.Services.Logging;
using System.Text;

namespace AddressBookAPI.Services.Queue
{
    public class RabbitMQService : IRabbitMQService, IDisposable
    {
        private IConnection? _connection;
        private IModel? _channel;
        private readonly IApplicationLogger _logger;

        public RabbitMQService(IApplicationLogger logger)
        {
            _logger = logger;
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _logger.LogInfo("RabbitMQ connection established");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to connect to RabbitMQ", ex);
            }
        }

        public void PublishMessage(string queueName, string message)
        {
            try
            {
                if (_channel == null)
                {
                    _logger.LogError("RabbitMQ channel is not initialized");
                    return;
                }

                _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                
                _logger.LogInfo($"Message published to queue {queueName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to publish message to queue {queueName}", ex);
            }
        }

        public void ConsumeMessage(string queueName, Action<string> callback)
        {
            try
            {
                if (_channel == null)
                {
                    _logger.LogError("RabbitMQ channel is not initialized");
                    return;
                }

                _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        callback(message);
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error processing message from queue {queueName}", ex);
                    }
                };

                _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
                _logger.LogInfo($"Consumer listening to queue {queueName}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to consume message from queue {queueName}", ex);
            }
        }

        public void Dispose()
        {
            try
            {
                _channel?.Close();
                _connection?.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error disposing RabbitMQ connections", ex);
            }
        }
    }
}