using ANCSG.Application.Contexts.DoctorContext.UseCases;
using ANCSG.Application.Contexts.PatientContext.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.UseCases
{
    internal static class UseCaseConfiguration
    {
        public static IServiceCollection ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterDoctorUseCase, RegisterDoctorUseCase>();
            services.AddScoped<IGetDoctorByIdUseCase, GetDoctorByIdUseCase>();
            services.AddScoped<IGetAllDoctorsUseCase, GetAllDoctorsUseCase>();
            services.AddScoped<IRegisterPatientUseCase, RegisterPatientUseCase>();
            services.AddScoped<IGetPatientByIdUseCase, GetPatientByIdUseCase>();
            return services;
        }
    }
}
