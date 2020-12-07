using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AchmeaProject.Models
{
    public class CommentViewModel
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public int ProjectReqId { get; set; }
        public DateTime? PostDateTime { get; set; }
    }
}