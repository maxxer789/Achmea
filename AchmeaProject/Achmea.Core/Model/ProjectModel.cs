using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Achmea.Core.Model
{
    public class ProjectModel
    {
        private int ProjectId { get; set; }
        private int UserId { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private string Status { get; set; }
        private DateTime CreationDate { get; set; }
    }
}
