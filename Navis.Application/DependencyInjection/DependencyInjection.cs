using Microsoft.Extensions.DependencyInjection;
using Navis.Application.ApplicationServices;
using Navis.Application.ApplicationServices.Interfaces;
using Navis.Domain.Repository.Interfaces;
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
    }
}
