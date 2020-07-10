using CicekSepetiCase.DataAccess.Contexts;
using CicekSepetiCase.DataAccess.Implementations;
using CicekSepetiCase.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CicekSepetiCase.DataAccess
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
