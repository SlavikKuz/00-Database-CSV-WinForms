using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Areas.Admin.ViewModels;

namespace TubeStore.ViewModels
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }

        public string Login { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        public string Phone { get; set; }

        public List<RoleViewModel> CustomerInRoles { get; set; }
        public bool IsLockedOut { get; set; }

    }
}
