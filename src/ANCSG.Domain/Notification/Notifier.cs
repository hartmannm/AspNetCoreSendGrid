using System.Collections.Generic;
using System.Linq;

namespace ANCSG.Domain.Notification
{
    public sealed class Notifier : INotifier
    {
        private ICollection<Notification> _notifications;

        public bool HasNotifications => _notifications.Any();

        public IReadOnlyCollection<Notification> Notifications => _notifications.ToList().AsReadOnly();

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            if (!_notifications.Contains(notification))
                _notifications.Add(notification);
        }

        public void AddNotification(string notificationMessage)
        {
            if (!_notifications.Any(n => n.Message.Equals(notificationMessage)))
                _notifications.Add(new Notification(notificationMessage));
        }
    }
}
