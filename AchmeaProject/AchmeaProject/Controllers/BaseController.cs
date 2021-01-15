using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AchmeaProject.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
            var user = GetUser();
            
            if(user != 0)
            {
                ViewBag.User = user;
            }

        }

        public int GetUser()
        {
            if (HttpContext != null)
            {
                if (HttpContext.Session.GetInt32("UserID") != null)
                {
                    return HttpContext.Session.GetString("UserID").FirstOrDefault();
                }
            }
            return 0;
        }
    }
}