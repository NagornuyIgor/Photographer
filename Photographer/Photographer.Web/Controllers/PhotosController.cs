using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotographerPerformance.Services;
using PhotographerPerformance.Models;
using PhotographerPerformance.Services.Dto;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.IO;
using PhotographerPerformance.Extensions;
using System.Threading.Tasks;
using System;

namespace PhotographerPerformance.Controllers
{
    public class PhotosController : ApiController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Uploads\";

        private readonly IPhotoService photoService;

        public PhotosController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        //public IHttpActionResult Get()
        //{
        //    return Json(1);
        //}

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var photos = new PhotoViewModel
            {
                Photos = photoService.Get(id)
            };

            return Json(photos);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add()
        {
            try
            {
                var provider = new CustomMultipartFormDataStreamProvider(workingFolder);

                await Task.Run(async () => await Request.Content.ReadAsMultipartAsync(provider));

                var photoDto = new PhotoDto();

                foreach (var file in provider.FileData)
                {
                    var data = provider.FormData;
                    var fileInfo = new FileInfo(file.LocalFileName);

                    photoDto = new PhotoDto
                    {
                        Name = fileInfo.Name,
                        PhotographerId = int.Parse(data.Get("Content[PhotographerId]"))
                    };

                    photoService.Add(photoDto);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            { 
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                photoService.Delete(id);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
