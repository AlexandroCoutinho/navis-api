using AutoMapper;
using Navis.Application.Models.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class BrandFilterProfile : Profile
    {
        public BrandFilterProfile()
        {
            CreateMap<BrandFilterModel, BrandFilter>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase(typeof(BaseFilterModel), typeof(BaseFilter<>))
                ;

            CreateMap<BrandFilter, BrandFilterModel>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase(typeof(BaseFilter<>), typeof(BaseFilterModel))
                ;
        }
    }
}
