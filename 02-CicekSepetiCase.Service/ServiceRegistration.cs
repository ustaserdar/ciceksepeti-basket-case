using CicekSepetiCase.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepetiCase.Service
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();
            DataAccess.ServiceRegistration.ConfigureServices(services);
        }
    }
}
