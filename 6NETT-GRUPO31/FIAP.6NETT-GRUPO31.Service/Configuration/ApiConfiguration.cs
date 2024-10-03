using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FIAP._6NETT_GRUPO31.Service.Configuration
{
    public static class ApiConfig
    {

        public static void AddApConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FIAPContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
            });
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();            
            app.MapControllers();
        }
    }
}
