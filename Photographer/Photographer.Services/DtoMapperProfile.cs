using AutoMapper;
using PhotographerPerformance.Data.Models;
using PhotographerPerformance.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographerPerformance.Services
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<Photo, PhotoDto>().PreserveReferences().ReverseMap();

            CreateMap<Photographer, PhotographerDto>().PreserveReferences().ReverseMap();
        }
    }
}
