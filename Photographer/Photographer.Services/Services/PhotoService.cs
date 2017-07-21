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

namespace PhotographerPerformance.Services
{
    public interface IPhotoService
    {        
        IList<PhotoDto> Get(int photographerId);
        void Add(UploadedPhotoDto photo);
        void Delete(int id);
    }

    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository photoRepository;

        public PhotoService(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        public IList<PhotoDto> Get(int photographerId)
        {
            var photos = photoRepository.Get(p => p.PhotographerId == photographerId);

            return Mapper.Map<IList<PhotoDto>>(photos);
        }

        public void Add(UploadedPhotoDto uploadedPhotoDto)
        {
            var photo = Mapper.Map<Photo>(ParseMultipartAsync(uploadedPhotoDto.Content));

            photoRepository.Create(photo);
            photoRepository.Save();
        }

        public void Delete(int id)
        {
            var photo = photoRepository.GetById(id);

            try
            {
                File.Delete($"\\Photographer.Web\\App_Data\\PhotographersPhotos\\{photo.Name}");                
            }
            catch(Exception ex)
            {
                throw ex;
            }

            photoRepository.Delete(id);
            photoRepository.Save();
        }


        public async Task<PhotoDto> ParseMultipartAsync(HttpContent postedContent)
        {
            var photoDto = new PhotoDto();
            var provider = await postedContent.ReadAsMultipartAsync();   

            foreach (var content in provider.Contents)
            {
                if (!string.IsNullOrEmpty(content.Headers.ContentDisposition.FileName))
                {
                    photoDto.PhotographerId = int.Parse(content.Headers.ContentDisposition.Name.Trim('"'));
                    photoDto.ImageName = content.Headers.ContentDisposition.FileName.Trim('"');
                    var file = await content.ReadAsByteArrayAsync();
                    using (var ms = new MemoryStream(file))
                    {
                        //var img = Image.FromStream(ms);
                        //img.Save($"\\Photographer.Web\\App_Data\\PhotographersPhotos\\{photoDto.ImageName}");
                        Image.FromStream(ms).Save($"\\Photographer.Web\\App_Data\\PhotographersPhotos\\{photoDto.ImageName}");
                    }
                }
            }

            return photoDto;
        }
    }
}
