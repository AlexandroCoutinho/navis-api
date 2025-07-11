﻿using AutoMapper;
using Navis.Application.ApplicationModels.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class BrandFilterProfile : Profile
    {
        public BrandFilterProfile()
        {
            CreateMap<BrandFilterModel, BrandFilter>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase<BaseFilterModel, BaseFilter>()
                ;

            CreateMap<BrandFilter, BrandFilterModel>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase<BaseFilter, BaseFilterModel>()
                ;
        }
    }
}
