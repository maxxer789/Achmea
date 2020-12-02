using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchmeaProject.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Project = new HashSet<Project>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int PhoneNumber { get; set; }
        public string RoleId { get; set; }



        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
