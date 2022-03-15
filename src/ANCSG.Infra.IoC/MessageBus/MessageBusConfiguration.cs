using ANCSG.Application.MessageBus;
using ANCSG.Infra.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.MessageBus
{
    internal static class MessageBusConfiguration
    {
        public static IServiceCollection ConfigureMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RabbitMQ");

            services.AddSingleton<IMessageBus>(new RabbitMqMessageBus(connectionString));

            return services;
        }
    }
}
