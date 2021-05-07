using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Enable Entity Framework and setup migration assembly
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Scoped lifetime services are created once per request within the scope.
            // Create DI for IApplicationDbContext that binds to ApplicationDbContext
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            // Register Services through Dependency Injection
            // Register the OData Services
            services.AddOData();
            services.AddControllers(
                    options =>
                    {
                        options.EnableEndpointRouting = false;
                        var outputFormatters =
                            options.OutputFormatters.OfType<ODataOutputFormatter>()
                                .Where(formatter => formatter.SupportedMediaTypes.Count == 0);

                        foreach (var outputFormatter in outputFormatters) outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                    })
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); ;
            return services;
        }
    }
}
