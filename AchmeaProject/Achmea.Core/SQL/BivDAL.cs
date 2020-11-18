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
    public class BivDAL : AchmeaContext, IBiv
    {
        public List<Biv> GetBiv()
        {
            return Biv.ToList();
        }

        public IEnumerable<Biv> SaveBivToProject(List<Biv> classifications, Project project)
        {
            foreach (Biv biv in classifications)
            {
                ProjectBiv pb = new ProjectBiv();
                pb.BivId = biv.Id;
                pb.ProjectId = project.ProjectId;

                ProjectBiv.Add(pb);
                SaveChanges();
            }
            return classifications;
        }
    }
}
