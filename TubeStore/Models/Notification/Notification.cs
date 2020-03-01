using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models.Notification
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationText { get; set; }
        public List<NotificationUser> NotificationUsers { get; set; }
    }
}
