using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ESA_AspectViewModel
    {
        [BindProperty]
        public int ID { get; }
        public string Title { get; }
        public string Description { get; }

        public ESA_AspectViewModel(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }
    }
}
