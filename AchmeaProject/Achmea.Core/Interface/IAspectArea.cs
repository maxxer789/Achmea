using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IAspectArea
    {
        List<EsaAspect> GetAspectAreas();
        IEnumerable<EsaAspect> SaveAspectToProject(List<EsaAspect> aspects, Project project);
        List<EsaArea> GetAreas();
    }
}
