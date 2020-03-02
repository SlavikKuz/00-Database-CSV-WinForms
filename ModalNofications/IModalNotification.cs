using System;
using System.Collections.Generic;
using System.Text;
using static ModalNofications.SupportModalClass;

namespace ModalNofications
{
    public interface IModalNotification
    {
        void AddNotificationToast(string text, NotificationType type, ToastModalOptions options);
        void AddNotificationSweet(string title, NotificationType type, string text);
    }
}
