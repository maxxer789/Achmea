using Achmea.Core.Interface;
using AchmeaProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace AchmeaTestss.MockServices
{
    class MockRequirementDAL : IRequirement
    {
        private List<SecurityRequirement> Requirements = new List<SecurityRequirement>();
        private List<EsaAreaRequirement> esaAreaReq = new List<EsaAreaRequirement>();
        private List<EsaAspectArea> esaAspArea = new List<EsaAspectArea>();
        private List<BIVRequirement> bivRequirements = new List<BIVRequirement>();

        public MockRequirementDAL()
        {
            Populate();
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
            List<EsaArea> Areas = new List<EsaArea>();
            foreach (EsaAspect asp in aspects)
            {
                Areas.AddRange(esaAspArea.Where(ea => ea.EsaAspectId == asp.AspectId).Select(ee => ee.EsaArea));
            }

            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            foreach (EsaArea area in Areas)
            {
                requirements.AddRange(esaAreaReq.Where(ear => ear.EsaAreaId == area.AreaId).Select(req => req.Requirement));
            }

            return requirements;
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            foreach (Biv classification in classifications)
            {
                requirements.AddRange(bivRequirements.Where(br => br.BivId == classification.Id).Select(brr => brr.SecurityRequirement));
            }

            return requirements;
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
            Requirements.Add(req);
            return req;
        }

        private void Populate()
        {
            #region Aspects
            EsaAspect aspect0 = new EsaAspect()
            {
                AspectId = 0,
                Description = "Aspectgebied 0",
                Name = "Aspect 0"
            };
            EsaAspect aspect1 = new EsaAspect()
            {
                AspectId = 1,
                Description = "Aspectgebied 1",
                Name = "Aspect 1"
            };
            EsaAspect aspect2 = new EsaAspect()
            {
                AspectId = 2,
                Description = "Aspectgebied 2",
                Name = "Aspect 2"
            };
            #endregion
            #region Areas
            EsaArea area0 = new EsaArea()
            {
                AreaId = 0,
                Name = "Area0"
            };
            EsaArea area1 = new EsaArea()
            {
                AreaId = 1,
                Name = "Area1"
            };
            EsaArea area2 = new EsaArea()
            {
                AreaId = 2,
                Name = "Area2"
            };
            #endregion
            #region Bivs
            Biv biv0 = new Biv()
            {
                Id = 0,
                Name = "1"
            };
            Biv biv1 = new Biv()
            {
                Id = 1,
                Name = "2"
            };
            Biv biv2 = new Biv()
            {
                Id = 2,
                Name = "3"
            };
            #endregion
            #region Requirements
            Requirements.Add(new SecurityRequirement()
            {
                RequirementId = 0,
                Name = "Requirement 0",
                Description = "Dit is requirement 0",
                Details = "Extra info over requirement 0",
                Family = "AO",
                MainGroup = "5",
                RequirementNumber = "AO1"
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
            #endregion
            #region AspectAreas
            esaAspArea.Add(new EsaAspectArea()
            {
                EsaArea = area0,
                EsaAspect = aspect0,
                EsaAreaId = 0,
                EsaAspectId = 0,
                EsaAspectAreaId = 0
            });
            esaAspArea.Add(new EsaAspectArea()
            {
                EsaArea = area1,
                EsaAspect = aspect1,
                EsaAreaId = 1,
                EsaAspectId = 1,
                EsaAspectAreaId = 1
            });
            esaAspArea.Add(new EsaAspectArea()
            {
                EsaArea = area2,
                EsaAspect = aspect2,
                EsaAreaId = 2,
                EsaAspectId = 2,
                EsaAspectAreaId = 2
            });
            #endregion
            #region AreaReqs
            esaAreaReq.Add(new EsaAreaRequirement()
            {
                EsaArea = area0,
                EsaAreaId = 0,
                EsaAreaRequirementId = 0,
                RequirementId = 0,
                Requirement = Requirements[0]
            });
            esaAreaReq.Add(new EsaAreaRequirement()
            {
                EsaArea = area1,
                EsaAreaId = 1,
                EsaAreaRequirementId = 1,
                RequirementId = 1,
                Requirement = Requirements[1]
            });
            esaAreaReq.Add(new EsaAreaRequirement()
            {
                EsaArea = area2,
                EsaAreaId = 2,
                EsaAreaRequirementId = 2,
                RequirementId = 2,
                Requirement = Requirements[2]
            });
            #endregion
            #region BivReqs
            bivRequirements.Add(new BIVRequirement()
            {
                Id = 0,
                BivId = 0,
                Biv = biv0,
                RequirementId = 0,
                SecurityRequirement = Requirements[0]
            });
            bivRequirements.Add(new BIVRequirement()
            {
                Id = 1,
                BivId = 1,
                Biv = biv1,
                RequirementId = 1,
                SecurityRequirement = Requirements[1]
            });
            bivRequirements.Add(new BIVRequirement()
            {
                Id = 2,
                BivId = 2,
                Biv = biv2,
                RequirementId = 2,
                SecurityRequirement = Requirements[2]
            });
            #endregion
        }
    }
}
