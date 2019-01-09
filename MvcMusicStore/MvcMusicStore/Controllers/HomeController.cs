using MvcMusicStore.DAL;
using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Play(string MusicID)
        {
            Music Music = db.Musics.Find(MusicID);
            return View(Music);
        }
    }
}