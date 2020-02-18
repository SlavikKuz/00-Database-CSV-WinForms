using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels
{
    public class CustomerRegistrationViewModel
    {
        [Display(Name="Login")]
        [Required, MaxLength(16)]
        public string Login { get; set; }        
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        [Required]
        public bool Agreement { get; set; }
    }
}
