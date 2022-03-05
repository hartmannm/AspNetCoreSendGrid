using ANCSG.Domain.Notification;
using ANCSG.Infra.IoC.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.ConfigureRepositories();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
