using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using static Petar_Tsvetkov_Blog.Models.AplicationUser;

namespace Petar_Tsvetkov_Blog.Models
{
    public class EditUserViewModel
    {
        public AplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]

        [Compare("Password", ErrorMessage = "Password does not match.")]

        public string ConfirmPassword { get; set; }

        public List<Role> Roles { get; set; }
    }
}