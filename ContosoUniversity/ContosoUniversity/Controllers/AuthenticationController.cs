using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ContosoUniversity.DAL;

namespace ContosoUniversity.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [NonAction]
        public bool IsValidUser(User u)
        {
            //using (var sc = new SchoolContext())
            //{
            //    var query = sc.Users.Where(e => e.UserName==u.UserName).Where(e=>e.Password==u.Password);
            //    Console.WriteLine(query);
            //    if (query.Count()== 0)
            //        return false;
            //    else
            //        return true;
            //}
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            if (IsValidUser(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "用户名密码无效");
                return View("Login");
            }
        }


    }
}