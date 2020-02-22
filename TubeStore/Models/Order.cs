using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customers")]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Invoices")]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

        //shipping address for another person
        //for sake of feature, not useful
        //public CustomerDetailsViewModel OrderReceiver { get; set; }


    }
}
