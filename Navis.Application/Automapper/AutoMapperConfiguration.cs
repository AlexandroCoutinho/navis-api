using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Navis.Application.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(BrandProfile).Assembly);
        }
    }
}
