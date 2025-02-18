using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Contact.Core.ServiceBus
{
    public static class  RabbitMqConfiguration
    {
        public static void AddRabitMqConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {                
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), h => {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });            

        }              
    }
}
