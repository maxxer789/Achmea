using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class ProjectLogic
    {
        ProjectDAL projectDAL;

        readonly IProject _IUser;

        public ProjectLogic(IProject IUser)
        {
            projectDAL = new ProjectDAL();
            _IUser = IUser;

        }

            public void MakeNewProject(ProjectModel projectModel)
        {
            try
            {
                projectDAL.AddNewProject(projectModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

    }
}
