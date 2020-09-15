using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}