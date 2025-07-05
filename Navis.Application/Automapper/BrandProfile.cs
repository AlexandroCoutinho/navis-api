using AutoMapper;
using Navis.Application.ApplicationModels.Brand;
using Navis.Domain.Entities;

namespace Navis.Application.Automapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandApplicationModel>()
                .ForMember(dest => dest.Id, (x) => { x.MapFrom(src => src.Id); })
                .ForMember(dest => dest.Name, (x) => { x.MapFrom(src => src.Name); })
                ;
        }
    }
}
