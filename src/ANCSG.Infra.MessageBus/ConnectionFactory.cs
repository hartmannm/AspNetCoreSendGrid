namespace ANCSG.Infra.MessageBus
{
    public class ConnectionFactory
    {
        private static RabbitMQ.Client.IConnection connection;

        public static RabbitMQ.Client.IConnection CreateConnection(string connectionString)
        {
            if (connection is not null)
                return connection;

            var connectionFactory = new RabbitMQ.Client.ConnectionFactory();
            connectionFactory.Uri = new Uri(connectionString);
            connection = connectionFactory.CreateConnection();

            return connection;
        }
    }
}
