using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
    public class Music
    {
        public int MusicID { get; set; }
        [Display(Name = "歌曲")]
        public string MusicName { get; set; }
        [Display(Name = "路径")]
        public string MusicPath { get; set; }
        //public string aaa { get; set; }
        [Display(Name = "信息")]
        public virtual ICollection<Info> Infos { get; set; }

    }
}