using System;
using System.Collections.Generic;
using System.Text;
using static UserModalNotifications.SupportModalClass;

namespace UserModalNotifications
{
    public interface IUserModalNotification
    {
        void AddNotificationToast(string text, NotificationType type, ToastModalOption options);
        void AddNotificationSweet(string title, NotificationType type, string text);
    }
}
