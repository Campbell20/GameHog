using GameHog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameHog.Data
{
    public class GameHogContext : DbContext
    {
        public GameHogContext() : base("DefaultConnection")
        {

        }

        //All stores table
        public DbSet<Store> Stores { get; set; }
        //All of the hardware including game systems table
        public DbSet<Hardware> Hardwares { get; set; }
        //All of teh games for every system table
        public DbSet<Game> Games { get; set; }
        //All of the genres of game types
        public DbSet<Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<GameHog.Models.Accessory> Accessories { get; set; }
    }
}