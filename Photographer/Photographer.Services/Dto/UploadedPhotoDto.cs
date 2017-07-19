using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotographerPerformance.Services.Dto
{
    public class UploadedPhotoDto
    {
        public HttpContent content { get; set; }
    }
}

