using ANCSG.Domain.Messages.Events;
using System;
using System.Threading.Tasks;

namespace ANCSG.Application.MessageBus
{
    public interface IMessageBus
    {
        void Publish<T>(BusConnectionConfig connectionConfig, T message) where T : IntegrationEvent;

        void Subscribe<T>(BusConnectionConfig connectionConfig, Action<T> onMessage) where T : IntegrationEvent;

        void SubscribeAsync<T>(BusConnectionConfig connectionConfig, Func<T, Task> onMessage) where T : IntegrationEvent;
    }
}
