namespace ANCSG.Application.MessageBus
{
    public sealed class BusQueueConfigs
    {
        public string Name { get; }

        public bool Durable { get; set; }

        public bool Exclusive { get; set; }

        public bool AutoDelete { get; set; }

        public BusQueueConfigs(string name)
        {
            Name = name;
        }
    }
}
