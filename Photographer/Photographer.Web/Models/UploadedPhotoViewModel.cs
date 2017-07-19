using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PhotographerPerformance.Models
{
    public class UploadedPhotoViewModel
    {
        HttpContent content { get; set; }
    }
}