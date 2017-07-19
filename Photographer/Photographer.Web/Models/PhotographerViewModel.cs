using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotographerPerformance.Services.Dto;

namespace PhotographerPerformance.Models
{
    public class PhotographerViewModel
    {
        public IList<PhotographerDto> Photographers { get; set; }
    }
}