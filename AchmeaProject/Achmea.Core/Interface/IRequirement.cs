using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IRequirement
    {
        List<RequirementModel> getRequiermentsFromAreas(List<AspectAreaModel> areas);
    }
}
