using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class RequiermentLogic
    {
        private IRequirement _IReq;
        public RequiermentLogic(IRequirement IReq)
        {
            _IReq = IReq;
        }

        public List<RequirementModel> getRequiermentsFromAreas(List<AspectAreaModel> areas)
        {
            return _IReq.getRequiermentsFromAreas(areas);
        }
    }
}
