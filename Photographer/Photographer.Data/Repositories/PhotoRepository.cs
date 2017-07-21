using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Data.Models;
using System.Data.Entity;

namespace PhotographerPerformance.Data.Repositories
{
    public interface IPhotoRepository : IRepository<Photo>
    {
    }

    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DbContext context)
            :base(context) { }
    }
}
