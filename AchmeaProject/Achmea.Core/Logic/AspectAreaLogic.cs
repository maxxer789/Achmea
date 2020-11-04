using System;
using System.Collections.Generic;
using System.Text;
using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;

namespace Achmea.Core.Logic
{
    public class AspectAreaLogic
    {
        readonly IAspectArea _IAspectArea;

        public AspectAreaLogic(IAspectArea IAspectArea)
        {
            _IAspectArea = IAspectArea;
        }

        public List<EsaAspect> GetAspectAreas()
        {
            return _IAspectArea.GetAspectAreas();
        }

        public List<EsaArea> GetAreas()
        {
            return _IAspectArea.GetAreas();
        }

        public IEnumerable<EsaAspect> SaveAspectToProject(List<EsaAspect> aspects, Project project)
        {
            return _IAspectArea.SaveAspectToProject(aspects, project);
        }
    }
}
