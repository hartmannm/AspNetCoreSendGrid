using Microsoft.AspNetCore.Mvc;

namespace ANCSG.API.Configuration
{
    public static class VersionConfig
    {
        public static IServiceCollection ConfigureVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            return services;
        }
    }
}
