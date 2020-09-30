using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models.ViewModelConverter
{
    public class ViewModelConverter
    {
        public static ESA_AspectViewModel AspectAreaModelToESA_AspectViewModel(AspectAreaModel model)
        {
            ESA_AspectViewModel vm = new ESA_AspectViewModel(model.AspectAreaId, model.Title, model.Description);

            return vm;
        }

        public static List<ESA_AspectViewModel> AspectAreaModelToESA_AspectViewModel(List<AspectAreaModel> models)
        {
            List<ESA_AspectViewModel> vms = new List<ESA_AspectViewModel>();

            foreach (var model in models)
            {
                ESA_AspectViewModel vm = new ESA_AspectViewModel(model.AspectAreaId, model.Title, model.Description);
                vms.Add(vm);
            }    

            return vms;
        }
    }
}
