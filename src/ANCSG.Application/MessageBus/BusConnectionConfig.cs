namespace ANCSG.Application.MessageBus
{
    public class BusConnectionConfig
    {
        public BusExchangeConfigs exchangeConfigs { get; }

        public BusQueueConfigs QueueConfigs { get; }

        public string RoutingKey { get; }

        public BusConnectionConfig(BusQueueConfigs queueConfigs, BusExchangeConfigs exchangeConfigs)
        {
            this.exchangeConfigs = exchangeConfigs;
            QueueConfigs = queueConfigs;
            RoutingKey = queueConfigs.Name;
        }

        public BusConnectionConfig(BusQueueConfigs queueConfigs, string routingKey, BusExchangeConfigs exchangeConfigs)
            : this(queueConfigs, exchangeConfigs)
        {
            RoutingKey = routingKey;
        }
    }
}
