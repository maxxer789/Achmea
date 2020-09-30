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

        public ProjectModel(int projectId, int userId, string title, string description, string status)
        {
            ProjectId = projectId;
            UserId = userId;
            Title = title;
            Description = description;
            Status = status;
            CreationDate = DateTime.Now;
        }

        public string GetTitle()
        {
            return Title;
        }

        public int GetUser()
        {
            return UserId;
        }

        public string GetStatus()
        {
            return Status;
        }

        public DateTime GetDate()
        {
            CreationDate = DateTime.UtcNow;

            return CreationDate;
        }

        public string GetDescription()
        {

            return Description;
        }

    }
}
