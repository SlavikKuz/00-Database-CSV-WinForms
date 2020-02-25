using System.ComponentModel.DataAnnotations;

namespace TubeStore.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public decimal CouponValue { get; set; }
        public EnumCoupon CouponStatus { get; set; }
    }
}