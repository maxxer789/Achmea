using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Achmea.Core.Logic
{
    public class ProjectLogic
    {
        ProjectDAL projectDAL;

        readonly IProject _IUser;

        private List<ProjectModel> Projects;

        public ProjectLogic(IProject IUser)
        {
            projectDAL = new ProjectDAL();
            _IUser = IUser;

            Projects = projectDAL.GetProjects();
        }

            public void MakeNewProject(ProjectModel projectModel)
        {
            try
            {
                projectDAL.AddNewProject(projectModel);
                Projects = projectDAL.GetProjects();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public List<ProjectModel> GetProjects()
        {
            return new List<ProjectModel>(Projects);
        }

        public ProjectModel GetProject(int projectId)
        {
            return Projects.FirstOrDefault(x => x.GetProjectId() == projectId);
        }
    }
}
