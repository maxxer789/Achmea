using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fill in Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill in Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
