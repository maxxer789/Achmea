using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class AdminController : BaseController
    {
        private readonly UserLogic _UserLogic;

        public AdminController(IConfiguration config, IUser iUser)
        {
            _UserLogic = new UserLogic(iUser);
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("RoleID") == "Admin")
            {
                return View("Views/Accounts/Admin/Index.cshtml");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("RoleID") == "Admin")
            {
                return View("Views/Accounts/Admin/Register.cshtml");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(UserViewModel VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = ViewModelConverter.VmtoUser(VM);
                    user = _UserLogic.InsertUser(user);

                    return RedirectToAction("UserList", "Admin");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Email already exists!");
                }
            }
            return View("Views/Accounts/Admin/Register.cshtml");
        }

        public IActionResult UserList()
        {
            if (HttpContext.Session.GetString("RoleID") == "Admin")
            {
                List<UserViewModel> vm = new List<UserViewModel>();
                foreach (User U in _UserLogic.GetAllUsers())
                {
                    UserViewModel Uvm = ViewModelConverter.UserToVm(U);

                    vm.Add(Uvm);
                }
                return View("Views/Accounts/Admin/UserList.cshtml", vm);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete_User(int id)
        {
            _UserLogic.DeleteUser(id);

            return RedirectToAction("UserList", "Admin");
        }

        [HttpGet]
        public IActionResult Edit_User(int id)
        {
            if (HttpContext.Session.GetString("RoleID") == "Admin")
            {
                UserViewModel vm = ViewModelConverter.UserToVm(_UserLogic.GetUserByID(id));
                return View("Views/Accounts/Admin/UserEdit.cshtml", vm);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Edit_User(UserViewModel vm)
        {
            User user = ViewModelConverter.VmtoUser(vm);

            _UserLogic.UpdateUser(user);

            return View("Views/Accounts/Admin/UserDetails.cshtml", vm);
        }

        public IActionResult Details_User(int id)
        {
            if (HttpContext.Session.GetString("RoleID") == "Admin")
            {
                User user = _UserLogic.GetUserByID(id);
                UserViewModel vm = ViewModelConverter.UserToVm(user);

                return View("Views/Accounts/Admin/UserDetails.cshtml", vm);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
