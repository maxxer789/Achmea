using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int PhoneNumber { get; set; }
        public string RoleID { get; set; }
    }
}
