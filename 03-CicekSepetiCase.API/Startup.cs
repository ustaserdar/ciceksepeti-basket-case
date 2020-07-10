using CicekSepetiCase.API.MiddlewareExtensions;
using CicekSepetiCase.API.RequestHandlers;
using CicekSepetiCase.DataAccess.Contexts;
using CicekSepetiCase.DataAccess.Settings;
using CicekSepetiCase.Service;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CicekSepetiCase.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Setting up mongdob connection string and database
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            #endregion

            services.AddMediatR(typeof(AddProductToBasket).GetTypeInfo().Assembly);

            #region Fill database with dummy datas
            var provider = services.BuildServiceProvider();
            var settings = provider.GetService<IOptions<MongoDbSettings>>();
            var context = new MongoContext(settings);
            context.Products.InsertMany(settings.Value.Products, new MongoDB.Driver.InsertManyOptions() { });
            #endregion

            ServiceRegistration.ConfigureServices(services);

            services.AddControllers();

            services.AddSwaggerGen(s => s.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Çiçeksepeti Case Basket API", Version = "v1.0" })); ; ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Çiçeksepeti Case Basket API"));

            app.UseExceptionHandler(appError => { });

            app.UseRouting();

            app.ConfigureExceptionHandler();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
