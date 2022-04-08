using ANCSG.Application.MessageBus.Enums;

namespace ANCSG.Application.MessageBus
{
    public sealed class BusExchangeConfigs
    {
        public string Name { get; }

        public EExchangeType Type { get; }

        public bool Durable { get; }

        public BusExchangeConfigs(EExchangeType type)
        {
            Name = string.Empty;
            Type = type;
            Durable = true;
        }

        public BusExchangeConfigs(string name, EExchangeType type, bool durable)
        {
            Name = name;
            Type = type;
            Durable = durable;
        }
    }
}
