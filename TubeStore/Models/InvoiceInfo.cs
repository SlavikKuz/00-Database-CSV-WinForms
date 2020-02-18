using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class InvoiceInfo
    {
        public int InvoiceInfoId { get; set; }
        public int TubeId { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Tube Tube { get; set; }
    }
}
