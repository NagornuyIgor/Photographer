using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Data.Models;
using System.Data.Entity;

namespace PhotographerPerformance.Data.Repositories
{
    public class PhotographerRepository : Repository<Photographer>
    {
        PhotographerRepository(DbContext context)
            : base(context) { }
    }
}
