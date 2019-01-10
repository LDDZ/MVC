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
                new Genre {GenreID=1, GenreName="摇滚" },
                new Genre {GenreID=2, GenreName="爵士" },
                new Genre {GenreID=3, GenreName="house" },
                new Genre {GenreID=4, GenreName="Soul" },
                 new Genre {GenreID=5, GenreName="迪斯科" },
                  new Genre {GenreID=6, GenreName="民歌" },
                   new Genre {GenreID=7, GenreName="DJ" },
                    new Genre {GenreID=8, GenreName="轻音乐" }

            };
            //将流派数据加入实体集,并保存状态
            Genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            // 构建歌曲数据
            var Musics = new List<Music>
            {
                new Music {MusicID=1, MusicName="齐天大圣" ,MusicPath="http://music.163.com/song/media/outer/url?id=442869498.mp3"},
                new Music {MusicID=2, MusicName="There for you" ,MusicPath="http://music.163.com/song/media/outer/url?id=480426313.mp3"},
                new Music {MusicID=3, MusicName="裂缝中的阳光" ,MusicPath="http://music.163.com/song/media/outer/url?id=25794009.mp3"},
                new Music {MusicID=4, MusicName="晴天" ,MusicPath="http://dl.stream.qqmusic.qq.com/M8000039MnYb0qxYhV.mp3?vkey=3214D0192D6BA348F27B7DE24650E8364136330281E237C83EE6EA5A459BD274205DC47F8FEE646369FCEC8C28E74006617B7002B5163F92&guid=5150825362&fromtag=1"},
                new Music {MusicID=5, MusicName="西厢" ,MusicPath="http://music.163.com/song/media/outer/url?id=92311.mp3"}
            };
            //将歌曲数据加入实体集,并保存状态
            Musics.ForEach(s => context.Musics.Add(s));
            context.SaveChanges();

            // 构建信息数据
            var Infos = new List<Info>
            {
                new Info {InfoID=1, GenreID=1,MusicID=1},
                new Info {InfoID=2, GenreID=2 ,MusicID=2},
                new Info {InfoID=3, GenreID=2 ,MusicID=3},
                new Info {InfoID=4, GenreID=4 ,MusicID=4},
                new Info {InfoID=5, GenreID=5 ,MusicID=2},
                new Info {InfoID=6, GenreID=1 ,MusicID=3},
                new Info {InfoID=7, GenreID=4 ,MusicID=2},
                new Info {InfoID=8, GenreID=3 ,MusicID=3},
                new Info {InfoID=9, GenreID=3 ,MusicID=2},
                new Info {InfoID=10, GenreID=8 ,MusicID=3},
            };
            //将信息数据加入实体集,并保存状态
            Infos.ForEach(s => context.Infos.Add(s));
            context.SaveChanges();

            //构建用户数据
            var users = new List<UserDetails> {
                new UserDetails { UserName="admin1",Password="admin",Status=UserStatus.AuthenticatedAdmin},
                new UserDetails  { UserName="guest1",Password="guest",Status=UserStatus.AuthentucatedUser},
                new UserDetails { UserName="admin2",Password="admin",Status=UserStatus.AuthenticatedAdmin},
                new UserDetails  { UserName="guest2",Password="guest",Status=UserStatus.AuthentucatedUser}
            };

            users.ForEach(u => context.UserDbSet.Add(u));
            context.SaveChanges();

        }
    }
}
