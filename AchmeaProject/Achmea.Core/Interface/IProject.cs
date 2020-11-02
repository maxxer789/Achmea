
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IProject
    {
        public void AddNewProject(string title, int ID);

        public IEnumerable<Project> GetProjects();

        public Project GetProject(int projectId);

        public List<EsaAspect> GetEsaForProject(int projectId);
    }
}
