using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models.Chat;

namespace TubeStore.Models.Notification
{
    public class NotificationUser
    {
        [Key]
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public bool IsRead { get; set; } = false;
    }
}
