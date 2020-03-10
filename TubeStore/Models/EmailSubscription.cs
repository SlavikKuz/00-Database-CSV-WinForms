using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class EmailSubscription
    {
        [Key]
        public int EmailSubscriptionId { get; set; }
        
        public string Email { get; set; }

        //false unsibscribed
        public bool Status { get; set; }
    }
}
