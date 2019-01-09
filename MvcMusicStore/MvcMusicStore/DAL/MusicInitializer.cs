using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcMusicStore.Models;

namespace MvcMusicStore.DAL
{
    public class MusicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicContext>
    {
        protected override void Seed(MusicContext context)
        {
            // 构建流派数据
            var Genres = new List<Genre>
            {
                new Genre {GenreID=01, GenreName="摇滚" },
                new Genre {GenreID=02, GenreName="爵士" },
                new Genre {GenreID=03, GenreName="R&B" },
                new Genre {GenreID=04, GenreName="迪斯科" }
            };
            //将流派数据加入实体集,并保存状态
            Genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            // 构建歌曲数据
            var Musics = new List<Music>
            {
                new Music {MusicID=01, MusicName="齐天大圣" ,MusicPath="#"},
                new Music {MusicID=02, MusicName="There for you" ,MusicPath="#"},
                new Music {MusicID=03, MusicName="裂缝中的阳光" ,MusicPath="#"},
                new Music {MusicID=04, MusicName="晴天" ,MusicPath="#"}
            };
            //将歌曲数据加入实体集,并保存状态
            Musics.ForEach(s => context.Musics.Add(s));
            context.SaveChanges();

            // 构建信息数据
            var Infos = new List<Info>
            {
                new Info {InfoID=01, GenreID=01,MusicID=01},
                new Info {InfoID=02, GenreID=02 ,MusicID=02},
                new Info {InfoID=03, GenreID=03 ,MusicID=03},
                new Info {InfoID=04, GenreID=04 ,MusicID=04}
            };
            //将信息数据加入实体集,并保存状态
            Infos.ForEach(s => context.Infos.Add(s));
            context.SaveChanges();
        }
    }
}
