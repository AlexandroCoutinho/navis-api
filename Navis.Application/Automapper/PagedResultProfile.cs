using AutoMapper;
using Navis.Application.ApplicationModels.PagedResult;
using Navis.Domain.Repository.PagedResult;

namespace Navis.Application.Automapper
{
    public class PagedResultProfile : Profile
    {
        public PagedResultProfile()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResultModel<>))
                .ForMember("PageSize", (x) => { x.MapFrom("PageSize"); })
                .ForMember("PageNumber", (x) => { x.MapFrom("PageNumber"); })
                .ForMember("TotalItems", (x) => { x.MapFrom("TotalItems"); })
                .ForMember("TotalPages", (x) => { x.MapFrom("TotalPages"); })
                ;
        }
    }
}
