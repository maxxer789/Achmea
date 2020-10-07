using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IAspectArea
    {
        List<AspectAreaModel> GetAspectAreas();
        AspectAreaModel GetAspectAreaById(int Id);
    }
}
