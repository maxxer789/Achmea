using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ActionViewModel
    {
        public string Title { get; set; }
        public int OpenActions { get; set; }
        public int Accepted { get; set; }
        public int Excluded { get; set; }

        public ActionViewModel()
        {

        }

        public ActionViewModel(string title, int openActions, int accepted, int excluded)
        {
            Title = title;
            OpenActions = openActions;
            Accepted = accepted;
            Excluded = excluded;
        }
    }
}
