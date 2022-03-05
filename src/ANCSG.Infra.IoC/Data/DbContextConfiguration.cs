using ANCSG.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.Data
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SendGridContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
