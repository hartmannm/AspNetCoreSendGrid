using ANCSG.Application.Contexts.DoctorContext.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.UseCases
{
    public static class UseCaseConfiguration
    {
        public static IServiceCollection ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterDoctorUseCase, RegisterDoctorUseCase>();
            services.AddScoped<IGetDoctorByIdUseCase, GetDoctorByIdUseCase>();
            services.AddScoped<IGetAllDoctorsUseCase, GetAllDoctorsUseCase>();
            return services;
        }
    }
}
