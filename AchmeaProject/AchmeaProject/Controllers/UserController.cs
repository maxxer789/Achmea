using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AchmeaProject.Sessions;
using Microsoft.AspNetCore.Mvc;
using Achmea.Core.Logic;
using Achmea.Core.Interface;
using Achmea.Core.SQL;
using Microsoft.Extensions.Configuration;
using AchmeaProject.Models;
using Microsoft.AspNetCore.Http;

namespace AchmeaProject.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserLogic _UserLogic;
        public UserController(IConfiguration config, IUser iUser)
        {
            _UserLogic = new UserLogic(iUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Views/Accounts/Developer/Login.cshtml");
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel VM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool verified = false;
                    User User = _UserLogic.Login(VM.Email);
                    if (User != null)
                    {
                        verified = BCrypt.Net.BCrypt.Verify(VM.Password, User.Password);
                    }
                    if (verified == true)
                    {
                        HttpContext.Session.SetInt32("UserID", User.UserId);
                        HttpContext.Session.SetString("Firstname", User.Firstname);
                        HttpContext.Session.SetString("RoleID", User.RoleId);

                        if (User.RoleId == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        if (User.RoleId == "Security")
                        {
                            return RedirectToAction("Index", "Security");
                        }
                        if (User.RoleId == "Developer")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ModelState.AddModelError(string.Empty, "The data is not correct");
                    return View("Views/Accounts/Developer/Login.cshtml");
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }
            ModelState.AddModelError(string.Empty, "Fill in all Data");

            return View("Views/Accounts/Developer/Login.cshtml", VM);
        }

        public IActionResult Log_Out()
        {
            HttpContext.Session.Remove("Firstname");
            HttpContext.Session.Remove("RoleID");
            HttpContext.Session.Remove("UserID");

            return RedirectToAction("Login");
        }
    }
}
