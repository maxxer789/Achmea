using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class FileOfProof
    {
        public FileOfProof()
        {
            Comment = new HashSet<Comment>();
        }

        public int FileOfProofId { get; set; }
        public string DocumentTitle { get; set; }
        public string FileLocation { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
    }
}
