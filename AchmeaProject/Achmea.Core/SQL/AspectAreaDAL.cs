using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.SQL
{
    public class AspectAreaDAL : BaseDAL, IAspectArea
    {
        public AspectAreaDAL(string Connectionstring) : base(Connectionstring)
        {

        }

        public List<AspectAreaModel> GetAspectAreas()
        {
            List<AspectAreaModel> aspects = new List<AspectAreaModel>();

            return aspects;
        }
    }
}
