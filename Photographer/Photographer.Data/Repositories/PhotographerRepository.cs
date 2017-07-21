using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Data.Models;
using System.Data.Entity;

namespace PhotographerPerformance.Data.Repositories
{
    public interface IPhotographerRepository : IRepository<Photographer>
    {
    }

    public class PhotographerRepository : Repository<Photographer>, IPhotographerRepository
    {
        public PhotographerRepository(DbContext context)
            : base(context) { }
    }
}
