using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ANCSG.Application.Notification
{
    public sealed class Notifier : INotifier
    {
        private ICollection<Domain.Notification.Notification> _notifications;

        public bool HasNotifications => _notifications.Any();

        public IReadOnlyCollection<Domain.Notification.Notification> Notifications => _notifications.ToList().AsReadOnly();

        public Notifier()
        {
            _notifications = new List<Domain.Notification.Notification>();
        }

        public void AddNotification(Domain.Notification.Notification notification)
        {
            if (!_notifications.Contains(notification))
                _notifications.Add(notification);
        }

        public void AddNotification(string notificationMessage)
        {
            if (!_notifications.Any(n => n.Message.Equals(notificationMessage)))
                _notifications.Add(new Domain.Notification.Notification(notificationMessage));
        }

        public void AddNotifications(ICollection<Domain.Notification.Notification> notifications)
        {
            _notifications = _notifications.Union(notifications).ToList();
        }
    }
}
