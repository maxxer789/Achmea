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
    public class RequiermentDAL : DbContext, IRequirement
    {
        public RequiermentDAL(string Connectionstring)
        {

        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromAreas(List<EsaArea> areas)
        {
            List<SecurityRequirement> requierments = new List<SecurityRequirement>();
            string sql = @"SELECT * FROM [Security_Requirement] AS SR WHERE SR.RequirementID IN
                            (SELECT RequirementID FROM[ESA-Aspect-Security_Requirement] WHERE AspectID IN
                                (SELECT ESA_AreaID FROM[ESA_Aspect-Area] AS EAA WHERE EAA.ESA_AspectID = @ID))";

            //DataSet result = ExecuteSQL(sql, parameters);
            foreach (EsaArea aam in areas)
            {
                
            }

            requierments = requierments.Distinct().ToList();

            return requierments;
        }

        public IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, int projectId)
        {
            foreach(SecurityRequirement req in requirements)
            {
                SecurityRequirementProject srm = new SecurityRequirementProject();
                srm.SecurityRequirementId = req.RequirementId;
                srm.ProjectId = projectId;
                srm.Status = Status.ToDo.ToString();

                SecurityRequirementProject.Add(srm);
                SaveChanges();
            }
            return SecurityRequirementProject.ToList().Where(sr => sr.ProjectId == projectId);
        }
    }
}
