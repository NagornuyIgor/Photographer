using AutoMapper;
using PhotographerPerformance.Models;
using PhotographerPerformance.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotographerPerformance.Web.Models
{
    public class ViewModelMapperProfile : Profile
    {
        public ViewModelMapperProfile()
        {
            CreateMap<PhotoDto, PhotoViewModel>().PreserveReferences().ReverseMap();

            CreateMap<PhotographerDto, PhotographerViewModel>().PreserveReferences().ReverseMap();

            CreateMap<UploadedPhotoDto, UploadedPhotoViewModel>().PreserveReferences().ReverseMap();
        }
    }
}