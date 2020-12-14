using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class UserSelectionViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string RoleId { get; set; }

        public UserSelectionViewModel()
        {

        }
        public UserSelectionViewModel(int userID, string name, string roleId)
        {
            UserID = userID;
            Name = name;
            RoleId = roleId;
        }
    }
}
