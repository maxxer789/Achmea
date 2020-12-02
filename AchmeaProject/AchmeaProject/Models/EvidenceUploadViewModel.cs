using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class EvidenceUploadViewModel
    {
        public int SecurityRequirementProjectID { get; set; }
        public IFormFile File { get; set; }
    }
}
