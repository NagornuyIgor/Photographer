using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PhotographerPerformance.Models
{
    public class UploadedPhotoViewModel
    {
        public HttpContent Content { get; set; }
    }
}