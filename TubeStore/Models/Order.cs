using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }

        //shipping address for another person
        //for sake of feature, not useful
        //public CustomerDetailsViewModel OrderReceiver { get; set; }


    }
}
