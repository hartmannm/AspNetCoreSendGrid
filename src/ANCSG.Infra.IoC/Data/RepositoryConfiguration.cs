using ANCSG.Application.Contexts.DoctorContext.Data;
using ANCSG.Application.Contexts.MedicalExamContext.Data;
using ANCSG.Application.Contexts.PatientContext.Data;
using ANCSG.Application.Data;
using ANCSG.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.Data
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IMedicalExamRepository, MedicalExamRepository>();
            services.AddScoped<IDataManager, DataManager>();
            return services;
        }
    }
}
