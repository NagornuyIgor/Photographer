using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotographerPerformance.Services;
using PhotographerPerformance.Models;
using PhotographerPerformance.Services.Dto;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;

namespace PhotographerPerformance.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IPhotoService photoService;

        HomeController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        public IHttpActionResult Index(int photographerId)
        {
            var photos = new PhotoViewModel
            {
                Photos = photoService.Get(photographerId)
                //Photos = Mapper.Map<IList<PhotoDto>>(photoService.Get(photographerId))
            };

            return Json(photos);
        }

        [HttpPost]
        public HttpResponseMessage Add(UploadedPhotoViewModel photo)
        {
            photoService.Add(Mapper.Map<UploadedPhotoDto>(photo)); 

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            photoService.Delete(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
