using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TubeStore.Models.Cart;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Status")]
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

        [Display(Name = "Total")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { get; set; }
    }
}
