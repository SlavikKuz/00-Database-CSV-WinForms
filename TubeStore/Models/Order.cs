using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }

        //shipping address
        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter your Zip Code")]
        [Display(Name = "Zip Code")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        [Display(Name = "Country")]
        [StringLength(50)]
        public string Coutry { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [Display(Name = "Phone Number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
