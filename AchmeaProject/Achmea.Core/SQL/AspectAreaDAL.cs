using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Achmea.Core.SQL
{
    public class AspectAreaDAL : AchmeaContext, IAspectArea
    {
        public AspectAreaDAL() : base()
        {

        }

        public List<EsaAspect> GetAspectAreas()
        {
            return EsaAspect.ToList();
        }

        public IEnumerable<EsaAspect> SaveAspectToProject(List<EsaAspect> aspects, Project project)
        {
            foreach (EsaAspect aspect in aspects)
            {
                ProjectEsaAspect pa = new ProjectEsaAspect();
                pa.AspectId = aspect.AspectId;
                pa.ProjectId = project.ProjectId;

                ProjectEsaAspect.Add(pa);
                SaveChanges();
            }
            return aspects;
        }
    }
}
