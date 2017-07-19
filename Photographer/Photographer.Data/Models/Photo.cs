using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographerPerformance.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhotographerId { get; set; }
    }
}
