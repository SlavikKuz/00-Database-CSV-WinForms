using System;
using System.Collections.Generic;
using System.Text;
using static UserNotifications.SupportClass;

namespace UserNotifications
{
    public interface IUserNotification
    {
        void AddNotificationToast(string text, NotificationType type, ToastOption options);
        void AddNotificationSweet(string title, NotificationType type, string text);
    }
}
