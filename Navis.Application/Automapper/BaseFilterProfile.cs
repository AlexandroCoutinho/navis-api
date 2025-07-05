using AutoMapper;
using Navis.Application.ApplicationModels.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class BaseFilterProfile : Profile
    {
        public BaseFilterProfile()
        {
            CreateMap<BaseFilterModel, BaseFilter>()
                .ForMember("Id", (src) => { src.MapFrom("Id"); })
                .ForMember("Paging", (src) => { src.MapFrom("Paging"); })
                .ForMember("Sorting", (src) => { src.MapFrom("Sorting"); })
                ;

            CreateMap<BaseFilter, BaseFilterModel>()
                .ForMember("Id", (src) => { src.MapFrom("Id"); })
                .ForMember("Paging", (src) => { src.MapFrom("Paging"); })
                .ForMember("Sorting", (src) => { src.MapFrom("Sorting"); })
                ;
        }
    }
}
