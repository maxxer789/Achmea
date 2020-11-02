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
    public class AdminController : Controller
    {
        private readonly UserLogic logic;
        private readonly IUser Interface;

        public AdminController(IConfiguration config)
        {
            Interface = new UserDAL();
            logic = new UserLogic(Interface);
        }


        public IActionResult Index()
        {
            return View("Views/Accounts/Admin/Index.cshtml");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Views/Accounts/Admin/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Register(UserViewModel VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = logic.Login(VM.Email);
                    ModelState.AddModelError(string.Empty, "Email already exists!");
                }
                catch
                {
                    User user = ViewModelConverter.VmtoUser(VM);
                    logic.InsertUser(user);

                    HttpContext.Session.SetInt32("UserID", logic.InsertUser(user));
                    HttpContext.Session.SetString("Firstname", VM.Firstname);
                    HttpContext.Session.SetString("RoleID", user.RoleId);

                    return RedirectToAction("UserList", "Admin", VM);
                }
            }
            return View("Views/Accounts/Admin/Register.cshtml");
        }

        public IActionResult UserList()
        {
            List<UserViewModel> vm = new List<UserViewModel>();
            foreach (User U in logic.GetAllUsers())
            {
                UserViewModel Uvm = ViewModelConverter.UserToVm(U);

                vm.Add(Uvm);
            }
            return View("Views/Accounts/Admin/UserList.cshtml", vm);
        }

        public IActionResult Delete_User(int id)
        {
            logic.DeleteUser(id);

            return RedirectToAction("UserList", "Admin");
        }

        [HttpGet]
        public IActionResult Edit_User(int id)
        {
            UserViewModel vm = ViewModelConverter.UserToVm(logic.GetUserByID(id));
            return View("Views/Accounts/Admin/UserEdit.cshtml", vm);
        }
        [HttpPost]
        public IActionResult Edit_User(UserViewModel vm)
        {
            User user = ViewModelConverter.VmtoUser(vm);

            logic.UpdateUser(user);

            return View("Views/Accounts/Admin/UserDetails.cshtml", vm);
        }

        public IActionResult Details_User(int id)
        {
            User user = logic.GetUserByID(id);
            UserViewModel vm = ViewModelConverter.UserToVm(user);

            return View("Views/Accounts/Admin/UserDetails.cshtml", vm);
        }
    }
}
