using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IBiv
    {
        List<Biv> GetBiv();
        IEnumerable<Biv> SaveBivToProject(List<Biv> classifications, Project project);
    }
}
