using BusnessService.Profiles;
using BusnessService.Service;
using DataModels.Context;
using DataModels.Repositories.IRepository;
using DataModels.Repositories.Repository;
using Microsoft.EntityFrameworkCore;


namespace TupPps
{
    public static class Startup
    {
        public static WebApplication InitializeApp(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);
            configurationService(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void configurationService(WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FerreTechContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("FerreConnection"));
                });
            builder.Services.AddAutoMapper(typeof(FerreTechMapperProfile));
        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
