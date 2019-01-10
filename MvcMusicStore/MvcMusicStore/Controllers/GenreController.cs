using MvcMusicStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class GenreController : Controller
    {
        private MusicContext db = new MusicContext();
        // GET: Genre
        public ActionResult Index(int id)
        {
            Genre gener = db.Genres.Find(id);
            List<Info> infoList = gener.Infos.ToList();
            var musicList = new List<Music>();
            foreach (var item in infoList)
            {
                musicList.Add(item.Music);
            }
            return View(musicList);
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