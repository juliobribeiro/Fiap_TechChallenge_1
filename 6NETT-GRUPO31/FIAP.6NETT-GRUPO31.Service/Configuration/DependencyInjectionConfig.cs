using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Infra.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace FIAP._6NETT_GRUPO31.Service.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)

        {

            services.AddScoped<FIAPContext>();
            //repository
            services.AddScoped<IContatoRepository, ContatoRepository>();

        }
    }
}
