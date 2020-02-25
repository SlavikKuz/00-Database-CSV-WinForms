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
        public EnumStatus Status { get; set; }

        [ForeignKey("Customers")]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; } 

        public int ShippingAddressId { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

        [ForeignKey("Coupons")]
        public int? CouponId { get; set; }
        public virtual Coupon Coupon { get; set; }

        public virtual List<InvoiceInfo> InvoicesInfo { get; set; } = new List<InvoiceInfo>();

        public decimal Total { get; set; }
    }
}
