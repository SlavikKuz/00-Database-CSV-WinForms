using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }

        private string CustomerFirstName { get; set; }
        private string CustomerLastName { get; set; }

        public string CustomerFullName
        {
            get
            {
                return CustomerFirstName + " " + CustomerLastName;
            }
        }

        //public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceInfo> InvoicesInfo { get; set; } 
            = new HashSet<InvoiceInfo>();
    }
}
