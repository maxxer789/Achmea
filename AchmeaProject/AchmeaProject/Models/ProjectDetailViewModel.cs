using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ProjectDetailViewModel
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
        public List<EsaAspect> EsaAspects { get; set; }
        //h
    }
}
