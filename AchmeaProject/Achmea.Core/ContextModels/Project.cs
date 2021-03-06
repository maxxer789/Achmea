﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AchmeaProject.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectEsaAspect = new HashSet<ProjectEsaAspect>();
            SecurityRequirementProject = new HashSet<SecurityRequirementProject>();
        }

        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }


        public Project(int projectId, int userId, string title, string description)
        {
            ProjectId = projectId;
            UserId = userId;
            Title = title;
            Description = description;
            CreationDate = DateTime.Now;
        }

        public Project(int projectId, int userId, string title, string description, DateTime creationDate)
        {
            ProjectId = projectId;
            UserId = userId;
            Title = title;
            Description = description;
            CreationDate = creationDate;
        }

        public virtual User User { get; set; }
        public virtual ICollection<ProjectEsaAspect> ProjectEsaAspect { get; set; }
        public virtual ICollection<SecurityRequirementProject> SecurityRequirementProject { get; set; }
    }
}
