using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;
using WEBAPI.Models;

namespace WEBAPI.Services
{
    class MovieServices : IMoviesReprosatory
    {
        private readonly AppBDContext ctx;
        public MovieServices(AppBDContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            var movie = await ctx.Movies.Include(m=>m.Genrie).ToListAsync();
            return movie;
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = await ctx.Movies.Include(m=>m.Genrie).SingleOrDefaultAsync(m=>m.Id==id);
            return movie;
        }
        public async Task<Movie> Create(Movie movie)
        {
            await ctx.Movies.AddAsync(movie);
            ctx.SaveChanges();
            return (movie);
        }
        public Movie Update(Movie movie)
        {
            ctx.Movies.Update(movie);
            ctx.SaveChanges();

            return (movie);
        }

        public Movie Delete(Movie movie)
        {
            ctx.Movies.Remove(movie);
            ctx.SaveChanges();
            return (movie);
        }

    }
}
