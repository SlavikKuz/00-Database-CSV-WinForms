using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TubeStore.Models.Cart
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        
        [Display(Name = "Coupon")]
        [StringLength(10)]
        public string CouponName { get; set; }
        
        [Display(Name = "Coupon Value, 0.01")]
        [Column(TypeName = "decimal(3,2)")]
        [Range(0, 0.99)]
        public decimal CouponValue { get; set; }

        [Display(Name = "Status")]
        public EnumCoupon CouponStatus { get; set; }
    }
}