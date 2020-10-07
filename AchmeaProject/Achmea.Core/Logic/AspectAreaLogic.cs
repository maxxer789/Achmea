using System;
using System.Collections.Generic;
using System.Text;
using Achmea.Core.Interface;
using Achmea.Core.Model;

namespace Achmea.Core.Logic
{
    public class AspectAreaLogic
    {
            readonly IAspectArea _IAspectArea;

            public AspectAreaLogic(IAspectArea IAspectArea)
            {
                _IAspectArea = IAspectArea;
            }

            public List<AspectAreaModel> GetAspectAreas()
            {
                return _IAspectArea.GetAspectAreas();
            }

            public AspectAreaModel GetAspectAreaById(int Id)
            {
                return _IAspectArea.GetAspectAreaById(Id);
            }
        }
    }