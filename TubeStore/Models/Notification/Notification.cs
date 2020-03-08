using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models.Notification
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationText { get; set; }
        public List<NotificationUser> NotificationUsers { get; set; }
    }
}
