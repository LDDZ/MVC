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
            Genre genre = db.Genres.Find(id);
            var query = from b in db.Infos
                        where b.GenreID.ToString().Contains(genre.GenreID.ToString())
                        select b;
            var info = query.ToList();
            List<Music> musicList = null;
            Music music = new Music();
            foreach (var item in info)
            {
                music.MusicID = item.MusicID;
                music.MusicName = item.Music.MusicName;
                music.MusicPath = item.Music.MusicPath;
                music.Infos = (ICollection<Info>)item.Genre;
                //item.Genre = music.Infos;
                musicList.Add(music);
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