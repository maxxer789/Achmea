using Achmea.Core;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using AchmeaProject.Core;
using AchmeaProject.Models;
using Dapper;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Achmea.Core.SQL
{
    public class RequirementDAL : AchmeaContext, IRequirement
    {
        public RequirementDAL()
        {

        }

        public List<SecurityRequirement> GetAllRequirements()
        {
            return SecurityRequirement.OrderBy(x=>x.RequirementId).ToList();
        }

        public SecurityRequirement GetRequirementById(int Id)
        {
            return SecurityRequirement.Where(requirement => requirement.RequirementId == Id).SingleOrDefault();
        }

        public IEnumerable<SecurityRequirement> GetRequiermentsFromAreas(List<EsaAspect> aspects)
        {
            List<SecurityRequirement> requierments = new List<SecurityRequirement>();
            List<SecurityRequirement> disRequierments = new List<SecurityRequirement>();
            List<EsaArea> areas = new List<EsaArea>();

            foreach (EsaAspect aspect in aspects)
            {
                var result = (from a in EsaArea
                              join ea in EsaAspectArea on a.AreaId equals ea.EsaAreaId
                              where ea.EsaAspectId == aspect.AspectId

                              select new EsaArea
                              {
                                  AreaId = a.AreaId,
                                  Name = a.Name,
                                  EsaAreaRequirement = a.EsaAreaRequirement,
                                  EsaAspectArea = a.EsaAspectArea
                              }).ToList();
                areas.AddRange(result);
            }


            areas.Add(EsaArea.ToList().Where(area => area.AreaId == 13).FirstOrDefault());

            foreach (EsaArea area in areas)
            {
                var result = (from r in SecurityRequirement
                              join ear in EsaAreaRequirement on r.RequirementId equals ear.RequirementId
                              where ear.EsaAreaId == area.AreaId

                              select new SecurityRequirement
                              {
                                  RequirementId = r.RequirementId,
                                  Name = r.Name,
                                  Details = r.Details,
                                  Description = r.Description,
                                  Family = r.Family,
                                  RequirementNumber = r.RequirementNumber,
                                  MainGroup = r.MainGroup
                              }).ToList();
                requierments.AddRange(result);
            }

            disRequierments = requierments.GroupBy(r => r.RequirementId).Select(g => g.First()).OrderBy(s => s.RequirementId).ToList();

            return disRequierments;
        }
        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            List<SecurityRequirement> requierments = new List<SecurityRequirement>();
            List<SecurityRequirement> disRequierments = new List<SecurityRequirement>();

            foreach (Biv classif in classifications)
            {
                var result = (from r in SecurityRequirement
                              join br in BIVRequirement on r.RequirementId equals br.RequirementId
                              join b in Biv on br.BivId equals b.Id
                              where b.Name.Contains(classif.Name.First().ToString())
                              where b.Id <= classif.Id

                              select new SecurityRequirement
                              {
                                  RequirementId = r.RequirementId,
                                  Name = r.Name,
                                  Details = r.Details,
                                  Description = r.Description,
                                  Family = r.Family,
                                  RequirementNumber = r.RequirementNumber,
                                  MainGroup = r.MainGroup,
                              }).ToList();

                requierments.AddRange(result);
            }

            disRequierments = requierments.GroupBy(r => r.RequirementId).Select(g => g.First()).OrderBy(s => s.RequirementId).ToList();

            return disRequierments;
        }

        public IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, Project project)
        {
            foreach (SecurityRequirement req in requirements)
            {
                SecurityRequirementProject srm = new SecurityRequirementProject();
                srm.SecurityRequirementId = req.RequirementId;
                srm.ProjectId = project.ProjectId;
                srm.Excluded = false;
                srm.Status = Status.ToDo.ToString();

                SecurityRequirementProject.Add(srm);
                SaveChanges();
            }
            return SecurityRequirementProject.ToList().Where(sr => sr.ProjectId == project.ProjectId);
        }

        public SecurityRequirement CreateRequirement(SecurityRequirement req, List<int> bivIds, List<int> areaIds)
        {
            SecurityRequirement.Add(req);

            SaveChanges();
            req.RequirementId = req.RequirementId;
            foreach (int Id in bivIds)
            {
                BIVRequirement br = new BIVRequirement();
                br.BivId = Id;
                br.RequirementId = req.RequirementId;

                BIVRequirement.Add(br);
            }
            foreach(int Id in areaIds)
            {
                EsaAreaRequirement areaReq = new EsaAreaRequirement();
                areaReq.EsaAreaId = Id;
                areaReq.RequirementId = req.RequirementId;

                EsaAreaRequirement.Add(areaReq);
            }

            SaveChanges();

            return req;
        }
    }
}
