using MvcMusicStore.DAL;
using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcMusicStore.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                UserStatus status = GetUserValidity(u);
                bool IsAdmin = false;
                if (status == UserStatus.AuthenticatedAdmin)
                {
                    IsAdmin = true;
                }
                else if (status == UserStatus.AuthentucatedUser)
                {
                    IsAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "用户名密码无效");
                    return View();
                }
                //设置cookie 保存在浏览器
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                // 保存在服务器端,关闭浏览器后session就清空
                Session["IsAdmin"] = IsAdmin;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //[NonAction]
        //public bool IsValidUser(UserDetails u)
        //{
        //    using (var db = new MusicContext())
        //    {
        //        return db.UserDbSet.Any(o => o.UserName == u.UserName && o.Password == u.Password);
        //    }

        //}
        public UserStatus GetUserValidity(UserDetails u)
        {
            using (var db = new MusicContext())
            {

                if (db.UserDbSet.Any(o => o.UserName == u.UserName && o.Password == u.Password))
                {
                    return db.UserDbSet.Single(o => o.UserName == u.UserName && o.Password == u.Password).Status;
                }
                else
                {
                    return UserStatus.NonAuthenticatedUser;
                }
            }
        }

        }
    }