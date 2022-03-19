﻿using System.Collections.Generic;

namespace ANCSG.Application.Notification
{
    public interface INotifier
    {
        bool HasNotifications { get; }

        IReadOnlyCollection<Domain.Notification.Notification> Notifications { get; }

        void AddNotification(Domain.Notification.Notification notification);

        void AddNotifications(ICollection<Domain.Notification.Notification> notifications);

        void AddNotification(string notificationMessage);
    }
}
