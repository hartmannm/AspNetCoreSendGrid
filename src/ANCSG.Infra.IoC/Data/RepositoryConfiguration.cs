using ANCSG.Domain.Contexts.DoctorContext.Data;
using ANCSG.Domain.Contexts.MedicalExamContext.Data;
using ANCSG.Domain.Contexts.PatientContext.Data;
using ANCSG.Domain.Data;
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
