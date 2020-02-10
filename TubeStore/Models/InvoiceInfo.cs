using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class InvoiceInfo
    {
        public int InvoiceId { get; set; }
        public int TubeId { get; set; }
        public decimal Price { get; set; }
        public int Quntity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Tube Tube { get; set; }
    }
}
