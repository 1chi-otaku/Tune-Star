using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tune_Star.DAL.EF;
using Tune_Star.DAL.Entities;
using Tune_Star.DAL.Interfaces;

namespace Tune_Star.DAL.Repositories
{
    public class GenresRepository : IRepository<Genres>
    {
        private TuneStarContext db;

        public GenresRepository(TuneStarContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Genres>> GetAll()
        {
            return await db.Genres.ToListAsync();
        }

        public async Task<Genres> Get(int id)
        {
            Genres? team = await db.Genres.FindAsync(id);
            return team!;
        }

        public async Task<Genres> Get(string name)
        {
            var teams = await db.Genres.Where(a => a.Name == name).ToListAsync();
            Genres? team = teams?.FirstOrDefault();
            return team!;
        }

        public async Task Create(Genres team)
        {
            await db.Genres.AddAsync(team);
        }

        public void Update(Genres team)
        {
            db.Entry(team).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            Genres? team = await db.Genres.FindAsync(id);
            if (team != null)
                db.Genres.Remove(team);
        }
    }
}
