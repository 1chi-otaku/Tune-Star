using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Tune_Star.DAL.Entities;

namespace Tune_Star.DAL.EF
{
    public class TuneStarContext : DbContext
    {
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Users> Users { get; set; }
        public TuneStarContext(DbContextOptions<TuneStarContext> options)
                   : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
