using AutoMapper;
using Navis.Application.ApplicationModels.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class SortingProfile : Profile
    {
        public SortingProfile()
        {
            CreateMap<SortingModel, Sorting>()
                .ForMember(dest => dest.SortBy, (src) => { src.MapFrom(x => x.SortBy); })
                .ForMember(dest => dest.Ascending, (src) => { src.MapFrom(x => x.Ascending); })
                ;

            CreateMap<Sorting, SortingModel>()
                 .ForMember(dest => dest.SortBy, (src) => { src.MapFrom(x => x.SortBy); })
                .ForMember(dest => dest.Ascending, (src) => { src.MapFrom(x => x.Ascending); })
                ;
        }
    }
}
