using AutoMapper;
using Navis.Application.ApplicationModels.Filters;
using Navis.Domain.Repository.Filters;

namespace Navis.Application.Automapper
{
    public class ModelFilterProfile : Profile
    {
        public ModelFilterProfile()
        {
            CreateMap<ModelFilterModel, ModelFilter>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase<BaseFilterModel, BaseFilter>()
                ;

            CreateMap<ModelFilter, ModelFilterModel>()
                .ForMember(dest => dest.Name, (src) => { src.MapFrom(src => src.Name); })
                .IncludeBase<BaseFilter, BaseFilterModel>()
                ;
        }
    }
}
