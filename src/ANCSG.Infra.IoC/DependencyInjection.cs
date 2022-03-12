using ANCSG.Application.Notification;
using ANCSG.Infra.IoC.Data;
using ANCSG.Infra.IoC.Notification;
using ANCSG.Infra.IoC.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotifier, Notifier>();
            services.ConfigureDbContext(configuration);
            services.ConfigureRepositories();
            services.ConfigureUseCases();
            services.ConfigureEmail(configuration);

            return services;
        }
    }
}
