using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Data.Models;

namespace PhotographerPerformance.Data 
{
    public class PhotographerDbContext : DbContext
    {
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public PhotographerDbContext() 
            : base("PhotographerDbContext")
        {
        }
    }
}
