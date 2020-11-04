using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class BivLogic
    {
        readonly IBiv _IBiv;

        public BivLogic(IBiv IBiv)
        {
            _IBiv = IBiv;
        }

        public List<Biv> GetBiv()
        {
            return _IBiv.GetBiv();
        }

        public IEnumerable<Biv> SaveBivToProject(List<Biv> classifications, Project project)
        {
            return _IBiv.SaveBivToProject(classifications, project);
        }
    }
}

