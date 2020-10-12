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

        public static UserModel VmtoUser(UserViewModel VM)
        {
            return new UserModel
            {
                UserID = VM.UserID,
                Email = VM.Email,
                Password = VM.Password,
                Firstname = VM.Firstname,
                Lastname = VM.Lastname,
                PhoneNumber = VM.PhoneNumber,
                RoleID = VM.RoleID
            };
        }

        public static UserViewModel UserToVm(UserModel User)
        {
            return new UserViewModel
            {
                UserID = User.UserID,
                Email = User.Email,
                Password = User.Password,
                Firstname = User.Firstname,
                Lastname = User.Lastname,
                PhoneNumber = User.PhoneNumber,
                RoleID = User.RoleID
            };
        }
      
        public static BivViewModel BivModelToBivViewModel(Biv model)
        {
            BivViewModel vm = new BivViewModel(model.Id, model.Name);

            return vm;
        }

        public static List<BivViewModel> BivModelToBivViewModel(List<Biv> models)
        {
            List<BivViewModel> vms = new List<BivViewModel>();

            foreach (var model in models)
            {
                BivViewModel vm = new BivViewModel(model.Id, model.Name);
                vms.Add(vm);
            }

            return vms;
        }
    }
}
