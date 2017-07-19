using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotographerPerformance.Services;
using PhotographerPerformance.Models;
using PhotographerPerformance.Services.Dto;
using AutoMapper;

namespace PhotographerPerformance.Controllers
{
    public class PhotographersController : ApiController
    {
        private readonly IPhotographerService photographerService;

        PhotographersController(IPhotographerService photographerService)
        {
            this.photographerService = photographerService;
        }

        // GET api/photographers
        public IHttpActionResult Get()
        {
            var photographers = new PhotographerViewModel
            {
                Photographers = photographerService.GetAll()
            };

            return Json(photographers);
        }

        // POST api/photographers/Add
        [HttpPost]
        public HttpResponseMessage Add(PhotographerViewModel photographer)
        {
            photographerService.Add(Mapper.Map<PhotographerDto>(photographer));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // POST api/delete
        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            photographerService.Delete(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
