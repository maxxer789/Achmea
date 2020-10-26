
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

        public static User VmtoUser(UserViewModel VM)
        {
            return new User
            {
                UserId = VM.UserID,
                Email = VM.Email,
                Password = VM.Password,
                Firstname = VM.Firstname,
                Lastname = VM.Lastname,
                PhoneNumber = VM.PhoneNumber,
                RoleId = VM.RoleID
            };
        }

        public static UserViewModel UserToVm(User User)
        {
            return new UserViewModel
            {
                UserID = User.UserId,
                Email = User.Email,
                Password = User.Password,
                Firstname = User.Firstname,
                Lastname = User.Lastname,
                PhoneNumber = User.PhoneNumber,
                RoleID = User.RoleId
            };
        }
      
        public static BivViewModel BivModelToBivViewModel(Biv biv)
        {
            return new BivViewModel
            {
                Id = biv.Id,
                Name = biv.Name,
            };
            
        }

        public static List<BivViewModel> BivModelToBivViewModel(List<Biv> bivs)
        {
            List<BivViewModel> vms = new List<BivViewModel>();

            foreach (var biv in bivs)
            {
                BivViewModel vm = new BivViewModel
                {
                    Id = biv.Id,
                    Name = biv.Name,
                };
                vms.Add(vm);
            }

            return vms;
        }
    }
}
