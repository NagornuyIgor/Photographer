using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographerPerformance.Services.Dto;
using PhotographerPerformance.Data.Repositories;
using PhotographerPerformance.Data.Models;
using AutoMapper;

namespace PhotographerPerformance.Services
{
    public interface IPhotographerService
    {
        IList<PhotographerDto> GetAll();
        void Add(PhotographerDto photographer);
        void Delete(int id);
        void Get(int id);
    }

    public class PhotographerService : IPhotographerService
    {
        private readonly IPhotographerRepository photographerRepository;
        private readonly IPhotoRepository photoRepository;

        public PhotographerService(IPhotographerRepository photographerRepository, IPhotoRepository photoRepository)
        {
            this.photographerRepository = photographerRepository;
            this.photoRepository = photoRepository;
        }

        public IList<PhotographerDto> GetAll()
        {
            var photographers = photographerRepository.GetAll(q => q.OrderBy(p => p.Id)).ToList();
            var photo = photoRepository.GetAll(q => q.OrderBy(p => p.Id)).ToList();

            //foreach (var photographer in photographers)
            //{
            //    photographer.PictureCount = photo.Count(p => p.PhotographerId == photographer.Id);


            //}

            return photographers.Select(p => new PhotographerDto
            {
                Name = p.Name,
                BirthDate = p.BirthDate,
                PictureCount = photo.Count(q => q.PhotographerId == p.Id)
            }).ToList();

            //return Mapper.Map<IList<PhotographerDto>>(photographers);
        }

        public void Add(PhotographerDto photographerDto)
        {
            var photographer = Mapper.Map<Photographer>(photographerDto);
            photographerRepository.Create(photographer);
            photographerRepository.Save();
        }

        public void Delete(int id)
        {
            photographerRepository.Delete(id);
            photographerRepository.Save();
        }

        public void Get(int photographerId)
        {
            var photographerDto = photographerRepository.Get(p => p.Id == photographerId);
        }
    }
}
