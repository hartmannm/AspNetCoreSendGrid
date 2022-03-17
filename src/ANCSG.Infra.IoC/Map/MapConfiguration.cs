using ANCSG.Application.Map;
using ANCSG.Application.Map.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ANCSG.Infra.IoC.Map
{
    internal static class MapConfiguration
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var autoMapper = ConfigureAutoMapper();
            services.AddSingleton(autoMapper);
            services.AddSingleton<IMap, AutoMapperMap>();

            return services;
        }

        private static IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile<DoctorProfile>();
            });
            config.AssertConfigurationIsValid();


            return config.CreateMapper();
        }
    }
}
