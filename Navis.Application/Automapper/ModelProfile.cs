using AutoMapper;
using Navis.Application.ApplicationModels;
using Navis.Domain.Entities;

namespace Navis.Application.Automapper
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Model, ModelApplicationModel>()
                .ForMember(dest => dest.Id, (x) => { x.MapFrom(src => src.Id); })
                .ForMember(dest => dest.Name, (x) => { x.MapFrom(src => src.Name); })
                ;

            CreateMap<ModelApplicationModel, Model>()
                .ForMember(dest => dest.Id, (x) => { x.MapFrom(src => src.Id); })
                .ForMember(dest => dest.Name, (x) => { x.MapFrom(src => src.Name); })
                .ForMember(dest => dest.IsDeleted, (x) => { x.Ignore(); })
                ;

        }
    }
}
