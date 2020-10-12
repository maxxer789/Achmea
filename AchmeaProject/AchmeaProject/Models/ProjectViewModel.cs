using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string SearchTerm { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
    }
}
