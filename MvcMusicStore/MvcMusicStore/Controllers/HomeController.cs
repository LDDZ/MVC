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
    public class HomeController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Music
        public ActionResult Index()
        {
            return View(db.Musics.ToList());
        }
        public ActionResult Play(int id)
        {
            Music Music = db.Musics.Find(id);
            return View(Music);
        }
        public ActionResult Genre()
        {
            return View(db.Genres.ToList());
        }
        [Authorize]//验证
        public ActionResult Download()
        {
            return View();
        }
        [NonAction]
        public bool IsValidUser(UserDetails u)
        {
            
            return db.UserDbset.Any(o => o.UserName == u.UserName && o.Password == u.Password);
           
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

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}