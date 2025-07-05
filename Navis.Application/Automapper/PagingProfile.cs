using AutoMapper;
using Navis.Application.ApplicationModels.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class PagingProfile : Profile
    {
        public PagingProfile()
        {
            CreateMap<PagingModel, Paging>()
                .ForMember(dest => dest.PageSize, (src) => { src.MapFrom(x => x.PageSize); })
                .ForMember(dest => dest.PageNumber, (src) => { src.MapFrom(x => x.PageNumber); })
                ;

            CreateMap<Paging, PagingModel>()
                .ForMember(dest => dest.PageSize, (src) => { src.MapFrom(x => x.PageSize); })
                .ForMember(dest => dest.PageNumber, (src) => { src.MapFrom(x => x.PageNumber); })
                ;
        }
    }
}
