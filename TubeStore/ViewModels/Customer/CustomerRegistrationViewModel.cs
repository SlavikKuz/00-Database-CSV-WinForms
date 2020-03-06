using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels.Customer
{
    public class CustomerRegistrationViewModel
    {
        [Display(Name = "Email")]
        [Required, EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool Agreement { get; set; }
    }
}
