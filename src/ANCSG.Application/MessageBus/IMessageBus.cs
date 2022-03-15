using ANCSG.Domain.Messages.Events;
using System;

namespace ANCSG.Application.MessageBus
{
    public interface IMessageBus
    {
        void Publish<T>(string queue, T message, string exchange = null) where T : IntegrationEvent;

        void Subscribe<T>(string queue, Action<T> onMessage) where T : IntegrationEvent;
    }
}
