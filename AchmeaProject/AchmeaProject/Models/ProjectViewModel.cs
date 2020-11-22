using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static AchmeaProject.Models.Project;

namespace AchmeaProject.Models
{
    public class ProjectViewModel
    {
        [AllowNull]
        public int ProjectId { get; set; }
        public string SearchTerm { get; set; }
        [Required]
        public string Title { get; set; }
        public string CreationDate { get; set; }
        [Required]
        public string Description { get; set; }
        public string[] Members { get; set; }

    }
}
