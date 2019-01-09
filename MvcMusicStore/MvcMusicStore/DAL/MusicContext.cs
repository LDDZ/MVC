using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcMusicStore.DAL
{
    public class MusicContext : DbContext
    {

        public MusicContext() : base("MusicContext")
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}