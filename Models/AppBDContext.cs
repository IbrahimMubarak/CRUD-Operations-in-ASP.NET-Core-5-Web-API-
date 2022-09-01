using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class AppBDContext:DbContext
    {
        public AppBDContext(DbContextOptions<AppBDContext>options):base(options)
        {

        }
        public DbSet<Genrie> Genries { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
