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

        public void Publish<T>(BusConnectionConfig connectionConfig, T message) where T : IntegrationEvent
        {
            DeclareExchange(connectionConfig.ExchangeConfigs);

            string serializedContent = JsonSerializer.Serialize(message);
            var content = Encoding.UTF8.GetBytes(serializedContent);

            _channel.BasicPublish(
                exchange: connectionConfig?.ExchangeConfigs?.Name ?? string.Empty,
                routingKey: connectionConfig.RoutingKey,
                basicProperties: null,
                body: content
            );
        }

        public void Subscribe<T>(BusConnectionConfig connectionConfig, Action<T> onMessage) where T : IntegrationEvent
        {
            DeclareQueue(connectionConfig);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<T>(contentString);

                onMessage(message);

                _channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            };
            _channel.BasicConsume(connectionConfig.QueueConfigs.Name, autoAck: false, consumer);
        }

        public void SubscribeAsync<T>(BusConnectionConfig connectionConfig, Func<T, Task> onMessage) where T : IntegrationEvent
        {
            DeclareQueue(connectionConfig);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonSerializer.Deserialize<T>(contentString);

                onMessage(message);

                _channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            };
            _channel.BasicConsume(connectionConfig.QueueConfigs.Name, autoAck: false, consumer);
        }

        private void ConfigureConnection(string connectionString)
        {
            var connection = ConnectionFactory.CreateConnection(connectionString);
            _channel = connection.CreateModel();
        }

        private void DeclareQueue(BusConnectionConfig connectionConfig)
        {
            _channel.QueueDeclare(
                queue: connectionConfig.QueueConfigs.Name,
                durable: connectionConfig.QueueConfigs.Durable,
                exclusive: connectionConfig.QueueConfigs.Exclusive,
                autoDelete: connectionConfig.QueueConfigs.AutoDelete,
                arguments: null
            );

            if (connectionConfig.ExchangeConfigs is not null)
            {
                DeclareExchange(connectionConfig.ExchangeConfigs);
                _channel.QueueBind(
                    queue: connectionConfig.QueueConfigs.Name,
                    exchange: connectionConfig.ExchangeConfigs.Name,
                    routingKey: connectionConfig.RoutingKey
                );
            }
        }

        private void DeclareExchange(BusExchangeConfigs configs)
        {
            if (configs is not null)
                _channel.ExchangeDeclare(
                    exchange: configs.Name,
                    type: configs.Type.ToString().ToLower(),
                    durable: configs.Durable
                );
        }
    }
}
