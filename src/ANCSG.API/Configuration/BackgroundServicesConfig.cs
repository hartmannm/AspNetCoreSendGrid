using ANCSG.API.Services;

namespace ANCSG.API.Configuration
{
    public static class BackgroundServicesConfig
    {
        public static IServiceCollection ConfigureBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<DoctorRegisteredIntegrationHandler>();
            services.AddHostedService<PatientRegisteredIntegrationHandler>();
            services.AddHostedService<DoctorExamScheduledIntegrationHandler>();
            services.AddHostedService<PatientExamScheduledIntegrationHandler>();

            return services;
        }
    }
}
