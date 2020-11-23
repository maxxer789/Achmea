using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchmeaTestss.MockServices
{
    class MockRequirementDAL : IRequirement
    {
        private List<SecurityRequirement> Requirements = new List<SecurityRequirement>();

        public MockRequirementDAL()
        {
            List<EsaAreaRequirement> esaAreaReq1 = new List<EsaAreaRequirement>();

            Requirements.Add(new SecurityRequirement()
            {
                RequirementId = 0,
                Name = "Requirement 0",
                Description = "Dit is requirement 0",
                Details = "Extra info over requirement 0",
                Family = "AO",
                MainGroup = "5",
                RequirementNumber = "AO1",
            });
            Requirements.Add(new SecurityRequirement()
            {
                RequirementId = 1,
                Name = "Requirement 1",
                Description = "Dit is requirement 1",
                Details = "Extra info over requirement 1",
                Family = "AO",
                MainGroup = "7",
                RequirementNumber = "AO2"
            });
            Requirements.Add(new SecurityRequirement()
            {
                RequirementId = 2,
                Name = "Requirement 2",
                Description = "Dit is requirement 2",
                Details = "Extra info over requirement 2",
                Family = "AT",
                MainGroup = "9",
                RequirementNumber = "AT1"
            });
        }

        public List<SecurityRequirement> GetAllRequirements()
        {
            return Requirements;
        }

        public SecurityRequirement GetRequirementById(int Id)
        {
            return Requirements.Find(req => req.RequirementId == Id);
        }

        public IEnumerable<SecurityRequirement> GetRequiermentsFromAreas(List<EsaAspect> aspects)
        {
            return new List<SecurityRequirement>();
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            return new List<SecurityRequirement>();
        }

        public IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, Project project)
        {
            return new List<SecurityRequirementProject>();
        }

        public SecurityRequirement ExcludeRequirement(int requirementId, int projectId, string reason)
        {
            return new SecurityRequirement();
        }

        public SecurityRequirement CreateRequirement(SecurityRequirement req, List<int> bivIds, List<int> areaIds)
        {
            return new SecurityRequirement();
        }
    }
}
