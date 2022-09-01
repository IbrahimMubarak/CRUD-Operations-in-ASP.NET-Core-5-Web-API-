using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;
using WEBAPI.Models;

namespace WEBAPI.Services
{
    public class GenrieServices : IGenriesReprosatory
    {
        private readonly AppBDContext ctx;
        public GenrieServices(AppBDContext _ctx)
        {
            ctx = _ctx;
        }

      

        
        public async Task<IEnumerable<Genrie>> GetAll()
        {
            return await ctx.Genries.ToListAsync();
        }

        public async Task<Genrie> GetById(int id)
        {
            
            return await ctx.Genries.SingleOrDefaultAsync(c=>c.Id==id);

        }
        public async Task<Genrie> Create(Genrie genrie)
        {
            await ctx.AddAsync(genrie);
            ctx.SaveChanges();
            return (genrie);
        }
        public Genrie Update(Genrie genrie)
        {
            ctx.Update(genrie);
            ctx.SaveChanges();
            return(genrie);
        }
        public Genrie Delete(Genrie genrie)
        {
            ctx.Remove(genrie);
            ctx.SaveChanges();
            return(genrie);
        }
    }
}
