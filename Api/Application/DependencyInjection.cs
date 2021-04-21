using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton(GetConfiguredMappingConfig());
            // register Mapster
            services.AddScoped<IMapper, ServiceMapper>();

            // register MediatR handlers
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

        /// <summary>
        /// Mapster(Mapper) global configuration settings
        /// To learn more about Mapster,
        /// see https://github.com/MapsterMapper/Mapster
        /// </summary>
        /// <returns></returns>
        private static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = TypeAdapterConfig.GlobalSettings;

            IList<IRegister> registers = config.Scan(Assembly.GetExecutingAssembly());

            config.Apply(registers);

            return config;
        }
    }
}
