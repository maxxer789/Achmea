using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AchmeaProject.Sessions;
using Microsoft.AspNetCore.Http;

namespace AchmeaProject.Models
{
    public class ProjectCreationDetailsViewModel
    {
        [Required]
        public string Title { get; set; }
        public string CreationDate { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
