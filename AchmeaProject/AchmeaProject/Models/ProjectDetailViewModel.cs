using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Logic;
using Google.Apis.Drive.v3.Data;

namespace AchmeaProject.Models
{
    public class ProjectDetailViewModel
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public _Status Status { get; set; }
        public string CreationDate { get; set; }
        public List<EsaAspect> EsaAspects { get; set; }
        public List<SecurityRequirementProject> RequirementProject { get; set; }
        public List<SecurityRequirement> Requirements { get; set; }
        public List<User> Users { get; set; }
        public List<File> Files { get; set; }

        public ProjectDetailViewModel()
        {
            Files = new List<File>();
        }
    }
}
