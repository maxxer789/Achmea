using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Achmea.Core.Interface
{
    public interface IProject
    {
        //public void AddNewProject(string title, int ID);

        //public List<ProjectModel> Search(string SearchTerm);
        public IEnumerable<Project> GetProjects();

        public Project GetProject(int projectId);

        //public ProjectModel GetProject(int projectId);
    }
}
