using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotographerPerformance.Services.Dto;

namespace PhotographerPerformance.Models
{
    public class PhotoViewModel
    {
        public IList<PhotoDto> Photos { get; set; }

        //public string UserId { get; set; }
    }
}