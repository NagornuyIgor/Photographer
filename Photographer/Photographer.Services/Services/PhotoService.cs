using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Services.Dto;
using PhotographerPerformance.Data.Repositories;
using PhotographerPerformance.Data.Models;
using AutoMapper;
using System.Net.Http;
using System.IO;
using System.Drawing;
using System.Web;

namespace PhotographerPerformance.Services
{
    public interface IPhotoService
    {        
        IList<PhotoDto> Get(int photographerId);
        void Add(PhotoDto photoDto);
        void Delete(int id);
    }

    public class PhotoService : IPhotoService
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Uploads\";
        private readonly IPhotoRepository photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        public IList<PhotoDto> Get(int photographerId)
        {
            var photos = photoRepository.Get(p => p.PhotographerId == photographerId);

            //foreach(var path in photos)
            //{
            //    path.Name = workingFolder + path.Name;
            //}

            return Mapper.Map<IList<PhotoDto>>(photos);
        }

        public void Add(PhotoDto photoDto)
        {
            var photo = Mapper.Map<Photo>(photoDto);

            photoRepository.Create(photo);
            photoRepository.Save();
        }

        public void Delete(int id)
        {
            var photo = photoRepository.GetById(id);

            try
            {
                File.Delete(workingFolder + photo.Name);                
            }
            catch(Exception ex)
            {
                throw ex;
            }

            photoRepository.Delete(id);
            photoRepository.Save();
        }
    }
}
