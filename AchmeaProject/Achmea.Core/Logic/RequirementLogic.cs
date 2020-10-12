using Achmea.Core.Interface;
using Achmea.Core.Model;
using Achmea.Core.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Achmea.Core.Logic
{
    public class RequirementLogic
    {
        RequirementDAL requirementDAL;

        private List<RequirementModel> Requirements;


        public RequirementLogic()
        {
            requirementDAL = new RequirementDAL();

            Requirements = requirementDAL.GetRequirements();
        }

        public List<RequirementModel> GetRequirements()
        {
            return new List<RequirementModel>(Requirements);
        }

        public RequirementModel GetRequirement(int requirementId)
        {
            return Requirements.FirstOrDefault(x => x.GetId() == requirementId);
        }

        public List<RequirementModel> GetRequirementsForProject(int projectId)
        {
            List<RequirementProject> requirementProjects = new List<RequirementProject>();
            requirementProjects = requirementDAL.GetRequirementsForProject(projectId);

            List<RequirementModel> list = new List<RequirementModel>();
            foreach(RequirementProject reqproject in requirementProjects)
            {
                RequirementModel model = Requirements.FirstOrDefault(x => x.GetId() == reqproject.getReqId());
                list.Add(model);
            }
            return list;
        }

        public List<string> GetStatuses(int projectId)
        {
            List<RequirementProject> requirementProjects = new List<RequirementProject>();
            requirementProjects = requirementDAL.GetRequirementsForProject(projectId);

            List<string> list = new List<string>();
            foreach (RequirementProject reqproject in requirementProjects)
            {
                string status = reqproject.GetStatus();
                list.Add(status);
            }
            return list;

        }
    }
}
