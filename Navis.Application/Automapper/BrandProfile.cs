using AutoMapper;
using Navis.Application.Models.Brand;
using Navis.Domain.Entities;

namespace Navis.Application.Automapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandCreateModel, Brand>()
                .ForMember(dest => dest.Id, (src) => { src.Ignore(); })
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); });

            CreateMap<Brand, BrandReadModel>()
                .ForMember(dest => dest.Id, (x) => { x.MapFrom(src => src.Id); })
                .ForMember(dest => dest.Name, (x) => { x.MapFrom(src => src.Name); });
        }
    }
}
