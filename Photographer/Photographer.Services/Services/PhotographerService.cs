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
        //PhotographerDto GetOne(); Do i need this? 
        IList<PhotographerDto> GetAll();
        void Add(PhotographerDto photographer);
        void Delete(int id);
    }

    public class PhotographerService : IPhotographerService
    {
        private readonly PhotographerRepository repository;

        public PhotographerService(PhotographerRepository repository)
        {
            this.repository = repository;
        }

        public IList<PhotographerDto> GetAll()
        {
            var photographers = repository.GetAll(q => q.OrderBy(p => p.Id)).ToList();

            return Mapper.Map<IList<PhotographerDto>>(photographers);
        }

        public void Add(PhotographerDto photographerDto)
        {
            var photographer = Mapper.Map<Photographer>(photographerDto);
            repository.Create(photographer);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
        }
    }
}
