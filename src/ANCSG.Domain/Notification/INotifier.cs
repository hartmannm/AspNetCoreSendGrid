using System.Collections.Generic;

namespace ANCSG.Domain.Notification
{
    public interface INotifier
    {
        bool HasNotifications { get; }

        IReadOnlyCollection<Notification> Notifications { get; }

        void AddNotification(Notification notification);

        void AddNotification(string notificationMessage);
    }
}
