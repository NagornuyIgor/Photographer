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
        private readonly PhotoRepository repository;

        PhotoService(PhotoRepository repository)
        {
            this.repository = repository;
        }

        public IList<PhotoDto> Get(int photographerId)
        {
            var photos = repository.Get(p => p.PhotographerId == photographerId);

            return Mapper.Map<IList<PhotoDto>>(photos);
        }

        public void Add(UploadedPhotoDto uploadedPhotoDto)
        {
            var photo = Mapper.Map<Photo>(ParseMultipartAsync(uploadedPhotoDto.content));
            repository.Create(photo);
            repository.Save();
        }

        public void Delete(int id)
        {
            var photoDto = Mapper.Map<PhotoDto>(repository.Get(i => i.Id == id));

            try
            {
                File.Delete($"\\Photographer.Web\\App_Data\\PhotographersPhotos\\{photoDto.ImageName}");
            }
            catch(Exception ex)
            {
                throw ex;
            }

            repository.Delete(id);
            repository.Save();
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
