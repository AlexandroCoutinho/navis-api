using Microsoft.Extensions.DependencyInjection;
using Navis.Application.Automapper;
using Navis.Application.Services;
using Navis.Application.Services.Interfaces;
using Navis.Domain.Repository;
using Navis.Domain.Services;
using Navis.Domain.Services.Interfaces;
using Navis.Repository;

namespace Navis.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            ConfigureApplication(serviceCollection);
            ConfigureDomain(serviceCollection);
            ConfigureRepository(serviceCollection);
            ConfigureAutoMapper(serviceCollection);
        }

        private static void ConfigureApplication(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBrandApplicationService, BrandApplicationService>();
        }

        private static void ConfigureDomain(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBrandDomainService, BrandDomainService>();
        }

        private static void ConfigureRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBrandRepository, BrandRepository>();
        }

        private static void ConfigureAutoMapper(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(BrandProfile));
        }
    }
}
