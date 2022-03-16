using ANCSG.Application.MessageBus;
using ANCSG.Domain.Messages.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ANCSG.Infra.MessageBus
{
    public class RabbitMqMessageBus : IMessageBus
    {
        private IModel _channel;

        public RabbitMqMessageBus(string connectionString)
        {
            ConfigureConnection(connectionString);
        }

        public void Publish<T>(string queue, T message, string exchange = null) where T : IntegrationEvent
        {
            CreateStructure(queue, exchange);

            string serializedContent = JsonSerializer.Serialize(message);
            var content = Encoding.UTF8.GetBytes(serializedContent);

            _channel.BasicPublish(exchange: exchange ?? "", routingKey: queue, basicProperties: null, body: content);
        }

        public void Subscribe<T>(string queue, Action<T> onMessage) where T : IntegrationEvent
        {
            CreateStructure(queue);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<T>(contentString);

                onMessage(message);

                _channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            };
            _channel.BasicConsume(queue, autoAck: false, consumer);
        }

        public void SubscribeAsync<T>(string queue, Func<T, Task> onMessage) where T : IntegrationEvent
        {
            CreateStructure(queue);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<T>(contentString);

                onMessage(message);

                _channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            };
            _channel.BasicConsume(queue, autoAck: false, consumer);
        }

        private void ConfigureConnection(string connectionString)
        {
            var connection = ConnectionFactory.CreateConnection(connectionString);
            _channel = connection.CreateModel();
        }

        private void CreateStructure(string queue, string exchange = null)
        {
            _channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            if (!string.IsNullOrEmpty(exchange))
            {
                _channel.ExchangeDeclare(exchange: exchange, type: "topic", durable: true);
                _channel.QueueBind(queue: queue, exchange: exchange, routingKey: queue);
            }
        }
    }
}
