using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSectionHandler.Models
{
    public class User: IdentityUser
    {
        public virtual ICollection<ChatMessage> Comments { get; set; }
        public User()
        {
            Comments = new HashSet<ChatMessage>();
        }
    }
}
