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
        public bool IsValidUser(UserDetails u)
        {
            using (var sc = new SchoolContext())
            {
                return sc.UserDbset.Any(e => e.UserName == u.UserName && e.Password == u.Password);
                
            }
        }

        [HttpPost]
        public ActionResult Login(UserDetails u)
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