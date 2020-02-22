using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class ShippingAddress
    {
        [Key]
        public int ShoppingAdressId { get; set; }
        
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(50)]
        public string State { get; set; }

        [Display(Name = "Country")]
        [StringLength(50)]
        public string Country { get; set; }

        [ForeignKey("Customers")]
        public string CustomerId { get; set; }
    }
}
