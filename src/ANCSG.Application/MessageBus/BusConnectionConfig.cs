namespace ANCSG.Application.MessageBus
{
    public class BusConnectionConfig
    {
        public BusExchangeConfigs ExchangeConfigs { get; }

        public BusQueueConfigs QueueConfigs { get; }

        public string RoutingKey { get; }

        public BusConnectionConfig(BusQueueConfigs queueConfigs, string routingKey = null)
        {
            QueueConfigs = queueConfigs;
            RoutingKey = routingKey ?? queueConfigs.Name;
        }

        public BusConnectionConfig(BusExchangeConfigs exchangeConfigs, string routingKey = null)
        {
            this.ExchangeConfigs = exchangeConfigs;
            RoutingKey = routingKey ?? string.Empty;
        }

        public BusConnectionConfig(BusQueueConfigs queueConfigs, BusExchangeConfigs exchangeConfigs, string routingKey = null)
        {
            ExchangeConfigs = exchangeConfigs;
            QueueConfigs = queueConfigs;
            RoutingKey = routingKey ?? queueConfigs.Name;
        }
    }
}
