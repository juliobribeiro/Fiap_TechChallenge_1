using FIAP._6NETT_GRUPO31.Application.Interfaces;
using FIAP._6NETT_GRUPO31.Application.Services;
using FIAP._6NETT_GRUPO31.Domain.Entities;
using FIAP._6NETT_GRUPO31.Infra.Data.Context;
using FIAP._6NETT_GRUPO31.Infra.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Contact.Core.ServiceBus;
using Prometheus;
using MassTransit;
using FIAP._6NETT_GRUPO31.Application.Consumers;


namespace FIAP._6NETT_GRUPO31.API.Configuration
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
            services.UseHttpClientMetrics();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<AddContactConsumer>();
                x.AddConsumer<UpdateContactConsumer>();
                x.AddConsumer<DeleteContactConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    //cfg.Host(new Uri("amqp://localhost:5672"), h => {
                    cfg.Host(new Uri("amqp://localhost:5672"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });


        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMetricServer();
            app.UseHttpMetrics();
            // app.UseHttpsRedirection();            
            app.MapControllers();
        }
    }
}
