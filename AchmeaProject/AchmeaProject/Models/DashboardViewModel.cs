using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class DashboardViewModel
    {
        public UserViewModel Developer { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
        public List<ActionViewModel> Actions { get; set; } = new List<ActionViewModel>();
    }
}
