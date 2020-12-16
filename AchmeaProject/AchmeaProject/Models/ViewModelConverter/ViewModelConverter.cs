
using Achmea.Core.Logic;
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
        public static List<EsaAspect> AspectAreaViewModelToESA_AspectModel(List<ESA_AspectViewModel> models)
        {
            List<EsaAspect> aspects = new List<EsaAspect>();

            foreach (var model in models)
            {
                EsaAspect vm = new EsaAspect()
                {
                    AspectId = model.ID,
                    Description = model.Description,
                    Name = model.Title
                };
                aspects.Add(vm);
            }

            return aspects;
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
        public static List<UserViewModel> UserToVm(List<User> Users)
        {
            List<UserViewModel> uvms = new List<UserViewModel>();
            foreach (User User in Users)
            {
                uvms.Add( new UserViewModel
                {
                    UserID = User.UserId,
                    Email = User.Email,
                    Password = User.Password,
                    Firstname = User.Firstname,
                    Lastname = User.Lastname,
                    PhoneNumber = User.PhoneNumber,
                    RoleID = User.RoleId
                });
            }
            return uvms;
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

        public static List<Biv> BivViewModelToBivModel(List<BivViewModel> bvms)
        {
            List<Biv> Bivs = new List<Biv>();

            foreach (var bvm in bvms)
            {
                Biv biv = new Biv
                {
                    Id = bvm.Id,
                    Name = bvm.Name,
                };
                Bivs.Add(biv);
            }

            return Bivs;
        }

        public static ProjectViewModel ProjectToVm(Project Pmodel)
        {
            ProjectViewModel vm = new ProjectViewModel()
            {
                ProjectId = Pmodel.ProjectId,
                Title = Pmodel.Title,
                Description = Pmodel.Description,
            };

            return vm;
        }

        public static List<ProjectViewModel> VmToProject(List<Project> Pmodel)
        {
            List<ProjectViewModel> vms = new List<ProjectViewModel>();

            foreach (Project model in Pmodel)
            {
                ProjectViewModel vm = new ProjectViewModel()
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Description = model.Description,
                    CreationDate = model.CreationDate.Value.ToShortDateString(),
                };
                vms.Add(vm);
            }

            return vms;
        }

        public static Project ProjectViewModelToProjectModel(ProjectCreationDetailsViewModel pvm)
        {
            return new Project
            {
                Title = pvm.Title,
                Description = pvm.Description,
                UserId = pvm.UserID,
                CreationDate = Convert.ToDateTime(pvm.CreationDate),
            };
        }
        public static Project ProjectViewModelToProjectModel(ProjectViewModel pvm)
        {
            return new Project
            {
                ProjectId = pvm.ProjectId,
                Title = pvm.Title,
                Description = pvm.Description,
                CreationDate = Convert.ToDateTime(pvm.CreationDate),
            };
        }
        public static SecurityRequirement securityRequirementViewModelToModel(RequirementCreateViewModel rcvm)
        {
            return new SecurityRequirement
            {
                Name = rcvm.Name,
                Description = rcvm.Description,
                Details = rcvm.Details,
                Family = rcvm.Family,
                MainGroup = rcvm.MainGroup,
                RequirementNumber = rcvm.RequirementNumber
            };
        }
        public static SecurityRequirement securityRequirementViewModelToModel(RequirementViewModel req)
        {
            return new SecurityRequirement
            {
                RequirementId = req.Id,
                Name = req.Name,
                Description = req.Description,
                Details = req.Details,
                Family = req.Family,
                MainGroup = req.MainGroup,
                RequirementNumber = req.RequirementNumber
            };
        }

        public static UserSelectionViewModel UserToUserSelectionViewModel(User user)
        {
            return new UserSelectionViewModel
            {
                UserID = user.UserId,
                Name = user.Firstname + " " + user.Lastname
            };
        }

        public static List<UserSelectionViewModel> UserToUserSelectionViewModel(List<User> users)
        {
            List<UserSelectionViewModel> UserVMs = new List<UserSelectionViewModel>();
            foreach (User user in users)
            {
                UserVMs.Add(new UserSelectionViewModel
                {
                    UserID = user.UserId,
                    Name = user.Firstname + " " + user.Lastname
                });
            }

            return UserVMs;
        }

        public static SecurityRequirementProject SecurityRequirementProjectViewModelToModel(SecurityRequirementProjectViewModel req)
        {
            return new SecurityRequirementProject
            {
                SecurityRequirementProjectId = req.SecurityRequirementProjectId,
                ProjectId = req.ProjectId,
                SecurityRequirementId = req.SecurityRequirementId,
                Excluded = req.Excluded,
                Reason = req.Reason,
                Status = (_Status)Enum.Parse(typeof(_Status), req.Status)
        };
        }
    }
}
