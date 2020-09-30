using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Achmea.Core.Logic;
using Achmea.Core.Interface;
using Achmea.Core.SQL;
using Microsoft.Extensions.Configuration;
using AchmeaProject.Models;
using Achmea.Core.Model;
using Microsoft.AspNetCore.Http;

namespace AchmeaProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserLogic Logic;
        private readonly IUser Interface;
        public UserController(IConfiguration config)
        {
            Interface = new UserDAL(config.GetConnectionString("MSSQLfhict"));
            Logic = new UserLogic(Interface);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserModel User = Logic.Login(VM.Email);

                    if (VM.Password == User.Password)
                    {
                        /*HttpContext.Session.SetString("Firstname", User.Firstname);
                        HttpContext.Session.SetInt32("RoleID", User.RoleID);
                        HttpContext.Session.SetInt32("UserID", User.UserID);*/

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ModelState.AddModelError(string.Empty, "The data is not correct");
                    return View("Views/User/Login.cshtml");
                }
            }
            ModelState.AddModelError(string.Empty, "Fill in all Data");

            return View("Views/User/Login.cshtml", VM);
        }
        public IActionResult Log_Out()
        {
            HttpContext.Session.Remove("Firstname");
            HttpContext.Session.Remove("RoleID");
            HttpContext.Session.Remove("UserID");

            return RedirectToAction("Index", "Home");
        }
    }
}
