using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ProjectViewModel
    {
        [AllowNull]
        public int ProjectId { get; set; }
        public string SearchTerm { get; set; }
        [Required]
        public string Title { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
