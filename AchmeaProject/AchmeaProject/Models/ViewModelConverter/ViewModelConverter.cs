using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models.ViewModelConverter
{
    public class ViewModelConverter
    {
        public static ESA_AspectViewModel AspectAreaModelToESA_AspectViewModel(EsaAspect model)
        {
            ESA_AspectViewModel vm = new ESA_AspectViewModel()
            {
                ID = model.AspectId,
                Title = model.Name,
                Description = model.Description
            };

            return vm;
        }

        public static List<ESA_AspectViewModel> AspectAreaModelToESA_AspectViewModel(List<EsaAspect> models)
        {
            List<ESA_AspectViewModel> vms = new List<ESA_AspectViewModel>();

            foreach (var model in models)
            {
                ESA_AspectViewModel vm = new ESA_AspectViewModel()
                {
                    ID = model.AspectId,
                    Title = model.Name,
                    Description = model.Description
                };
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
    }
}
