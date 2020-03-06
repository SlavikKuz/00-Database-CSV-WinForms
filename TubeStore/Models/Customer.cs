using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models.Chat;
using TubeStore.Models.Notification;

namespace TubeStore.Models
{
    public class Customer:IdentityUser
    {
        [Display(Name = "First Name")]
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Address Line 1")]
        [Required, StringLength(100)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [Display(Name = "Zip Code")]
        [Required, StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        [Required, StringLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required, StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Country")]
        [Required, StringLength(50)]
        public string Country { get; set; } 

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Watchlist> Watchlists { get; set; }
        public virtual ICollection<NotificationUser> NotificationUsers { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }


    }
}
