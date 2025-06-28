using AutoMapper;
using Navis.Application.Models.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class BaseFilterProfile : Profile
    {
        public BaseFilterProfile()
        {
            CreateMap(typeof(BaseFilterModel), typeof(BaseFilter<>))
                .ForMember("Id", (src) => { src.MapFrom("Id"); })
                .ForMember("Paging", (src) => { src.MapFrom("Paging"); })
                .ForMember("Sorting", (src) => { src.MapFrom("Sorting"); })
                ;

            CreateMap(typeof(BaseFilter<>), typeof(BaseFilterModel))
                .ForMember("Id", (src) => { src.MapFrom("Id"); })
                .ForMember("Paging", (src) => { src.MapFrom("Paging"); })
                .ForMember("Sorting", (src) => { src.MapFrom("Sorting"); })
                ;
        }
    }
}
