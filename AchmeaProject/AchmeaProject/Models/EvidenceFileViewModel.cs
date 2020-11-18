using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class EvidenceFileViewModel
    {
        public FileList List { get; set; }
        public File File { get; set; }

        public EvidenceFileViewModel()
        {
            List = new FileList();
        }
    }
}
