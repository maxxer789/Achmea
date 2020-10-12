using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IProject
    {
        public void AddNewProject(string title, int ID);

        public List<ProjectModel> GetProjects();

        public ProjectModel GetProject(int projectId);
    }
}
