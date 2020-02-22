using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
       
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; } 

        public int ShippingAddressId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

        public virtual ICollection<InvoiceInfo> InvoicesInfo { get; set; } 
            = new HashSet<InvoiceInfo>();
    }
}
