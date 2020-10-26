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
    }
}
