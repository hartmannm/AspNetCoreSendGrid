using System;

namespace ANCSG.Domain.Messages.Events
{
    public abstract class Event
    {
        public DateTime CreatedAt { get; }

        public Event()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
