using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographerPerformance.Services.Dto
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhotographerId { get; set; }
    }
}
