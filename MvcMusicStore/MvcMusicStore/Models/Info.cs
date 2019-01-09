using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class Info
    {
        public int InfoID { get; set; }
        public int GenreID { get; set; }
        public int MusicID { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Music Music { get; set; }
    }
}