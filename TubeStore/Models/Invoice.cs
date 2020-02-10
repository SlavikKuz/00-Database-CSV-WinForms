using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        //public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceInfo> InvoicesInfo { get; set; } 
            = new HashSet<InvoiceInfo>();
    }
}
