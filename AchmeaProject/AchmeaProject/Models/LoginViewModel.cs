using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email is missing.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill in the password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
